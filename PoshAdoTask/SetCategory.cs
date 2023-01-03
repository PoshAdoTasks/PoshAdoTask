namespace PoshAdoTask.Manifest.Cmdlets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Management.Automation;
    using PoshAdoTask.Manifest.Types;
    using System.Configuration;

    [Cmdlet(VerbsCommon.Set, "Category", HelpUri = "")]
    [OutputType(typeof(PoshAdoTask.Manifest.Types.Link))]
    [CmdletBinding(PositionalBinding = true)]
    public class SetCategory : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public Manifest? Manifest { get; set; }
        [Parameter(Mandatory = false, Position = 1)]
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
                if (MyInvocation.BoundParameters.ContainsKey(nameof(AzureArtifacts)))
                {
                    if ((SwitchParameter)MyInvocation.BoundParameters[nameof(AzureArtifacts)])
                    {
                        WriteVerbose("Flag should be added");
                        WriteVerbose("Test is flag exists");
                        if (!(Manifest.Categories.Contains(ManifestCategory.AzureArtifacts)))
                        {
                            WriteVerbose("Add Flag");
                            Manifest.Categories.Add(ManifestCategory.AzureArtifacts);
                        }
                    } else
                    {
                        WriteVerbose("Flag should be removed");
                        WriteVerbose("Test is flag exists");
                        if (Manifest.Categories.Contains(ManifestCategory.AzureArtifacts))
                        {
                            WriteVerbose("Remove Flag");
                            Manifest.Categories.Remove(ManifestCategory.AzureArtifacts);
                        }
                    }
                }
                if (MyInvocation.BoundParameters.ContainsKey(nameof(AzureBoards)))
                {
                    if ((SwitchParameter)MyInvocation.BoundParameters[nameof(AzureBoards)])
                    {
                        WriteVerbose("Flag should be added");
                        WriteVerbose("Test is flag exists");
                        if (!(Manifest.Categories.Contains(ManifestCategory.AzureBoards)))
                        {
                            WriteVerbose("Add Flag");
                            Manifest.Categories.Add(ManifestCategory.AzureBoards);
                        }
                    }
                    else
                    {
                        WriteVerbose("Flag should be removed");
                        WriteVerbose("Test is flag exists");
                        if (Manifest.Categories.Contains(ManifestCategory.AzureBoards))
                        {
                            WriteVerbose("Remove Flag");
                            Manifest.Categories.Remove(ManifestCategory.AzureBoards);
                        }
                    }
                }
                if (MyInvocation.BoundParameters.ContainsKey(nameof(AzurePipelines)))
                {
                    if ((SwitchParameter)MyInvocation.BoundParameters[nameof(AzurePipelines)])
                    {
                        WriteVerbose("Flag should be added");
                        WriteVerbose("Test is flag exists");
                        if (!(Manifest.Categories.Contains(ManifestCategory.AzurePipelines)))
                        {
                            WriteVerbose("Add Flag");
                            Manifest.Categories.Add(ManifestCategory.AzurePipelines);
                        }
                    }
                    else
                    {
                        WriteVerbose("Flag should be removed");
                        WriteVerbose("Test is flag exists");
                        if (Manifest.Categories.Contains(ManifestCategory.AzurePipelines))
                        {
                            WriteVerbose("Remove Flag");
                            Manifest.Categories.Remove(ManifestCategory.AzurePipelines);
                        }
                    }
                }
                if (MyInvocation.BoundParameters.ContainsKey(nameof(AzureRepos)))
                {
                    if ((SwitchParameter)MyInvocation.BoundParameters[nameof(AzureRepos)])
                    {
                        WriteVerbose("Flag should be added");
                        WriteVerbose("Test is flag exists");
                        if (!(Manifest.Categories.Contains(ManifestCategory.AzureRepos)))
                        {
                            WriteVerbose("Add Flag");
                            Manifest.Categories.Add(ManifestCategory.AzureRepos);
                        }
                    }
                    else
                    {
                        WriteVerbose("Flag should be removed");
                        WriteVerbose("Test is flag exists");
                        if (Manifest.Categories.Contains(ManifestCategory.AzureRepos))
                        {
                            WriteVerbose("Remove Flag");
                            Manifest.Categories.Remove(ManifestCategory.AzureRepos);
                        }
                    }
                }
                if (MyInvocation.BoundParameters.ContainsKey(nameof(AzureTestPlans)))
                {
                    if ((SwitchParameter)MyInvocation.BoundParameters[nameof(AzureTestPlans)])
                    {
                        WriteVerbose("Flag should be added");
                        WriteVerbose("Test is flag exists");
                        if (!(Manifest.Categories.Contains(ManifestCategory.AzureTestPlans)))
                        {
                            WriteVerbose("Add Flag");
                            Manifest.Categories.Add(ManifestCategory.AzureTestPlans);
                        }
                    }
                    else
                    {
                        WriteVerbose("Flag should be removed");
                        WriteVerbose("Test is flag exists");
                        if (Manifest.Categories.Contains(ManifestCategory.AzureTestPlans))
                        {
                            WriteVerbose("Remove Flag");
                            Manifest.Categories.Remove(ManifestCategory.AzureTestPlans);
                        }
                    }
                }
            }
        }
        protected override void EndProcessing()
        {
            WriteVerbose("SetCategory    : End Process");
            WriteObject(Manifest);
        }
    }
}