using System.Collections.Generic;
using System.Threading.Tasks;

namespace OpenEugene.Module.LittleHelpBook.Repository
{
    public interface ILittleHelpBookRepository
    {
        IEnumerable<Models.LittleHelpBook> GetLittleHelpBooks(int ModuleId);
        Models.LittleHelpBook GetLittleHelpBook(int LittleHelpBookId);
        Models.LittleHelpBook GetLittleHelpBook(int LittleHelpBookId, bool tracking);
        Models.LittleHelpBook AddLittleHelpBook(Models.LittleHelpBook LittleHelpBook);
        Models.LittleHelpBook UpdateLittleHelpBook(Models.LittleHelpBook LittleHelpBook);
        void DeleteLittleHelpBook(int LittleHelpBookId);

        Task<IEnumerable<Models.LittleHelpBook>> GetLittleHelpBooksAsync(int ModuleId);
        Task<Models.LittleHelpBook> GetLittleHelpBookAsync(int LittleHelpBookId);
        Task<Models.LittleHelpBook> GetLittleHelpBookAsync(int LittleHelpBookId, bool tracking);
        Task<Models.LittleHelpBook> AddLittleHelpBookAsync(Models.LittleHelpBook LittleHelpBook);
        Task<Models.LittleHelpBook> UpdateLittleHelpBookAsync(Models.LittleHelpBook LittleHelpBook);
        Task DeleteLittleHelpBookAsync(int LittleHelpBookId);
    }
}
