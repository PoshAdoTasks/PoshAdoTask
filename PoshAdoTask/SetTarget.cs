namespace PoshAdoTask.Cmdlets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Management.Automation;
    using PoshAdoTask.Types;
    using System.Configuration;

    [Cmdlet(VerbsCommon.Set, "Target", HelpUri = "")]
    [OutputType(typeof(PoshAdoTask.Types.Link))]
    [CmdletBinding(PositionalBinding = true)]
    public class SetTarget : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public Manifest? Manifest { get; set; }
        [Parameter(Mandatory = true, Position = 1)]
        [ValidateSet("Microsoft.TeamFoundation.Server", "Microsoft.TeamFoundation.Server.Integration", "Microsoft.VisualStudio.Services", "Microsoft.VisualStudio.Services.Cloud", "Microsoft.VisualStudio.Services.Cloud.Integration", "Microsoft.VisualStudio.Services.Integration")]
        public string? TargetId { get; set; }
        [Parameter(Mandatory = false, Position = 2)]
        public string? Version { get; set; } = string.Empty;
        [Parameter(Mandatory = false, Position = 3)]
        public SwitchParameter Remove { get; set; }
        protected override void BeginProcessing()
        {
            WriteVerbose("SetTarget : Begin Processing");
            WriteVerbose("TargetId  : " + TargetId);
            WriteVerbose("Version   : " + Version);
            WriteVerbose("Remove    : " + Remove);
        }
        protected override void ProcessRecord()
        {
            WriteVerbose("SetTarget : Process Record");
            if (Manifest != null)
            {
                Target newTarget = new();
                if (!(string.IsNullOrEmpty(TargetId)))
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
                WriteVerbose("Found Target: " + Found);
                if (MyInvocation.BoundParameters.ContainsKey(nameof(Remove)))
                {
                    if ((SwitchParameter)MyInvocation.BoundParameters[(nameof(Remove))] && Found)
                    {
                        WriteVerbose("Remove Target");
                        Target? delTarget = Manifest.Targets.Find(t => t.Id == TargetId);
                        if (delTarget != null)
                        {
                            Manifest.Targets.Remove(delTarget);
                        }
                    }
                } else  if (!(Found))
                {
                    WriteVerbose("Add Target");
                    Manifest.Targets.Add(newTarget);
                }
            }
        }
        protected override void EndProcessing()
        {
            WriteVerbose("SetTarget : End Process");
            WriteObject(Manifest);
        }
    }
}