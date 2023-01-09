namespace PoshAdoTask.Manifest.Cmdlets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Management.Automation;
    using PoshAdoTask.Task.Types;
    using System.Configuration;

    [Cmdlet(VerbsCommon.New, "Execution", HelpUri = "https://github.com/PoshAdoTasks/PoshAdoTask/blob/main/Docs/New-Execution.md")]
    [OutputType(typeof(PoshAdoTask.Task.Types.Task))]
    [CmdletBinding(PositionalBinding = true)]
    public class NewExecution : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public Task? Task { get; set; }
        [Parameter(Mandatory = true, Position = 1)]
        [ValidateSet("Node16", "Node10", "Node", "PowerShell3", "PowerShell")]
        public string? Execution { get; set; }
        [Parameter(Mandatory = false, Position = 2)]
        public string? Target { get; set; }
        protected override void BeginProcessing()
        {
            WriteVerbose("NewExecution : Begin Processing");
            WriteVerbose("Execution    : " + Execution);
            WriteVerbose("Target       : " + Target);
        }
        protected override void ProcessRecord()
        {
            WriteVerbose("NewExecution : Process Record");
            if (Task != null)
            {
                Execution newExecution = new();
                if (!(string.IsNullOrEmpty(Execution)) && !(string.IsNullOrEmpty(Target)))
                {
                    newExecution = new(Execution, Target);
                    Task.Execution = newExecution;
                }
            }
        }
        protected override void EndProcessing()
        {
            WriteVerbose("NewExecution : End Process");
            WriteObject(Task);
        }
    }
}