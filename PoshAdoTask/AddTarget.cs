namespace PoshAdoTask.Manifest.Cmdlets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Management.Automation;
    using PoshAdoTask.Manifest.Types;
    using System.Configuration;

    [Cmdlet(VerbsCommon.Add, "Target", HelpUri = "https://github.com/PoshAdoTasks/PoshAdoTask/blob/main/Docs/Add-Target.md")]
    [OutputType(typeof(PoshAdoTask.Manifest.Types.Manifest))]
    [CmdletBinding(PositionalBinding = true)]
    public class AddTarget : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public Manifest? Manifest { get; set; }
        [Parameter(Mandatory = true, Position = 1)]
        [ValidateSet("Microsoft.TeamFoundation.Server", "Microsoft.TeamFoundation.Server.Integration", "Microsoft.VisualStudio.Services", "Microsoft.VisualStudio.Services.Cloud", "Microsoft.VisualStudio.Services.Cloud.Integration", "Microsoft.VisualStudio.Services.Integration")]
        public string? TargetId { get; set; }
        [Parameter(Mandatory = false, Position = 2)]
        public string? Version { get; set; }
        protected override void BeginProcessing()
        {
            WriteVerbose("AddTarget : Begin Processing");
            WriteVerbose("TargetId  : " + TargetId);
            WriteVerbose("Version   : " + Version);
        }
        protected override void ProcessRecord()
        {
            WriteVerbose("AddTarget : Process Record");
            if (Manifest != null)
            {
                Target newTarget = new();
                if (!(string.IsNullOrEmpty(TargetId)) && string.IsNullOrEmpty(Version))
                {
                    newTarget = new(TargetId);
                    WriteVerbose("Target created id");
                }
                if (!(string.IsNullOrEmpty(TargetId)) && !(string.IsNullOrEmpty(Version)))
                {
                    newTarget = new(TargetId, Version);
                    WriteVerbose("Target created id, version");
                }

                bool Found = Manifest.Targets.Exists(t => t.Id == TargetId);
                if (!(Found))
                {
                    WriteVerbose("Add Target");
                    Manifest.Targets.Add(newTarget);
                }
            }
        }
        protected override void EndProcessing()
        {
            WriteVerbose("AddTarget : End Process");
            WriteObject(Manifest);
        }
    }
}