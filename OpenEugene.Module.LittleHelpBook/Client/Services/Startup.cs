using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using Oqtane.Services;

namespace OpenEugene.Module.LittleHelpBook.Client.Services
{
    public class Startup : IClientStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMudServices();
    }
    }
}
