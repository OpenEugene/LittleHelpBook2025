using Oqtane.Models;
using Oqtane.Modules;

namespace OpenEugene.Module.Template
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "Template",
            Description = "Template",
            Version = "1.1.3",
            ServerManagerType = "OpenEugene.Module.LittleHelpBook.Manager.LittleHelpBookManager, OpenEugene.Module.LittleHelpBook.Server.Oqtane",
            ReleaseVersions = "1.1.3",
            Dependencies = "OpenEugene.Module.LittleHelpBook.Shared.Oqtane,MudBlazor",
            PackageName = "OpenEugene.LittleHelpBook" 
        };
    }
}
