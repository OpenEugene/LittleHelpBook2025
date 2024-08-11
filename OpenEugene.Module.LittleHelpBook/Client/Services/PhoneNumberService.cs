using System.Net.Http;
using System.Threading.Tasks;
using Oqtane.Modules;
using Oqtane.Services;
using Oqtane.Shared;


namespace OpenEugene.Module.LittleHelpBook.Services
{
    public class PhoneNumberService : ServiceBase, IService
    {
        public PhoneNumberService(HttpClient http, SiteState siteState) : base(http, siteState) { }

        private string Apiurl => CreateApiUrl("PhoneNumber");

        public async Task<Models.PhoneNumber> AddPhoneNumberAsync(Models.PhoneNumber item)
        {
            item.EnsureIAuditable();
            return await PostJsonAsync<Models.PhoneNumber>($"{Apiurl}", item);
            
        }

        public async Task DeletePhoneNumberAsync(int id)
        {
            await DeleteAsync($"{Apiurl}/{id}");
        }
    }
}
