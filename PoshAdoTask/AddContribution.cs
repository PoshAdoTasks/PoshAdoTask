namespace PoshAdoTask.Cmdlets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Management.Automation;
    using PoshAdoTask.Types;

    [Cmdlet(VerbsCommon.Add, "Contribution", HelpUri = "")]
    [OutputType(typeof(PoshAdoTask.Types.Link))]
    [CmdletBinding(PositionalBinding = true)]
    public class AddContribution : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public Manifest? Manifest { get; set; }
        [Parameter(Mandatory = true, Position = 1)]
        public string? Id { get; set; }
        [Parameter(Mandatory = false, Position = 2)]
        public bool? Type { get; set; }
        [Parameter(Mandatory = false, Position = 3)]
        public string? PackagePath { get; set; }
        protected override void BeginProcessing()
        {
            WriteVerbose("AddContribution     : Begin Processing");
            WriteVerbose("Id        : " + Id);
            WriteVerbose("Type : " + Type);
            WriteVerbose("PackagePath : " + PackagePath);
        }
        protected override void ProcessRecord()
        {
            WriteVerbose("AddFile     : Process Record");
            if (Manifest != null && !(string.IsNullOrEmpty(Path)))
            {
                Manifest.AddFile(new File
                {
                    Path = Path,
                    Addressable = Addressable,
                    PackagePath = PackagePath
                });
            }
        }
        protected override void EndProcessing()
        {
            WriteVerbose("AddFile     : End Processing");
            WriteObject(Manifest);
        }
    }
}