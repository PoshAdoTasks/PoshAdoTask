namespace PoshAdoTask.Manifest.Cmdlets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Management.Automation;
    using PoshAdoTask.Manifest.Types;

    [Cmdlet(VerbsCommon.Add, "Contribution", HelpUri = "")]
    [OutputType(typeof(PoshAdoTask.Manifest.Types.Link))]
    [CmdletBinding(PositionalBinding = true)]
    public class AddContribution : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public Manifest? Manifest { get; set; }
        [Parameter(Mandatory = true, Position = 1)]
        public string? Id { get; set; }
        [Parameter(Mandatory = false, Position = 2)]
        public string? Type { get; set; } = "ms.vss-distributed-task.task";
        protected override void BeginProcessing()
        {
            WriteVerbose("AddContribution : Begin Processing");
            WriteVerbose("Id              : " + Id);
            WriteVerbose("Type            : " + Type);
        }
        protected override void ProcessRecord()
        {
            WriteVerbose("AddContribution : Process Record");
            if (Manifest != null)
            {
                Contribution newContribution = new();
                if (!(string.IsNullOrEmpty(Id)) && !(string.IsNullOrEmpty(Type)))
                {
                    newContribution = new(Id, Type);
                    newContribution.Properties.Add("name", Id);
                }
                if (Manifest.Contributions == null)
                {
                    Manifest.Contributions = new List<Contribution>();
                }
                Manifest.Contributions.Add(newContribution);
            }
        }
        protected override void EndProcessing()
        {
            WriteVerbose("AddContribution : End Processing");
            WriteObject(Manifest);
        }
    }
}