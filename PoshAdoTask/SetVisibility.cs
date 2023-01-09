namespace PoshAdoTask.Manifest.Cmdlets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Management.Automation;
    using PoshAdoTask.Task.Types;
    using System.Configuration;
    using System.Management;

    [Cmdlet(VerbsCommon.Set, "Visibility", HelpUri = "")]
    [OutputType(typeof(PoshAdoTask.Task.Types.Visibility))]
    [CmdletBinding(PositionalBinding = true)]
    public class SetVisibility : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public Task? Task { get; set; }
        [Parameter(Mandatory = false, Position = 1)]
        public SwitchParameter Build { get; set; }
        [Parameter(Mandatory = false, Position = 2)]
        public SwitchParameter Release { get; set; }
        protected override void BeginProcessing()
        {
            WriteVerbose("SetVisibility : Begin Processing");
            WriteVerbose("Build         : " + Build);
            WriteVerbose("Release       : " + Release);
        }
        protected override void ProcessRecord()
        {
            if (Task != null)
            {
                int Capacity = (Task.Visibility ??= new List<Visibility>()).Capacity;
            }
            WriteVerbose("SetGalleryFlag : Process Record");
            if (Task != null && Task.Visibility != null)
            {
                if (MyInvocation.BoundParameters.ContainsKey(nameof(Build)))
                {
                    if ((SwitchParameter)MyInvocation.BoundParameters[nameof(Build)])
                    {
                        WriteVerbose("Flag should be added");
                        WriteVerbose("Test is flag exists");
                        if (!(Task.Visibility.Contains(Visibility.Build)))
                        {
                            WriteVerbose("Add Flag");
                            Task.Visibility.Add(Visibility.Build);
                        }
                    }
                    else
                    {
                        WriteVerbose("Flag should be removed");
                        WriteVerbose("Test is flag exists");
                        if (Task.Visibility.Contains(Visibility.Build))
                        {
                            WriteVerbose("Remove Flag");
                            Task.Visibility.Remove(Visibility.Build);
                        }
                    }
                }
                if (MyInvocation.BoundParameters.ContainsKey(nameof(Release)))
                {
                    if ((SwitchParameter)MyInvocation.BoundParameters[nameof(Release)])
                    {
                        WriteVerbose("Flag should be added");
                        WriteVerbose("Test is flag exists");
                        if (!(Task.Visibility.Contains(Visibility.Release)))
                        {
                            WriteVerbose("Add Flag");
                            Task.Visibility.Add(Visibility.Release);
                        }
                    }
                    else
                    {
                        WriteVerbose("Flag should be removed");
                        WriteVerbose("Test is flag exists");
                        if (Task.Visibility.Contains(Visibility.Release))
                        {
                            WriteVerbose("Remove Flag");
                            Task.Visibility.Remove(Visibility.Release);
                        }
                    }
                }
            }
        }
        protected override void EndProcessing()
        {
            WriteVerbose("SetGalleryFlag : End Process");
            WriteObject(Task);
        }
    }
}