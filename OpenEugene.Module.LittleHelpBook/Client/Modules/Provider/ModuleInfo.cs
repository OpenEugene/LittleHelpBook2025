using Oqtane.Models;
using Oqtane.Modules;
using Oqtane.Shared;
using System.Collections.Generic;

namespace OpenEugene.Module.Provider
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "Provider",
            Description = "Providers",
            Version = "1.1.0",
            ServerManagerType = "OpenEugene.Module.LittleHelpBook.Manager.LittleHelpBookManager, OpenEugene.Module.LittleHelpBook.Server.Oqtane",
            ReleaseVersions = "1.1.0",
            Dependencies = "OpenEugene.Module.LittleHelpBook.Shared.Oqtane,MudBlazor",
            PackageName = "OpenEugene.LittleHelpBook",
            Resources = new List<Resource>()
            {
                new Resource { ResourceType = ResourceType.Stylesheet,  Url = "https://fonts.googleapis.com/css?family=Roboto:300,400,500,700&display=swap" },
                new Resource { ResourceType = ResourceType.Stylesheet,  Url = "_content/MudBlazor/MudBlazor.min.css" },
                new Resource { ResourceType = ResourceType.Script,     Url = "_content/MudBlazor/MudBlazor.min.js", Location = ResourceLocation.Body, Level = ResourceLevel.Site },
            }
        };
    }
}
