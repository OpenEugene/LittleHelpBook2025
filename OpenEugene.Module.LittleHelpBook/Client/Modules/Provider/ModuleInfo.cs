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
            ServerManagerType = "OE.Module.LHB.Manager.LHBManager, OE.Module.LHB.Server.Oqtane",
            ReleaseVersions = "1.1.0",
            Dependencies = "OpenEugene.Module.LittleHelpBook.Shared.Oqtane,MudBlazor",
            PackageName = "OpenEugene.LittleHelpBook"
        };
    }
}
