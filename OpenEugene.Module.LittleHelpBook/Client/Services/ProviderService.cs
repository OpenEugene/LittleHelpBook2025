using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using OpenEugene.Module.LittleHelpBook.ViewModels;
using Oqtane.Modules;
using Oqtane.Services;
using Oqtane.Shared;

namespace OpenEugene.Module.LittleHelpBook.Services
{
    public class ProviderService : ServiceBase, IService
    {
        public ProviderService(HttpClient http, SiteState siteState) : base(http, siteState) { }

        private string Apiurl => CreateApiUrl("Provider");

        public async Task<List<Models.Provider>> GetProvidersAsync()
        {
            List<Models.Provider> list = await GetJsonAsync<List<Models.Provider>>($"{Apiurl}");
            if (list != null)
            {
                return list.OrderBy(item => item.Name).ToList();
            }
            return null;
        }

        public async Task<Models.Provider> GetProviderAsync(int id)
        {
            return await GetJsonAsync<Models.Provider>($"{Apiurl}/{id}");
        }

        public async Task<ProviderViewModel> GetProviderViewModelAsync(int id)
        {
            var vm = await GetJsonAsync<ProviderViewModel>($"{Apiurl}/vm/{id}");
            return vm;
        }

        public async Task<Models.Provider> AddProviderAsync(Models.Provider item)
        {
            return await PostJsonAsync<Models.Provider>($"{Apiurl}", item);
        }

        public async Task<Models.Provider> UpdateProviderAsync(Models.Provider item)
        {
            return await PutJsonAsync<Models.Provider>($"{Apiurl}/{item.ProviderId}", item);
        }

        public async Task<ProviderViewModel> UpdateProviderAsync(ProviderViewModel item)
        {
            return await PutJsonAsync<ProviderViewModel>($"{Apiurl}/vm/{item.ProviderId}", item);
        }

        public async Task DeleteProviderAsync(int id)
        {
            await DeleteAsync($"{Apiurl}/{id}");
        }

        public async Task<List<ProviderAttributeViewModel>> GetAttributesForProviderAsync(int id) {
            var vm = await GetJsonAsync<List<ProviderAttributeViewModel>>($"{Apiurl}/ProviderAttributes/{id}");
            return vm;
        }
        public async Task DeleteAttributeAsync(int id)
        {
            await DeleteAsync($"{Apiurl}/ProviderAttribute/{id}");
        }
        public async Task<Models.ProviderAttribute> AddProviderAttribute(Models.ProviderAttribute item)
        {
            item.EnsureIAuditable();
            return await PostJsonAsync<Models.ProviderAttribute>($"{Apiurl}/ProviderAttribute", item);
        }

    }
}
