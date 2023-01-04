﻿namespace PoshAdoTask.Manifest.Cmdlets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Management.Automation;
    using PoshAdoTask.Manifest.Types;
    using System.Configuration;

    [Cmdlet(VerbsData.Out, "Manifest", HelpUri = "")]
    [OutputType(typeof(System.Text.Json.JsonDocument))]
    [CmdletBinding(PositionalBinding = true)]
    public class OutManifest : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0, ValueFromPipeline = true)]
        public Manifest? Manifest { get; set; }
        protected override void BeginProcessing()
        {
            WriteVerbose("AddInput     : Begin Processing");
        }
        protected override void ProcessRecord()
        {
            WriteVerbose("AddInput : Process Record");
        }
        protected override void EndProcessing()
        {
            WriteVerbose("AddInput : End Process");
            if (Manifest != null)
            {
                WriteObject(Manifest.ToString());
            }
        }
    }
}