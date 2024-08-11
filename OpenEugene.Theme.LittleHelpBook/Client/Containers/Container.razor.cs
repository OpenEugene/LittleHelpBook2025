using Microsoft.AspNetCore.Components;
using Oqtane.Themes;
using Oqtane.Services;

namespace OpenEugene.Theme.LittleHelpBook
{
    public partial class Container : ContainerBase
    {
        public override string Name => "OpenEugene LittleHelpBook - Container";

        [Inject] ISettingService SettingService { get; set; }
        private bool _title = true;
        private string _classes = "container-fluid";

        protected override void OnParametersSet()
        {
            try
            {

                _title = bool.Parse(SettingService.GetSetting(ModuleState.Settings, GetType().Namespace + ":Title", "true"));

            }
            catch
            {
                // error loading container settings
            }
        }
    }
}
