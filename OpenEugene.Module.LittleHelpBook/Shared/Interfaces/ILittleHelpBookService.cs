using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenEugene.Module.LittleHelpBook.Services
{
    public interface ILittleHelpBookService 
    {
        Task<List<Models.LittleHelpBook>> GetLittleHelpBooksAsync(int ModuleId);

        Task<Models.LittleHelpBook> GetLittleHelpBookAsync(int LittleHelpBookId, int ModuleId);

        Task<Models.LittleHelpBook> AddLittleHelpBookAsync(Models.LittleHelpBook LittleHelpBook);

        Task<Models.LittleHelpBook> UpdateLittleHelpBookAsync(Models.LittleHelpBook LittleHelpBook);

        Task DeleteLittleHelpBookAsync(int LittleHelpBookId, int ModuleId);
    }
}
