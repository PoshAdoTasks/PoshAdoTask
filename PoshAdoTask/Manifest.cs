namespace PoshAdoTask.Manifest.Types
{
    using System;
    using System.Collections.Generic;
    using System.Text.Json;
    using System.Text.Json.Serialization;

    public partial class Manifest
    {
        [JsonPropertyName("manifestVersion")]
        public long ManifestVersion { get; set; }
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;
        [JsonPropertyName("version")]
        public string Version { get; set; } = string.Empty;
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("publisher")]
        public string Publisher { get; set; } = string.Empty;
        [JsonPropertyName("categories")]
        public List<string> Categories { get; set; } = new List<string>();
        [JsonPropertyName("targets")]
        public List<Target> Targets { get; set; } = new List<Target>();
        [JsonPropertyName("scopes")]
        public List<Scope>? Scopes { get; set; }
        [JsonPropertyName("demands")]
        public List<string>? Demands { get; set; }
        [JsonPropertyName("baseUri")]
        public Uri? BaseUri { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;
        [JsonPropertyName("icons")]
        public Icon? Icons { get; set; }
        [JsonPropertyName("tags")]
        public List<string>? Tags { get; set; }
        [JsonPropertyName("galleryFlags")]
        public List<GalleryFlag>? GalleryFlags { get; set; }
        [JsonPropertyName("licensing")]
        public Dictionary<string, object>? Licensing { get; set; }
        [JsonPropertyName("galleryproperties")]
        public Dictionary<string, object>? Galleryproperties { get; set; }
        [JsonPropertyName("screenshots")]
        public List<ScreenShot>? Screenshots { get; set; }
        [JsonPropertyName("content")]
        public Content? Content { get; set; } = new Content();
        [JsonPropertyName("links")]
        public Link Links { get; set; } = new Link();
        [JsonPropertyName("repository")]
        public Repository Repository { get; set; } = new Repository();
        [JsonPropertyName("badges")]
        public List<Badge>? Badges { get; set; }
        [JsonPropertyName("branding")]
        public Branding? Branding { get; set; }
        [JsonPropertyName("public")]
        public bool? Public { get; set; } = false;
        [JsonPropertyName("files")]
        public List<File> Files { get; set; } = new List<File>();
        [JsonPropertyName("contributions")]
        public List<Contribution>? Contributions { get; set; }
        [JsonPropertyName("contributionTypes")]
        public List<ContributionType>? ContributionTypes { get; set; }
        public Manifest()
        { }
        public Manifest(string? json)
        {
            if (!(string.IsNullOrEmpty(json)))
            {
                JsonSerializerOptions options = new JsonSerializerOptions();

                options.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                options.Converters.Add(new JsonStringEnumConverter());
                options.PropertyNameCaseInsensitive = true;

                Manifest? manifest = JsonSerializer.Deserialize<Manifest>(json, options);
                if (manifest != null)
                {
                    ManifestVersion = manifest.ManifestVersion;
                    Id = manifest.Id;
                    Version = manifest.Version;
                    Name = manifest.Name;
                    Publisher = manifest.Publisher;
                    Categories = manifest.Categories;
                    Targets = manifest.Targets;
                    Scopes = manifest.Scopes;
                    Demands = manifest.Demands;
                    BaseUri = manifest.BaseUri;
                    Description = manifest.Description;
                    Icons = manifest.Icons;
                    Tags = manifest.Tags;
                    GalleryFlags = manifest.GalleryFlags;
                    Licensing = manifest.Licensing;
                    Galleryproperties = manifest.Galleryproperties;
                    Screenshots = manifest.Screenshots;
                    Content = manifest.Content;
                    Links = manifest.Links;
                    Repository = manifest.Repository;
                    Badges = manifest.Badges;
                    Branding = manifest.Branding;
                    Public = manifest.Public;
                    Files = manifest.Files;
                    Contributions = manifest.Contributions;
                    ContributionTypes = manifest.ContributionTypes;
                }
            }
        }
        public Manifest(long ManifestVersion, string Id, string Version, string Name, string Publisher)
        {
            this.ManifestVersion = ManifestVersion;
            this.Id = Id;
            this.Version = Version;
            this.Name = Name;
            this.Publisher = Publisher;
            Categories.Add(ManifestCategory.AzurePipelines);
            Targets.Add(new Target(TargetId.MicrosoftVisualStudioServices));
        }
        public override string ToString()
        {
            JsonSerializerOptions options = new();
            options.Converters.Add(new JsonStringEnumConverter());
            options.WriteIndented = true;
            options.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;

            return JsonSerializer.Serialize<Manifest>(this, options);
        }
        public void AddFile(string Path)
        {
            this.Files.Add(new File(Path));
        }
        public void AddFile(File File)
        {
            this.Files.Add(File);
        }
    }
    public enum GalleryFlag { Paid, Preview, Public };
    public enum RepositoryType { Cvs, Git, Mercurial, Svn };
    public enum RestrictedDefinition { Anonymous, Member, Public };
    public enum Theme { Dark, Light };
    public enum Scope { VsoAcquisitionWrite, VsoAgentpools, VsoAgentpoolsListen, VsoAgentpoolsManage, VsoAnalytics, VsoAuditlog, VsoBase, VsoBuild, VsoBuildExecute, VsoBuildFork, VsoCode, VsoCodeFull, VsoCodeManage, VsoCodeStatus, VsoCodeWrite, VsoCommerceWrite, VsoConnectedServer, VsoDashboards, VsoDashboardsManage, VsoEntitlements, VsoExtension, VsoExtensionData, VsoExtensionDataWrite, VsoExtensionDefault, VsoExtensionManage, VsoFeatures, VsoFeaturesWrite, VsoGallery, VsoGalleryAcquire, VsoGalleryManage, VsoGalleryPublish, VsoGovernanceManage, VsoGraph, VsoGraphManage, VsoGraphWrite, VsoHooks, VsoHooksInteract, VsoHooksWrite, VsoIdentity, VsoIdentityManage, VsoLicensing, VsoLoadtest, VsoLoadtestWrite, VsoMachinegroupManage, VsoMemberentitlementmanagement, VsoMemberentitlementmanagementWrite, VsoNotification, VsoNotificationDiagnostics, VsoNotificationManage, VsoNotificationPublish, VsoNotificationWrite, VsoPackaging, VsoPackagingManage, VsoPackagingWrite, VsoProfile, VsoProfileWrite, VsoProject, VsoProjectManage, VsoProjectWrite, VsoRelease, VsoReleaseExecute, VsoReleaseLogs, VsoReleaseManage, VsoSecurityManage, VsoServiceendpoint, VsoServiceendpointManage, VsoServiceendpointQuery, VsoSettings, VsoSettingsWrite, VsoSymbols, VsoSymbolsManage, VsoSymbolsWrite, VsoTaskgroupsManage, VsoTaskgroupsRead, VsoTaskgroupsWrite, VsoTest, VsoTestWrite, VsoTokenadministration, VsoTokens, VsoVariablegroupsManage, VsoVariablegroupsRead, VsoVariablegroupsWrite, VsoWiki, VsoWikiWrite, VsoWork, VsoWorkFull, VsoWorkWrite };
    public enum ContributionTypeEnum { Array, Boolean, DateTime, Double, Guid, Integer, Object, String, Uri };

    public static class ManifestCategory
    {
        public static readonly string AzureArtifacts = "Azure Artifacts";
        public static readonly string AzureBoards = "Azure Boards";
        public static readonly string AzurePipelines = "Azure Pipelines";
        public static readonly string AzureRepos = "Azure Repos";
        public static readonly string AzureTestPlans = "Azure Test Plans";
    }

    public static class TargetId 
    {
        public static readonly string MicrosoftTeamFoundationServer = "Microsoft.TeamFoundation.Server";
        public static readonly string MicrosoftTeamFoundationServerIntegration = "Microsoft.TeamFoundation.Server.Integration";
        public static readonly string MicrosoftVisualStudioServices = "Microsoft.VisualStudio.Services";
        public static readonly string MicrosoftVisualStudioServicesCloud = "Microsoft.VisualStudio.Services.Cloud";
        public static readonly string MicrosoftVisualStudioServicesCloudIntegration = "Microsoft.VisualStudio.Services.Cloud.Integration";
        public static readonly string MicrosoftVisualStudioServicesIntegration = "Microsoft.VisualStudio.Services.Integration";
    }
    public partial class Target
    {
        [JsonPropertyName("id")]
        public string? Id { get; set; }
        [JsonPropertyName("version")]
        public string? Version { get; set; }
        public Target()
        { }
        public Target (string Id)
        {
            this.Id = Id;
        }
        public Target(string Id, string Version)
        {
            this.Id = Id;
            this.Version = Version;
        }
    }
    public partial class Icon
    {
        [JsonPropertyName("default")]
        public string Default { get; set; } = string.Empty;
        public Icon()
        { }
        public Icon(string Path)
        {
            Default = Path;
        }
    }
    public partial class File
    {
        [JsonPropertyName("path")]
        public string Path { get; set; } = string.Empty;
        [JsonPropertyName("addressable")]
        public bool? Addressable { get; set; }
        [JsonPropertyName("packagePath")]
        public string? PackagePath { get; set; }
        public File()
        { }
        public File (string Path)
        {
            Addressable = false;
            this.Path = Path;
        }
        public File(string Path, bool Addressable, string PackagePath)
        {
            this.Addressable = Addressable;
            this.Path = Path;
            this.PackagePath = PackagePath;
        }
    }
    public partial class ContentDefinition
    {
        [JsonPropertyName("path")]
        public string Path { get; set; } = string.Empty;
        public ContentDefinition()
        {}
        public ContentDefinition(string Path)
        {
            this.Path = Path;
        }
    }
    public partial class Content
    {
        [JsonPropertyName("details")]
        public ContentDefinition Details { get; set; } = new ContentDefinition();
        [JsonPropertyName("license")]
        public ContentDefinition? License { get; set; }
        [JsonPropertyName("pricing")]
        public ContentDefinition? Pricing { get; set; }
    }
    public partial class LinkDefinition
    {
        [JsonPropertyName("uri")]
        public Uri? Uri { get; set; }
        public LinkDefinition()
        { }
        public LinkDefinition(string Path)
        {
            Uri = new Uri(Path);
        }
    }
    public partial class Link
    {
        [JsonPropertyName("getstarted")]
        public LinkDefinition Getstarted { get; set; } = new LinkDefinition();
        [JsonPropertyName("learn")]
        public LinkDefinition? Learn { get; set; }
        [JsonPropertyName("license")]
        public LinkDefinition License { get; set; } = new LinkDefinition();
        [JsonPropertyName("privacypolicy")]
        public LinkDefinition? PrivacyPolicy { get; set; }
        [JsonPropertyName("support")]
        public LinkDefinition Support { get; set; } = new LinkDefinition();
    }
    public partial class Repository
    {
        [JsonPropertyName("type")]
        public string? Type { get; set; }
        [JsonPropertyName("uri")]
        public Uri? Uri { get; set; }
    }
    public partial class Contribution
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;
        [JsonPropertyName("type")]
        public string? Type { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;
        [JsonPropertyName("targets")]
        public List<string> Targets { get; set; } = new List<string>();
        [JsonPropertyName("restrictedTo")]
        public List<RestrictedDefinition> RestrictedTo { get; set; } = new List<RestrictedDefinition>();
        [JsonPropertyName("properties")]
        public Dictionary<string, object> Properties { get; set; } = new Dictionary<string, object>();
        public Contribution()
        { }
        public Contribution(string Id, string Type)
        {
            this.Id = Id;
            this.Type = Type;
            Targets.Add(Type);
        }
    }
    public partial class Branding
    {
        [JsonPropertyName("color")]
        public string Color { get; set; } = string.Empty;
        [JsonPropertyName("theme")]
        public Theme? Theme { get; set; }
    }
    public partial class Badge
    {
        [JsonPropertyName("href")]
        public Uri? Href { get; set; }
        [JsonPropertyName("uri")]
        public Uri? Uri { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;
    }
    public partial class ContributionProperty
    {
        [JsonPropertyName("type")]
        public ContributionTypeEnum Type { get; set; }
        [JsonPropertyName("required")]
        public bool? Required { get; set; }
        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;
    }
    public partial class ContributionType
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("description")]
        public string Description { get; set; } = string.Empty;
        [JsonPropertyName("properties")]
        public List<ContributionProperty> Properties { get; set; } = new List<ContributionProperty>();
    }
    public partial class ScreenShot
    {
        [JsonPropertyName("path")]
        public string Path { get; set; } = string.Empty;
    }

    public static class IEnumerableExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> items)
        {
            return !(items?.Any() ?? false);
        }
    }
}