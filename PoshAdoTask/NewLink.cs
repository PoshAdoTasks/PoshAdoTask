namespace PoshAdoTask.Cmdlets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Management.Automation;
    using PoshAdoTask.Types;

    [Cmdlet(VerbsCommon.New, "Link", HelpUri = "")]
    [OutputType(typeof(PoshAdoTask.Types.Link))]
    [CmdletBinding(PositionalBinding = true)]
    public class NewLink : PSCmdlet
    {
        [Parameter(Mandatory = false, Position = 0)]
        public string GetStarted { get; set; } = string.Empty;
        [Parameter(Mandatory = false, Position = 1)]
        public string Learn { get; set; } = string.Empty;
        [Parameter(Mandatory = false, Position = 2)]
        public string License { get; set; } = string.Empty;
        [Parameter(Mandatory = false, Position = 3)]
        public string PrivacyPolicy { get; set; } = string.Empty;
        [Parameter(Mandatory = false, Position = 4)]
        public string Support { get; set; } = string.Empty;
        protected override void BeginProcessing()
        {
            WriteVerbose("NewLink       : Begin Processing");
            WriteVerbose("GetStarted    : " + GetStarted);
            WriteVerbose("Learn         : " + Learn);
            WriteVerbose("License       : " + License);
            WriteVerbose("PrivacyPolicy : " + PrivacyPolicy);
            WriteVerbose("Support       : " + Support);
            
            Link newLink = new();
            if (!(string.IsNullOrEmpty(GetStarted))) { newLink.Getstarted = new LinkDefinition(GetStarted); }
            if (!(string.IsNullOrEmpty(Learn))) { newLink.Learn = new LinkDefinition(Learn); }
            if (!(string.IsNullOrEmpty(License))) { newLink.License = new LinkDefinition(License); }
            if (!(string.IsNullOrEmpty(PrivacyPolicy))) { newLink.PrivacyPolicy = new LinkDefinition(PrivacyPolicy); }
            if (!(string.IsNullOrEmpty(Support))) { newLink.Support = new LinkDefinition(Support); }
            WriteObject(newLink);
        }
    }
}