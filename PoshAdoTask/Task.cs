namespace PoshAdoTask.Task.Types
{
    using System.Collections.Generic;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    public partial class Task
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("friendlyName")]
        public string FriendlyName { get; set; } = string.Empty;
        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;
        [JsonPropertyName("helpUrl")]
        public string HelpUrl { get; set; } = string.Empty;
        [JsonPropertyName("helpMarkDown")]
        public string HelpMarkDown { get; set; } = string.Empty;
        [JsonPropertyName("author")]
        public string Author { get; set; } = string.Empty;
        [JsonPropertyName("preview")]
        public bool? Preview { get; set; }
        [JsonPropertyName("deprecated")]
        public bool? Deprecated { get; set; }
        [JsonPropertyName("showEnvironmentVariables")]
        public bool? ShowEnvironmentVariables { get; set; }
        [JsonPropertyName("runsOn")]
        public List<RunsOn>? RunsOn { get; set; }
        [JsonPropertyName("visibility")]
        public List<Visibility> Visibility { get; set; } = new List<Visibility>();
        [JsonPropertyName("category")]
        public TaskCategory? Category { get; set; }
        [JsonPropertyName("groups")]
        public List<Group>? Groups { get; set; }
        [JsonPropertyName("demands")]
        public List<string>? Demands { get; set; }
        [JsonPropertyName("minimumAgentVersion")]
        public string MinimumAgentVersion { get; set; } = string.Empty;
        [JsonPropertyName("vresion")]
        public Version Version { get; set; } = new Version();
        [JsonPropertyName("instanceNameFormat")]
        public string InstanceNameFormat { get; set; } = string.Empty;
        [JsonPropertyName("releaseNotes")]
        public string ReleaseNotes { get; set; } = string.Empty;
        [JsonPropertyName("inputs")]
        public List<Input> Inputs { get; set; } = new List<Input>();
        [JsonPropertyName("dataSourceBindings")]
        public List<DataSourceBinding>? DataSourceBindings { get; set; }
        [JsonPropertyName("sourceDefinitions")]
        public List<SourceDefinition>? SourceDefinitions { get; set; }
        [JsonPropertyName("prejobexecution")]
        public Prejobexecution? Prejobexecution { get; set; }
        [JsonPropertyName("execution")]
        public Execution Execution { get; set; } = new Execution();
        [JsonPropertyName("postjobexecution")]
        public Postjobexecution? Postjobexecution { get; set; }
        [JsonPropertyName("messages")]
        public Dictionary<string, object>? Messages { get; set; }
        [JsonPropertyName("outputVariables")]
        public List<OutputVariable>? OutputVariables { get; set; }
        [JsonPropertyName("restrictions")]
        public Restrictions? Restrictions { get; set; }
        [JsonPropertyName("$schema")]
        public string? Schema { get; set; }
        public override string ToString()
        {
            JsonSerializerOptions options = new();
            options.Converters.Add(new JsonStringEnumConverter());
            options.WriteIndented = true;
            options.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;

            return JsonSerializer.Serialize<Task>(this, options);
        }
    }

    public partial class DataSourceBinding
    {
        [JsonPropertyName("target")]
        public string Target { get; set; } = string.Empty;
        [JsonPropertyName("endpointId")]
        public string EndpointId { get; set; } = string.Empty;
        [JsonPropertyName("dataSourceName")]
        public string DataSourceName { get; set; } = string.Empty;
        [JsonPropertyName("parameters")]
        public Dictionary<string, object> Parameters { get; set; } = new Dictionary<string, object>();
        [JsonPropertyName("resultTemplate")]
        public string ResultTemplate { get; set; } = string.Empty;
        [JsonPropertyName("endpointUrl")]
        public string EndpointUrl { get; set; } = string.Empty;
        [JsonPropertyName("resultSelector")]
        public string ResultSelector { get; set; } = string.Empty;
        [JsonPropertyName("RequestVerb")]
        public RequestVerb? RequestVerb { get; set; }
        [JsonPropertyName("requestContent")]
        public string RequestContent { get; set; } = string.Empty;
        [JsonPropertyName("callbackContextTemplate")]
        public string CallbackContextTemplate { get; set; } = string.Empty;
        [JsonPropertyName("callbackRequiredTemplate")]
        public string CallbackRequiredTemplate { get; set; } = string.Empty;
        [JsonPropertyName("initialContextTemplate")]
        public string InitialContextTemplate { get; set; } = string.Empty;
    }

    public partial class Execution
    {
        [JsonPropertyName("Node16")]
        public ExecutionObject? Node16 { get; set; }
        [JsonPropertyName("Node10")]
        public ExecutionObject? Node10 { get; set; }
        [JsonPropertyName("Node")]
        public ExecutionObject? Node { get; set; }
        [JsonPropertyName("PowerShell3")]
        public ExecutionObject PowerShell3 { get; set; } = new ExecutionObject();
        [JsonPropertyName("PowerShell")]
        public ExecutionObject? PowerShell { get; set; }
    }

    public partial class ExecutionObject
    {
        [JsonPropertyName("target")]
        public string Target { get; set; } = string.Empty;
        [JsonPropertyName("platforms")]
        public List<Platform>? Platforms { get; set; }
        [JsonPropertyName("argumentFormat")]
        public string? ArgumentFormat { get; set; }
        [JsonPropertyName("workingDirectory")]
        public string? WorkingDirectory { get; set; }
    }

    public partial class Group
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("displayName")]
        public string DisplayName { get; set; } = string.Empty;
        [JsonPropertyName("isExpanded")]
        public bool? IsExpanded { get; set; }
        [JsonPropertyName("visibleRule")]
        public string VisibleRule { get; set; } = string.Empty;
    }

    public partial class Input
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("aliases")]
        public List<string> Aliases { get; set; } = new List<string>();
        [JsonPropertyName("label")]
        public string Label { get; set; } = string.Empty;
        [JsonPropertyName("type")]
        public TaskType Type { get; set; }
        [JsonPropertyName("defaultValue")]
        public DefaultValue? DefaultValue { get; set; }
        [JsonPropertyName("required")]
        public bool? Required { get; set; }
        [JsonPropertyName("helpMarkDown")]
        public string HelpMarkDown { get; set; } = string.Empty;
        [JsonPropertyName("groupName")]
        public string GroupName { get; set; } = string.Empty;
        [JsonPropertyName("visibleRule")]
        public string VisibleRule { get; set; } = string.Empty;
        [JsonPropertyName("properties")]
        public Property Properties { get; set; } = new Property();
        [JsonPropertyName("options")]
        public Dictionary<string, object> Options { get; set; } = new Dictionary<string, object>();
    }

    public partial class Property
    {
        [JsonPropertyName("EditableOptions")]
        public StringBoolean? EditableOptions { get; set; }
        [JsonPropertyName("MultiSelect")]
        public StringBoolean? MultiSelect { get; set; }
        [JsonPropertyName("MultiSelectFlatList")]
        public StringBoolean? MultiSelectFlatList { get; set; }
        [JsonPropertyName("DisableManageLink")]
        public StringBoolean? DisableManageLink { get; set; }
        [JsonPropertyName("IsSearchable")]
        public StringBoolean? IsSearchable { get; set; }
        [JsonPropertyName("PopulateDefaultValue")]
        public StringBoolean? PopulateDefaultValue { get; set; }
        [JsonPropertyName("isVariableOrNonNegativeNumber")]
        public StringBoolean? IsVariableOrNonNegativeNumber { get; set; }
        [JsonPropertyName("resizable")]
        public bool? Resizable { get; set; }
        [JsonPropertyName("rows")]
        public string Rows { get; set; } = string.Empty;
        [JsonPropertyName("maxLength")]
        public string MaxLength { get; set; } = string.Empty;
        [JsonPropertyName("editorExtension")]
        public string EditorExtension { get; set; } = string.Empty;
        [JsonPropertyName("EndpointFilterRule")]
        public string EndpointFilterRule { get; set; } = string.Empty;
    }

    public partial class OutputVariable
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;
    }

    public partial class Postjobexecution
    {
        [JsonPropertyName("Node16")]
        public ExecutionObject? Node16 { get; set; }
        [JsonPropertyName("Node10")]
        public ExecutionObject? Node10 { get; set; }
        [JsonPropertyName("Node")]
        public ExecutionObject? Node { get; set; }
        [JsonPropertyName("PowerShell3")]
        public ExecutionObject PowerShell3 { get; set; } = new ExecutionObject();
        [JsonPropertyName("PowerShell")]
        public ExecutionObject? PowerShell { get; set; }
    }

    public partial class Prejobexecution
    {
        [JsonPropertyName("Node16")]
        public ExecutionObject? Node16 { get; set; }
        [JsonPropertyName("Node10")]
        public ExecutionObject? Node10 { get; set; }
        [JsonPropertyName("Node")]
        public ExecutionObject? Node { get; set; }
        [JsonPropertyName("PowerShell3")]
        public ExecutionObject PowerShell3 { get; set; } = new ExecutionObject();
        [JsonPropertyName("PowerShell")]
        public ExecutionObject? PowerShell { get; set; }
    }

    public partial class Restrictions
    {
        [JsonPropertyName("commands")]
        public Commands Commands { get; set; } = new Commands();
        [JsonPropertyName("settableVariables")]
        public SettableVariables SettableVariables { get; set; } = new SettableVariables();
    }

    public partial class Commands
    {
        [JsonPropertyName("mode")]
        public Mode? Mode { get; set; }
    }

    public partial class SettableVariables
    {
        [JsonPropertyName("allowed")]
        public List<string> Allowed { get; set; } = new List<string>();
    }

    public partial class SourceDefinition
    {
        [JsonPropertyName("target")]
        public string Target { get; set; } = string.Empty;
        [JsonPropertyName("endpoint")]
        public string Endpoint { get; set; } = string.Empty;
        [JsonPropertyName("selector")]
        public string Selector { get; set; } = string.Empty;
        [JsonPropertyName("keySelector")]
        public string KeySelector { get; set; } = string.Empty;
        [JsonPropertyName("authKey")]
        public string AuthKey { get; set; } = string.Empty;
    }

    public partial class Version
    {
        [JsonPropertyName("Major")]
        public double Major { get; set; }
        [JsonPropertyName("Minor")]
        public double Minor { get; set; }
        [JsonPropertyName("Patch")]
        public double Patch { get; set; }
    }
    public enum TaskType { boolean, filePath, multiline, picklist, radio, secureFile, @string, @int, identities, querycontrol}
    public enum TaskCategory { AzureArtifacts, AzureBoards, AzurePipelines, AzureRepos, AzureTestPlans, Build, Deploy, Package, Test, Utility };

    public enum RequestVerb { Delete, Get, Head, Options, Patch, Post, Put, Trace };

    public enum Platform { Windows };

    public enum StringBoolean { False, True };

    public enum Mode { Any, Restricted };

    public enum RunsOn { Agent, DeploymentGroup, MachineGroup, Server, ServerGate };

    public enum Visibility { Build, Release };
    public partial struct DefaultValue
    {
        public bool? Bool;
        public string String;

        public static implicit operator DefaultValue(bool Bool) => new DefaultValue { Bool = Bool };
        public static implicit operator DefaultValue(string String) => new DefaultValue { String = String };
    }
}