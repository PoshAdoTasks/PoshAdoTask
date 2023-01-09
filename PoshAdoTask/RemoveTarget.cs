namespace PoshAdoTask.Manifest.Cmdlets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Management.Automation;
    using PoshAdoTask.Manifest.Types;
    using System.Configuration;

    [Cmdlet(VerbsCommon.Remove, "Target", HelpUri = "")]
    [OutputType(typeof(PoshAdoTask.Manifest.Types.Manifest))]
    [CmdletBinding(PositionalBinding = true)]
    public class RemoveTarget : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public Manifest? Manifest { get; set; }
        [Parameter(Mandatory = true, Position = 1)]
        [ValidateSet("Microsoft.TeamFoundation.Server", "Microsoft.TeamFoundation.Server.Integration", "Microsoft.VisualStudio.Services", "Microsoft.VisualStudio.Services.Cloud", "Microsoft.VisualStudio.Services.Cloud.Integration", "Microsoft.VisualStudio.Services.Integration")]
        public string? TargetId { get; set; }
        protected override void BeginProcessing()
        {
            WriteVerbose("RemoveTarget : Begin Processing");
            WriteVerbose("TargetId     : " + TargetId);
        }
        protected override void ProcessRecord()
        {
            WriteVerbose("RemoveTarget : Process Record");
            if (Manifest != null)
            {
                WriteVerbose("Remove Target");
                Target? delTarget = Manifest.Targets.Find(t => t.Id == TargetId);
                if (delTarget != null)
                {
                    Manifest.Targets.Remove(delTarget);
                }
            }
        }
        protected override void EndProcessing()
        {
            WriteVerbose("RemoveTarget : End Process");
            WriteObject(Manifest);
        }
    }
}