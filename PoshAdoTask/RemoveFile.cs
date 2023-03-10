namespace PoshAdoTask.Manifest.Cmdlets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Management.Automation;
    using PoshAdoTask.Manifest.Types;

    [Cmdlet(VerbsCommon.Remove, "File", HelpUri = "https://github.com/PoshAdoTasks/PoshAdoTask/blob/main/Docs/Remove-File.md")]
    [OutputType(typeof(PoshAdoTask.Manifest.Types.Manifest))]
    [CmdletBinding(PositionalBinding = true)]
    public class RemoveFile : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public Manifest? Manifest { get; set; }
        [Parameter(Mandatory = true, Position = 1)]
        public string? Path { get; set; }
        protected override void BeginProcessing()
        {
            WriteVerbose("RemoveFile : Begin Processing");
            WriteVerbose("Path       : " + Path);
        }
        protected override void ProcessRecord()
        {
            WriteVerbose("RemoveFile : Process Record");
            if (Manifest != null)
            {
                File? delFile = Manifest.Files.Find(f => f.Path == Path);
                if (delFile != null)
                {
                    Manifest.Files.Remove(delFile);
                }
            }
        }
        protected override void EndProcessing()
        {
            WriteVerbose("RemoveFile : End Processing");
            WriteObject(Manifest);
        }
    }
}