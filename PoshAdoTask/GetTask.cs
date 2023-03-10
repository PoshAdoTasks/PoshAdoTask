namespace PoshAdoTask.Manifest.Cmdlets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.Json;
    using System.Management.Automation;
    using PoshAdoTask.Task.Types;
    using System.Text.Json.Serialization;

    [Cmdlet(VerbsCommon.Get, "Task", HelpUri = "https://github.com/PoshAdoTasks/PoshAdoTask/blob/main/Docs/Get-Task.md")]
    [OutputType(typeof(PoshAdoTask.Task.Types.Task))]
    [CmdletBinding(PositionalBinding = true)]
    public class GetTask : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0)]
        public string? Path { get; set; }
        protected override void BeginProcessing()
        {
            WriteVerbose("GetTask     : Begin Processing");
            WriteVerbose("Path        : " + Path);

            Task newTask = new();
            if (!(string.IsNullOrEmpty(Path)))
            {
                string json = System.IO.File.ReadAllText(Path);
                JsonSerializerOptions options = new JsonSerializerOptions();

                options.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                options.Converters.Add(new JsonStringEnumConverter());
                options.PropertyNameCaseInsensitive = true;

                newTask = JsonSerializer.Deserialize<Task>(json, options)!;
            }

            WriteObject(newTask);
        }
    }
}