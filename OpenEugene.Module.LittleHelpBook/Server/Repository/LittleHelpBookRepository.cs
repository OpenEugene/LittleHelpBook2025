using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace OpenEugene.Module.LittleHelpBook.Repository
{
    public partial class LittleHelpBookRepository : ITransientService
    {
        private readonly IDbContextFactory<LittleHelpBookContext> _factory;
        private readonly LittleHelpBookContext _db;

        public LittleHelpBookRepository(IDbContextFactory<LittleHelpBookContext> factory, 
            LittleHelpBookContext context)
        {
            _factory = factory;
            _db = context;
        }

        public IEnumerable<Models.LittleHelpBook> GetLittleHelpBooks(int ModuleId)
        {
            using var db = _factory.CreateDbContext();
            return db.LittleHelpBook.Where(item => item.ModuleId == ModuleId).ToList();
        }

        public Models.LittleHelpBook GetLittleHelpBook(int LittleHelpBookId)
        {
            return GetLittleHelpBook(LittleHelpBookId, true);
        }

        public Models.LittleHelpBook GetLittleHelpBook(int LittleHelpBookId, bool tracking)
        {
            using var db = _factory.CreateDbContext();
            if (tracking)
            {
                return db.LittleHelpBook.Find(LittleHelpBookId);
            }
            else
            {
                return db.LittleHelpBook.AsNoTracking().FirstOrDefault(item => item.LittleHelpBookId == LittleHelpBookId);
            }
        }

        public Models.LittleHelpBook AddLittleHelpBook(Models.LittleHelpBook LittleHelpBook)
        {
            using var db = _factory.CreateDbContext();
            db.LittleHelpBook.Add(LittleHelpBook);
            db.SaveChanges();
            return LittleHelpBook;
        }

        public Models.LittleHelpBook UpdateLittleHelpBook(Models.LittleHelpBook LittleHelpBook)
        {
            using var db = _factory.CreateDbContext();
            db.Entry(LittleHelpBook).State = EntityState.Modified;
            db.SaveChanges();
            return LittleHelpBook;
        }

        public void DeleteLittleHelpBook(int LittleHelpBookId)
        {
            using var db = _factory.CreateDbContext();
            Models.LittleHelpBook LittleHelpBook = db.LittleHelpBook.Find(LittleHelpBookId);
            db.LittleHelpBook.Remove(LittleHelpBook);
            db.SaveChanges();
        }


        public async Task<IEnumerable<Models.LittleHelpBook>> GetLittleHelpBooksAsync(int ModuleId)
        {
            using var db = _factory.CreateDbContext();
            return await db.LittleHelpBook.Where(item => item.ModuleId == ModuleId).ToListAsync();
        }

        public async Task<Models.LittleHelpBook> GetLittleHelpBookAsync(int LittleHelpBookId)
        {
            return await GetLittleHelpBookAsync(LittleHelpBookId, true);
        }

        public async Task<Models.LittleHelpBook> GetLittleHelpBookAsync(int LittleHelpBookId, bool tracking)
        {
            using var db = _factory.CreateDbContext();
            if (tracking)
            {
                return await db.LittleHelpBook.FindAsync(LittleHelpBookId);
            }
            else
            {
                return await db.LittleHelpBook.AsNoTracking().FirstOrDefaultAsync(item => item.LittleHelpBookId == LittleHelpBookId);
            }
        }

        public async Task<Models.LittleHelpBook> AddLittleHelpBookAsync(Models.LittleHelpBook LittleHelpBook)
        {
            using var db = _factory.CreateDbContext();
            db.LittleHelpBook.Add(LittleHelpBook);
            await db.SaveChangesAsync();
            return LittleHelpBook;
        }

        public async Task<Models.LittleHelpBook> UpdateLittleHelpBookAsync(Models.LittleHelpBook LittleHelpBook)
        {
            using var db = _factory.CreateDbContext();
            db.Entry(LittleHelpBook).State = EntityState.Modified;
            await db.SaveChangesAsync();
            return LittleHelpBook;
        }

        public async Task DeleteLittleHelpBookAsync(int LittleHelpBookId)
        {
            using var db = _factory.CreateDbContext();
            Models.LittleHelpBook LittleHelpBook = db.LittleHelpBook.Find(LittleHelpBookId);
            db.LittleHelpBook.Remove(LittleHelpBook);
            await db.SaveChangesAsync();
        }
    }
}
