namespace PoshAdoTask.Manifest.Cmdlets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Management.Automation;
    using PoshAdoTask.Task.Types;
    using System.Configuration;

    [Cmdlet(VerbsCommon.Add, "Input", HelpUri = "")]
    [OutputType(typeof(PoshAdoTask.Task.Types.Task))]
    [CmdletBinding(PositionalBinding = true)]
    public class AddInput : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public Task? Task { get; set; }
        [Parameter(Mandatory = true, Position = 1)]
        public string? Name { get; set; }
        [Parameter(Mandatory = true, Position = 2)]
        [ValidateSet("boolean", "filePath", "multiline", "picklist", "radio", "secureFile", "string", "int", "identities", "querycontrol")]
        public string? Type { get; set; }
        [Parameter(Mandatory = false, Position = 3)]
        public string? Label { get; set; }
        [Parameter(Mandatory = false, Position = 4)]
        public SwitchParameter Required { get; set; }
        [Parameter(Mandatory = false, Position = 5)]
        public string? HelpMarkDown { get; set; }
        protected override void BeginProcessing()
        {
            WriteVerbose("AddInput     : Begin Processing");
            WriteVerbose("Name         : " + Name);
            WriteVerbose("Type         : " + Type);
            WriteVerbose("Label        : " + Label);
            WriteVerbose("Required     : " + Required);
            WriteVerbose("HelpMarkDown : " + HelpMarkDown);
        }
        protected override void ProcessRecord()
        {
            WriteVerbose("AddInput : Process Record");
            if (Task != null)
            {
                Input newInput = new();
                bool Found = Task.Inputs.Exists(i => i.Name == Name);
                if (Found)
                {
                    Exception ex = new("Duplicate Input Found");
                    throw ex;
                } else
                {
                    if (!(string.IsNullOrEmpty(Name))) { newInput.Name = Name; }
                    if (!(string.IsNullOrEmpty(Label))) { newInput.Label = Label; }
                    if (!(string.IsNullOrEmpty(HelpMarkDown))) { newInput.HelpMarkDown = HelpMarkDown; }
                    newInput.Required = Required;
                    if (!(string.IsNullOrEmpty(Type)))
                    {
                        switch (Type.ToLower())
                        {
                            case "boolean":
                                newInput.Type = TaskType.boolean;
                                break;
                            case "filePath":
                                newInput.Type = TaskType.filePath;
                                break;
                            case "multiline":
                                newInput.Type = TaskType.multiline;
                                break;
                            case "picklist":
                                newInput.Type = TaskType.picklist;
                                break;
                            case "radio":
                                newInput.Type = TaskType.radio;
                                break;
                            case "secureFile":
                                newInput.Type = TaskType.secureFile;
                                break;
                            case "string":
                                newInput.Type = TaskType.@string;
                                break;
                            case "int":
                                newInput.Type = TaskType.@int;
                                break;
                            case "identities":
                                newInput.Type = TaskType.identities;
                                break;
                            case "querycontrol":
                                newInput.Type = TaskType.querycontrol;
                                break;
                        }
                    }
                    Task.Inputs.Add(newInput);
                }
            }
        }
        protected override void EndProcessing()
        {
            WriteVerbose("AddInput : End Process");
            WriteObject(Task);
        }
    }
}