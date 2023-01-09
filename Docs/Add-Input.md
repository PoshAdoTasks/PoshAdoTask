---
external help file: PoshAdoTask.dll-Help.xml
Module Name: PoshAdoTask
online version:
schema: 2.0.0
---

# Add-Input

## SYNOPSIS
{{ Fill in the Synopsis }}

## SYNTAX

```
Add-Input [-Task] <Task> [-Name] <String> [-Type] <String> [[-Label] <String>] [-Required]
 [[-HelpMarkDown] <String>] [<CommonParameters>]
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

### -HelpMarkDown
{{ Fill HelpMarkDown Description }}

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 5
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Label
{{ Fill Label Description }}

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 3
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
{{ Fill Name Description }}

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Required
{{ Fill Required Description }}

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

### -Task
{{ Fill Task Description }}

```yaml
Type: PoshAdoTask.Task.Types.Task
Parameter Sets: (All)
Aliases:

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Type
{{ Fill Type Description }}

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:
Accepted values: boolean, filePath, multiline, picklist, radio, secureFile, string, int, identities, querycontrol

Required: True
Position: 2
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### PoshAdoTask.Task.Types.Task

## OUTPUTS

### PoshAdoTask.Task.Types.Task

## NOTES

## RELATED LINKS
