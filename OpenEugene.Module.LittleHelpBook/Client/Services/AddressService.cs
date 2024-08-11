using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Oqtane.Models;
using Oqtane.Modules;
using Oqtane.Services;
using Oqtane.Shared;


namespace OpenEugene.Module.LittleHelpBook.Services
{
    public class AddressService : ServiceBase, IService
    {
        public AddressService(HttpClient http, SiteState siteState) : base(http, siteState) { }

        private string Apiurl => CreateApiUrl("Address");

        public async Task<Models.Address> AddAddressAsync(Models.Address item)
        {
            item.EnsureIAuditable();

            return await PostJsonAsync<Models.Address>($"{Apiurl}", item);
            
        }

        public async Task DeleteAddressAsync(int id)
        {
            await DeleteAsync($"{Apiurl}/{id}");
        }
    }
}
