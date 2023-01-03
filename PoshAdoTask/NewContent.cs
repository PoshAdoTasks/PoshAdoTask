namespace PoshAdoTask.Manifest.Cmdlets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Management.Automation;
    using PoshAdoTask.Manifest.Types;

    [Cmdlet(VerbsCommon.New, "Content", HelpUri = "")]
    [OutputType(typeof(PoshAdoTask.Manifest.Types.Content))]
    [CmdletBinding(PositionalBinding = true)]
    public class NewContent : PSCmdlet
    {
        [Parameter(Mandatory = false, Position = 0)]
        public string Details { get; set; } = string.Empty;
        [Parameter(Mandatory = false, Position = 1)]
        public string License { get; set; } = string.Empty;
        [Parameter(Mandatory = false, Position = 2)]
        public string Pricing { get; set; } = string.Empty;
        protected override void BeginProcessing()
        {
            WriteVerbose("NewContent : Begin Processing");
            WriteVerbose("Details    : " + Details);
            WriteVerbose("License    : " + License);
            WriteVerbose("Pricing    : " + Pricing);

            Content newContent = new();
            if (!(string.IsNullOrEmpty(Details))) { newContent.Details = new ContentDefinition(Details); }
            if (!(string.IsNullOrEmpty(License))) { newContent.License = new ContentDefinition(License); }
            if (!(string.IsNullOrEmpty(Pricing))) { newContent.Pricing = new ContentDefinition(Pricing); }
            
            WriteObject(newContent);
        }
    }
}