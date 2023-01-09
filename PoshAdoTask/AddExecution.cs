namespace PoshAdoTask.Manifest.Cmdlets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Management.Automation;
    using PoshAdoTask.Task.Types;
    using System.Configuration;

    [Cmdlet(VerbsCommon.Add, "Execution", HelpUri = "")]
    [OutputType(typeof(PoshAdoTask.Manifest.Types.Link))]
    [CmdletBinding(PositionalBinding = true)]
    public class AddExecution : PSCmdlet
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
            WriteVerbose("AddExecution : Begin Processing");
            WriteVerbose("Execution    : " + Execution);
            WriteVerbose("Target       : " + Target);
        }
        protected override void ProcessRecord()
        {
            WriteVerbose("AddExecution : Process Record");
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
            WriteVerbose("AddExecution : End Process");
            WriteObject(Task);
        }
    }
}