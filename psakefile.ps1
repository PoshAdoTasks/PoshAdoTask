$script:moduleName = "PoshAdoTask"
$script:Github = "https://github.com/PoshAdoTasks/PoshAdoTask"
$script:PoshGallery = "https://www.powershellgallery.com/packages/PoshAdoTask"
$script:Nuget = ""
$script:DiscordChannel = "https://discord.com/channels/1044305359021555793/1044305460729225227"

Task default -depends UpdateReadme

Task LocalUse -Description "Setup for local use and testing" -depends CreateModuleDirectory, CleanModuleDirectory, CleanProject, BuildProject, CopyModuleFiles -Action {
}

Task UpdateHelp -Description "Update the help files" -depends CreateModuleDirectory, CleanProject, BuildProject, CopyModuleFiles -Action {

 Import-Module -Name ".\Module\$($script:moduleName)" -Scope Global -force;
 New-MarkdownHelp -Module PoshAdoTask -AlphabeticParamsOrder -UseFullTypeName -WithModulePage -OutputFolder .\Docs\ -ErrorAction SilentlyContinue
 Update-MarkdownHelp -Path .\Docs\ -AlphabeticParamsOrder -UseFullTypeName
}

Task UpdateReadme -Description "Update the README file" -depends CreateModuleDirectory, CleanProject, BuildProject, CopyModuleFiles -Action {

 $readMe = Get-Item .\README.md

 $TableHeaders = "| Latest Version | PowerShell Gallery | Issues | License | Discord |"
 $Columns = "|-----------------|----------------|----------------|----------------|----------------|"
 $VersionBadge = "[![Latest Version](https://img.shields.io/github/v/tag/PoshAdoTasks/PoshAdoTask)](https://github.com/PoshAdoTasks/PoshAdoTask/tags)"
 $GalleryBadge = "[![Powershell Gallery](https://img.shields.io/powershellgallery/dt/PoshAdoTask)](https://www.powershellgallery.com/packages/PoshAdoTask)"
 $IssueBadge = "[![GitHub issues](https://img.shields.io/github/issues/PoshAdoTasks/PoshAdoTask)](https://github.com/PoshAdoTasks/PoshAdoTask/issues)"
 $LicenseBadge = "[![GitHub license](https://img.shields.io/github/license/PoshAdoTasks/PoshAdoTask)](https://github.com/PoshAdoTasks/PoshAdoTask/blob/master/LICENSE)"
 $DiscordBadge = "[![Discord Server](https://assets-global.website-files.com/6257adef93867e50d84d30e2/636e0b5493894cf60b300587_full_logo_white_RGB.svg)]($($script:DiscordChannel))"

 if (!(Get-Module -Name $script:moduleName )) { Import-Module -Name ".\Module\$($script:moduleName).psd1" }

 Write-Output $TableHeaders | Out-File $readMe.FullName -Force
 Write-Output $Columns | Out-File $readMe.FullName -Append
 Write-Output "| $($VersionBadge) | $($GalleryBadge) | $($IssueBadge) | $($LicenseBadge) | $($DiscordBadge) |" | Out-File $readMe.FullName -Append

 Get-Content .\Docs\PoshAdoTask.md | Select-Object -Skip 8 | ForEach-Object { $_.Replace('(', '(Docs/') } | Out-File $readMe.FullName -Append
 Write-Output "" | Out-File $readMe.FullName -Append
 #Get-Content .\Build.md | Out-File $readMe.FullName -Append
}

Task SetupModule -Description "Setup the PowerShell Module" -depends CreateModuleDirectory, CleanModuleDirectory, CleanProject, BuildProject, CopyModuleFiles, CreateExternalHelp, CreateCabFile, CreateNuSpec, NugetPack, NugetPush

Task NewTaggedRelease -Description "Create a tagged release" -depends CreateModuleDirectory, CleanProject, BuildProject, CopyModuleFiles -Action {


 if (!(Get-Module -Name $script:moduleName )) { Import-Module -Name ".\Module\$($script:moduleName).psd1" }
 $Version = (Get-Module -Name $script:moduleName | Select-Object -Property Version).Version.ToString()
 git tag -a v$version -m "$($script:moduleName) Version $($Version)"
 git push origin v$version
}

Task Post2Discord -Description "Post a message to discord" -Action {

 $version = (Get-Module -Name $script:moduleName | Select-Object -Property Version).Version.ToString()
 $Discord = Get-Content .\discord.PoshAdoTask | ConvertFrom-Json
 $Discord.message.content = "Version $($version) of $($script:moduleName) released. Please visit Github ($($script:Github)) or PowershellGallery ($($script:PoshGallery)) to download."
 Invoke-RestMethod -Uri $Discord.uri -Body ($Discord.message | ConvertTo-Json -Compress) -Method Post -ContentType 'application/json; charset=UTF-8'
}

Task CleanProject -Description "Clean the project before building" -Action {
 dotnet clean .\PoshAdoTask\PoshAdoTask.csproj
}

Task BuildProject -Description "Build the project" -Action {
 dotnet build .\PoshAdoTask\PoshAdoTask.csproj -c Release
}

Task CreateModuleDirectory -Description "Create the module directory" -Action {
 New-Item Module -ItemType Directory -Force
}

Task CleanModuleDirectory -Description "Clean the module directory" -Action {
 Get-ChildItem .\Module\ | Remove-Item
}

Task CopyModuleFiles -Description "Copy files for the module" -Action {
 Copy-Item .\PoshAdoTask\bin\Release\net6.0\*.dll Module -Force
 Copy-Item .\PoshAdoTask.psd1 Module -Force
}

Task CreateExternalHelp -Description "Create external help file" -Action {
 New-ExternalHelp -Path .\Docs -OutputPath .\Module\ -Force
}

Task CreateCabFile -Description "Create cab file for download" -Action {
 New-ExternalHelpCab -CabFilesFolder .\Module\ -LandingPagePath .\Docs\PoshAdoTask.md -OutputFolder .\cabs\
}

Task CreateNuSpec -Description "Create NuSpec file for upload" -Action {
 .\ConvertTo-NuSpec.ps1 -ManifestPath ".\Module\PoshAdoTask.psd1"
}

Task NugetPack -Description "Pack the nuget file" -Action {
 nuget pack .\Module\PoshAdoTask.nuspec -OutputDirectory .\Module
}

Task NugetPush -Description "Push nuget to PowerShell Gallery" -Action {
 $config = [xml](Get-Content .\nuget.config)
 nuget push .\Module\*.nupkg -NonInteractive -ApiKey "$($config.configuration.apikeys.add.value)" -ConfigFile .\nuget.config
}

Task PesterTest -Description "Test Cmdlets" -Action {
 Invoke-Pester
}