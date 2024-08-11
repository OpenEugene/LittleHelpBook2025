using Oqtane.Models;
using Oqtane.Modules;

namespace OpenEugene.Module.LittleHelpBook
{
    public class ModuleInfo : IModule
    {
        public ModuleDefinition ModuleDefinition => new ModuleDefinition
        {
            Name = "LittleHelpBook",
            Description = "digital edition of the little help book",
            Version = "1.0.0",
            ServerManagerType = "OpenEugene.Module.LittleHelpBook.Manager.LittleHelpBookManager, OpenEugene.Module.LittleHelpBook.Server.Oqtane",
            ReleaseVersions = "1.0.0",
            Dependencies = "OpenEugene.Module.LittleHelpBook.Shared.Oqtane,MudBlazor",
            PackageName = "OpenEugene.LittleHelpBook" 
        };
    }
}
