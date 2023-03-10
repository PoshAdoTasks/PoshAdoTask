namespace PoshAdoTask.Manifest.Cmdlets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Management.Automation;
    using PoshAdoTask.Task.Types;

    [Cmdlet(VerbsCommon.New, "Task", HelpUri = "https://github.com/PoshAdoTasks/PoshAdoTask/blob/main/Docs/New-Task.md")]
    [OutputType(typeof(PoshAdoTask.Task.Types.Task))]
    [CmdletBinding(PositionalBinding = true)]
    public class NewTask : PSCmdlet
    {
        [Parameter(Mandatory = false, Position = 0)]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Parameter(Mandatory = true, Position = 1)]
        public string Name { get; set; } = string.Empty;
        [Parameter(Mandatory = true, Position = 2)]
        public string FriendlyName { get; set; } = string.Empty;
        [Parameter(Mandatory = false, Position = 3)]
        public string Description { get; set; } = string.Empty;
        [Parameter(Mandatory = true, Position = 4)]
        public string Author { get; set; } = string.Empty;
        [Parameter(Mandatory = false, Position = 5)]
        public string? Version { get; set; } = string.Empty;
        protected override void BeginProcessing()
        {
            WriteVerbose("NewTask      : Begin Processing");
            WriteVerbose("Id           : " + Id);
            WriteVerbose("Name         : " + Name);
            WriteVerbose("FriendlyName : " + FriendlyName);
            WriteVerbose("Description  : " + Description);
            WriteVerbose("Author       : " + Author);
            WriteVerbose("Version      : " + Version);

            Task newTask = new(Id, Name, FriendlyName, Author)
            {
                Description = Description,
            };
            if (!(string.IsNullOrEmpty(Version)))
            {
                newTask.Version = new PoshAdoTask.Task.Types.Version(new System.Version(Version));
            }
            WriteObject(newTask);
        }
    }
}