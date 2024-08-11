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
    public class AttributeService : ServiceBase, IService
    {
        public AttributeService(HttpClient http, SiteState siteState) : base(http, siteState) { }

        private string Apiurl => CreateApiUrl("Attribute");

        public async Task<List<Models.Attribute>> GetAttributesAsync()
        {
            List<Models.Attribute> list = await GetJsonAsync<List<Models.Attribute>>($"{Apiurl}");
            if (list != null)
            {
                return list.OrderBy(item => item.Name).ToList();
            }
            return null;
        }


        public async Task<Models.Attribute> AddAttributeAsync(Models.Attribute item)
        {
            item.EnsureIAuditable();
            return await PostJsonAsync<Models.Attribute>($"{Apiurl}", item);
        }

        public async Task DeleteAddressAsync(int id)
        {
            await DeleteAsync($"{Apiurl}/{id}");
        }
    }
}
