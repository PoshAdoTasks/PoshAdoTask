namespace PoshAdoTask.Manifest.Cmdlets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Management.Automation;
    using PoshAdoTask.Manifest.Types;

    [Cmdlet(VerbsCommon.Remove, "Contribution", HelpUri = "")]
    [OutputType(typeof(PoshAdoTask.Manifest.Types.Link))]
    [CmdletBinding(PositionalBinding = true)]
    public class RemoveContribution : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public Manifest? Manifest { get; set; }
        [Parameter(Mandatory = true, Position = 1)]
        public string? Id { get; set; }
        protected override void BeginProcessing()
        {
            WriteVerbose("RemoveContribution : Begin Processing");
            WriteVerbose("Id                 : " + Id);
        }
        protected override void ProcessRecord()
        {
            WriteVerbose("RemoveContribution : Process Record");
            if (Manifest != null && Manifest.Contributions != null)
            {
                Contribution? delContribution = Manifest.Contributions.Find(c => c.Id == Id);
                if (delContribution != null)
                {
                    Manifest.Contributions.Remove(delContribution);
                }
            }
        }
        protected override void EndProcessing()
        {
            WriteVerbose("RemoveContribution : End Processing");
            WriteObject(Manifest);
        }
    }
}