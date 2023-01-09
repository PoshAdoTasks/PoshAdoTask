namespace PoshAdoTask.Manifest.Cmdlets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Management.Automation;
    using PoshAdoTask.Task.Types;
    using System.Configuration;

    [Cmdlet(VerbsData.Out, "Task", HelpUri = "https://github.com/PoshAdoTasks/PoshAdoTask/blob/main/Docs/Out-Task.md")]
    [OutputType(typeof(System.Text.Json.JsonDocument))]
    [CmdletBinding(PositionalBinding = true)]
    public class OutTask : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public Task? Task { get; set; }
        protected override void BeginProcessing()
        {
            WriteVerbose("OutTask : Begin Processing");
        }
        protected override void ProcessRecord()
        {
            WriteVerbose("OutTask : Process Record");
        }
        protected override void EndProcessing()
        {
            WriteVerbose("OutTask : End Process");
            if (Task != null)
            {
                WriteObject(Task.ToString());
            }
        }
    }
}