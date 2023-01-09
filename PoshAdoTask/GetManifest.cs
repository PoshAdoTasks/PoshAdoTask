namespace PoshAdoTask.Manifest.Cmdlets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.Json;
    using System.Management.Automation;
    using PoshAdoTask.Manifest.Types;
    using System.Text.Json.Serialization;

    [Cmdlet(VerbsCommon.Get, "Manifest", HelpUri = "")]
    [OutputType(typeof(PoshAdoTask.Manifest.Types.Manifest))]
    [CmdletBinding(PositionalBinding = true)]
    public class GetManifest : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0)]
        public string? Path { get; set; }
        protected override void BeginProcessing()
        {
            WriteVerbose("GetManifest : Begin Processing");
            WriteVerbose("Path        : " + Path);

            Manifest newManifest = new();
            if (!(string.IsNullOrEmpty(Path)))
            {
                string json = System.IO.File.ReadAllText(Path);
                JsonSerializerOptions options = new JsonSerializerOptions();

                options.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                options.Converters.Add(new JsonStringEnumConverter());
                options.PropertyNameCaseInsensitive = true;

                newManifest = JsonSerializer.Deserialize<Manifest>(json, options)!;
            }

            WriteObject(newManifest);
        }
    }
}