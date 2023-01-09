namespace PoshAdoTask.Manifest.Cmdlets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Management.Automation;
    using PoshAdoTask.Manifest.Types;
    using System.Configuration;
    using System.Management;

    [Cmdlet(VerbsCommon.Set, "GalleryFlag", HelpUri = "https://github.com/PoshAdoTasks/PoshAdoTask/blob/main/Docs/Set-GalleryFlag.md")]
    [OutputType(typeof(PoshAdoTask.Manifest.Types.Manifest))]
    [CmdletBinding(PositionalBinding = true)]
    public class SetGalleryFlag : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public Manifest? Manifest { get; set; }
        [Parameter(Mandatory = false, Position = 1)]
        public SwitchParameter Paid { get; set; }
        [Parameter(Mandatory = false, Position = 2)]
        public SwitchParameter Preview { get; set; }
        [Parameter(Mandatory = false, Position = 3)]
        public SwitchParameter Public { get; set; }
        protected override void BeginProcessing()
        {
            WriteVerbose("SetGalleryFlag : Begin Processing");
            WriteVerbose("Paid           : " + Paid);
            WriteVerbose("Preview        : " + Preview);
            WriteVerbose("Public         : " + Public);
        }
        protected override void ProcessRecord()
        {
            if (Manifest != null)
            {
                int Capacity = (Manifest.GalleryFlags ??= new List<GalleryFlag>()).Capacity;
            }
            WriteVerbose("SetGalleryFlag : Process Record");
            if (Manifest != null && Manifest.GalleryFlags != null)
            {
                if (MyInvocation.BoundParameters.ContainsKey(nameof(Paid)))
                {
                    if ((SwitchParameter)MyInvocation.BoundParameters[nameof(Paid)])
                    {
                        WriteVerbose("Flag should be added");
                        WriteVerbose("Test is flag exists");
                        if (!(Manifest.GalleryFlags.Contains(GalleryFlag.Paid)))
                        {
                            WriteVerbose("Add Flag");
                            Manifest.GalleryFlags.Add(GalleryFlag.Paid);
                        }
                    }
                    else
                    {
                        WriteVerbose("Flag should be removed");
                        WriteVerbose("Test is flag exists");
                        if (Manifest.GalleryFlags.Contains(GalleryFlag.Paid))
                        {
                            WriteVerbose("Remove Flag");
                            Manifest.GalleryFlags.Remove(GalleryFlag.Paid);
                        }
                    }
                }
                if (MyInvocation.BoundParameters.ContainsKey(nameof(Preview)))
                {
                    if ((SwitchParameter)MyInvocation.BoundParameters[nameof(Preview)])
                    {
                        WriteVerbose("Flag should be added");
                        WriteVerbose("Test is flag exists");
                        if (!(Manifest.GalleryFlags.Contains(GalleryFlag.Preview)))
                        {
                            WriteVerbose("Add Flag");
                            Manifest.GalleryFlags.Add(GalleryFlag.Preview);
                        }
                    }
                    else
                    {
                        WriteVerbose("Flag should be removed");
                        WriteVerbose("Test is flag exists");
                        if (Manifest.GalleryFlags.Contains(GalleryFlag.Preview))
                        {
                            WriteVerbose("Remove Flag");
                            Manifest.GalleryFlags.Remove(GalleryFlag.Preview);
                        }
                    }
                }
                if (MyInvocation.BoundParameters.ContainsKey(nameof(Public)))
                {
                    if ((SwitchParameter)MyInvocation.BoundParameters[nameof(Public)])
                    {
                        WriteVerbose("Flag should be added");
                        WriteVerbose("Test is flag exists");
                        if (!(Manifest.GalleryFlags.Contains(GalleryFlag.Public)))
                        {
                            WriteVerbose("Add Flag");
                            Manifest.GalleryFlags.Add(GalleryFlag.Public);
                        }
                    }
                    else
                    {
                        WriteVerbose("Flag should be removed");
                        WriteVerbose("Test is flag exists");
                        if (Manifest.GalleryFlags.Contains(GalleryFlag.Public))
                        {
                            WriteVerbose("Remove Flag");
                            Manifest.GalleryFlags.Remove(GalleryFlag.Public);
                        }
                    }
                }
            }
        }
        protected override void EndProcessing()
        {
            WriteVerbose("SetGalleryFlag : End Process");
            WriteObject(Manifest);
        }
    }
}