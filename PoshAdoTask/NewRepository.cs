namespace PoshAdoTask.Manifest.Cmdlets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Management.Automation;
    using PoshAdoTask.Manifest.Types;

    [Cmdlet(VerbsCommon.New, "Repository", HelpUri = "https://github.com/PoshAdoTasks/PoshAdoTask/blob/main/Docs/New-Repository.md")]
    [OutputType(typeof(PoshAdoTask.Manifest.Types.Repository))]
    [CmdletBinding(PositionalBinding = true)]
    public class NewRepository : PSCmdlet
    {
        [Parameter(Mandatory = false, Position = 0)]
        [ValidateSet("Cvs","Git","Mercurial","Svn")]
        public string Type { get; set; } = string.Empty;
        [Parameter(Mandatory = false, Position = 1)]
        public string Url { get; set; } = string.Empty;
        protected override void BeginProcessing()
        {
            WriteVerbose("NewRepository : Begin Processing");
            WriteVerbose("Type          : " + Type);
            WriteVerbose("Url           : " + Url);

            Repository newRepository = new();
            switch (Type.ToLower())
            {
                case "cvs":
                    if (!(string.IsNullOrEmpty(Type))) { newRepository.Type = "cvs"; }

                    break;
                case "git":
                    if (!(string.IsNullOrEmpty(Type))) { newRepository.Type = "git"; }

                    break;
                case "mercurial":
                    if (!(string.IsNullOrEmpty(Type))) { newRepository.Type = "mercurial"; }

                    break;
                case "svn":
                    if (!(string.IsNullOrEmpty(Type))) { newRepository.Type = "svn"; }

                    break;
            }
            if (!(string.IsNullOrEmpty(Url))) { newRepository.Uri = new Uri(Url); }

            WriteObject(newRepository);
        }
    }
}