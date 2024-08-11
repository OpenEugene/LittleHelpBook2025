using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Repository;
using Oqtane.Infrastructure;
using Oqtane.Repository.Databases.Interfaces;

namespace OpenEugene.Module.LittleHelpBook.Repository
{
    public class LittleHelpBookContext : DBContextBase, ITransientService, IMultiDatabase
    {
        public virtual DbSet<Models.LittleHelpBook> LittleHelpBook { get; set; }

        public LittleHelpBookContext(IDBContextDependencies DBContextDependencies) : base(DBContextDependencies)
        {
            // ContextBase handles multi-tenant database connections
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Models.LittleHelpBook>().ToTable(ActiveDatabase.RewriteName("OpenEugeneLittleHelpBook"));
        }
    }
}
