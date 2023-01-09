namespace PoshAdoTask.Manifest.Cmdlets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Management.Automation;
    using PoshAdoTask.Manifest.Types;

    [Cmdlet(VerbsCommon.Add, "File", HelpUri = "")]
    [OutputType(typeof(PoshAdoTask.Manifest.Types.Manifest))]
    [CmdletBinding(PositionalBinding = true)]
    public class AddFile : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public Manifest? Manifest { get; set; }
        [Parameter(Mandatory = true, Position = 1)]
        public string? Path { get; set; }
        [Parameter(Mandatory = false, Position = 2)]
        public bool? Addressable { get; set; }
        [Parameter(Mandatory = false, Position = 3)]
        public string? PackagePath { get; set; }
        protected override void BeginProcessing()
        {
            WriteVerbose("AddFile     : Begin Processing");
            WriteVerbose("Path        : " + Path);
            WriteVerbose("Addressable : " + Addressable);
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