namespace PoshAdoTask.Cmdlets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Management.Automation;
    using PoshAdoTask.Types;

    [Cmdlet(VerbsCommon.New, "Manifest", HelpUri = "")]
    [OutputType(typeof(PoshAdoTask.Types.Manifest))]
    [CmdletBinding(PositionalBinding = true)]
    public class NewManifest : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0)]
        public string Id { get; set; } = string.Empty;
        [Parameter(Mandatory = true, Position = 1)]
        public string Version { get; set; } = string.Empty;
        [Parameter(Mandatory = true, Position = 2)]
        public string Name { get; set; } = string.Empty;
        [Parameter(Mandatory = true, Position = 3)]
        public string Publisher { get; set; } = string.Empty;
        [Parameter(Mandatory = true, Position = 4)]
        public string Description { get; set; } = string.Empty;
        [Parameter(Mandatory = false, Position = 5)]
        public long ManifestVersion { get; set; } = 1;
        protected override void BeginProcessing()
        {
            WriteVerbose("NewManifest     : Begin Processing");
            WriteVerbose("Id              : " + Id);
            WriteVerbose("Version         : " + Version);
            WriteVerbose("Name            : " + Name);
            WriteVerbose("Publisher       : " + Publisher);
            WriteVerbose("Description     : " + Description);
            WriteVerbose("ManifestVersion : " + ManifestVersion);

            Manifest newManifest = new(ManifestVersion, Id, Version, Name, Publisher)
            {
                Description = Description
            };

            WriteObject(newManifest);
        }
    }
}