namespace PoshAdoTask.Manifest.Cmdlets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Management.Automation;
    using PoshAdoTask.Manifest.Types;
    using PoshAdoTask.Task.Types;
    using System.Configuration;

    [Cmdlet(VerbsCommon.New, "Version", HelpUri = "https://github.com/PoshAdoTasks/PoshAdoTask/blob/main/Docs/New-Version.md")]
    [OutputType(typeof(PoshAdoTask.Manifest.Types.Manifest))]
    [OutputType(typeof(PoshAdoTask.Task.Types.Task))]
    [CmdletBinding(PositionalBinding = true)]
    public class NewVersion : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "Manifest")]
        public Manifest? Manifest { get; set; }
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true, ParameterSetName = "Task")]
        public Task? Task { get; set; }

        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "Manifest")]
        [Parameter(Mandatory = true, Position = 1, ParameterSetName = "Task")]
        public System.Version? Version { get; set; }
        protected override void BeginProcessing()
        {
            WriteVerbose("NewVersion : Begin Processing");
            WriteVerbose("Version    : " + Version);
        }
        protected override void ProcessRecord()
        {
            WriteVerbose("NewVersion : Process Record");
            if (Manifest != null)
            {
                if (Version != null)
                {
                    Manifest.Version = Version.ToString();
                }
            }
            if (Task != null)
            {
                if (Version != null)
                {
                    Task.Version = new PoshAdoTask.Task.Types.Version(Version);
                }
            }
        }
        protected override void EndProcessing()
        {
            WriteVerbose("NewVersion : End Process");
            if (Manifest != null) { WriteObject(Manifest); }
            if (Task != null) { WriteObject(Task); }
        }
    }
}