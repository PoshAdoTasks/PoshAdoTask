namespace PoshAdoTask.Manifest.Cmdlets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Management.Automation;
    using PoshAdoTask.Manifest.Types;

    [Cmdlet(VerbsCommon.New, "Icon", HelpUri = "https://github.com/PoshAdoTasks/PoshAdoTask/blob/main/Docs/New-Icon.md")]
    [OutputType(typeof(PoshAdoTask.Manifest.Types.Icon))]
    [CmdletBinding(PositionalBinding = true)]
    public class NewIcon : PSCmdlet
    {
        [Parameter(Mandatory = true, Position = 0)]
        public string Path { get; set; } = string.Empty;
        protected override void BeginProcessing()
        {
            WriteVerbose("NewIcon : Begin Processing");
            WriteVerbose("Path          : " + Path);

            Icon newIcon = new(Path);

            WriteObject(newIcon);
        }
    }
}