using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Oqtane.Modules;
using Oqtane.Services;
using Oqtane.Shared;

namespace OpenEugene.Module.LittleHelpBook.Services
{
    public class LittleHelpBookService : ServiceBase, IService
    {
        public LittleHelpBookService(IHttpClientFactory http, SiteState siteState) : base(http, siteState) { }

        private string Apiurl => CreateApiUrl("LittleHelpBook");

        public async Task<List<Models.LittleHelpBook>> GetLittleHelpBooksAsync(int ModuleId)
        {
            List<Models.LittleHelpBook> LittleHelpBooks = await GetJsonAsync<List<Models.LittleHelpBook>>(CreateAuthorizationPolicyUrl($"{Apiurl}?moduleid={ModuleId}", EntityNames.Module, ModuleId), Enumerable.Empty<Models.LittleHelpBook>().ToList());
            return LittleHelpBooks.OrderBy(item => item.Name).ToList();
        }

        public async Task<Models.LittleHelpBook> GetLittleHelpBookAsync(int LittleHelpBookId, int ModuleId)
        {
            return await GetJsonAsync<Models.LittleHelpBook>(CreateAuthorizationPolicyUrl($"{Apiurl}/{LittleHelpBookId}", EntityNames.Module, ModuleId));
        }

        public async Task<Models.LittleHelpBook> AddLittleHelpBookAsync(Models.LittleHelpBook LittleHelpBook)
        {
            return await PostJsonAsync<Models.LittleHelpBook>(CreateAuthorizationPolicyUrl($"{Apiurl}", EntityNames.Module, LittleHelpBook.ModuleId), LittleHelpBook);
        }

        public async Task<Models.LittleHelpBook> UpdateLittleHelpBookAsync(Models.LittleHelpBook LittleHelpBook)
        {
            return await PutJsonAsync<Models.LittleHelpBook>(CreateAuthorizationPolicyUrl($"{Apiurl}/{LittleHelpBook.LittleHelpBookId}", EntityNames.Module, LittleHelpBook.ModuleId), LittleHelpBook);
        }

        public async Task DeleteLittleHelpBookAsync(int LittleHelpBookId, int ModuleId)
        {
            await DeleteAsync(CreateAuthorizationPolicyUrl($"{Apiurl}/{LittleHelpBookId}", EntityNames.Module, ModuleId));
        }
    }
}
