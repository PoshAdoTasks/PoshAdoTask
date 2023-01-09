---
external help file: PoshAdoTask.dll-Help.xml
Module Name: PoshAdoTask
online version:
schema: 2.0.0
---

# Set-Category

## SYNOPSIS
{{ Fill in the Synopsis }}

## SYNTAX

### Manifest
```
Set-Category [-Manifest] <Manifest> [-AzureArtifacts] [-AzureBoards] [-AzurePipelines] [-AzureRepos]
 [-AzureTestPlans] [<CommonParameters>]
```

### Task
```
Set-Category [-Task] <Task> [-AzureArtifacts] [-AzureBoards] [-AzurePipelines] [-AzureRepos] [-AzureTestPlans]
 [-Build] [-Utility] [-Test] [-Package] [-Deploy] [<CommonParameters>]
```

## DESCRIPTION
{{ Fill in the Description }}

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

## PARAMETERS

### -AzureArtifacts
{{ Fill AzureArtifacts Description }}

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AzureBoards
{{ Fill AzureBoards Description }}

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AzurePipelines
{{ Fill AzurePipelines Description }}

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AzureRepos
{{ Fill AzureRepos Description }}

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: 4
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AzureTestPlans
{{ Fill AzureTestPlans Description }}

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: 5
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Build
{{ Fill Build Description }}

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: Task
Aliases:

Required: False
Position: 6
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Deploy
{{ Fill Deploy Description }}

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: Task
Aliases:

Required: False
Position: 10
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Manifest
{{ Fill Manifest Description }}

```yaml
Type: PoshAdoTask.Manifest.Types.Manifest
Parameter Sets: Manifest
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Package
{{ Fill Package Description }}

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: Task
Aliases:

Required: False
Position: 9
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Task
{{ Fill Task Description }}

```yaml
Type: PoshAdoTask.Task.Types.Task
Parameter Sets: Task
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Test
{{ Fill Test Description }}

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: Task
Aliases:

Required: False
Position: 8
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Utility
{{ Fill Utility Description }}

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: Task
Aliases:

Required: False
Position: 7
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### PoshAdoTask.Manifest.Types.Manifest

### PoshAdoTask.Task.Types.Task

## OUTPUTS

### PoshAdoTask.Manifest.Types.Manifest

### PoshAdoTask.Task.Types.Task

## NOTES

## RELATED LINKS
