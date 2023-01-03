namespace PoshAdoTask.Cmdlets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Management.Automation;
    using PoshAdoTask.Types;

    [Cmdlet(VerbsCommon.Set, "Category", HelpUri = "")]
    [OutputType(typeof(PoshAdoTask.Types.Link))]
    [CmdletBinding(PositionalBinding = true)]
    public class SetCategory : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public Manifest? Manifest { get; set; }
        [Parameter(Mandatory = true, Position = 1)]
        public SwitchParameter AzureArtifacts { get; set; }
        [Parameter(Mandatory = false, Position = 2)]
        public SwitchParameter AzureBoards { get; set; }
        [Parameter(Mandatory = false, Position = 3)]
        public SwitchParameter AzurePipelines { get; set; }
        [Parameter(Mandatory = false, Position = 2)]
        public SwitchParameter AzureRepos { get; set; }
        [Parameter(Mandatory = false, Position = 3)]
        public SwitchParameter AzureTestPlans { get; set; }
        protected override void BeginProcessing()
        {
            // AzureArtifacts, AzureBoards, AzurePipelines, AzureRepos, AzureTestPlans
            WriteVerbose("SetCategory    : Begin Processing");
            WriteVerbose("AzureArtifacts : " + AzureArtifacts);
            WriteVerbose("AzureBoards    : " + AzureBoards);
            WriteVerbose("AzurePipelines : " + AzurePipelines);
            WriteVerbose("AzureRepos     : " + AzureRepos);
            WriteVerbose("AzureTestPlans : " + AzureTestPlans);
        }
        protected override void ProcessRecord()
        {
            WriteVerbose("SetCategory    : Process Record");
            if (Manifest != null)
            {
                if (AzureArtifacts) { Manifest.Categories.Add(ManifestCategory.AzureArtifacts); }
                if (AzureBoards) { Manifest.Categories.Add(ManifestCategory.AzureBoards); }
                if (AzurePipelines) { Manifest.Categories.Add(ManifestCategory.AzurePipelines); }
                if (AzureRepos) { Manifest.Categories.Add(ManifestCategory.AzureRepos); }
                if (AzureTestPlans) { Manifest.Categories.Add(ManifestCategory.AzureTestPlans); }
            }
        }
        protected override void EndProcessing()
        {
            WriteVerbose("SetCategory    : End Process");
            WriteObject(Manifest);
        }
    }
}