using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Oqtane.Modules;
using Oqtane.Repository;
using Oqtane.Infrastructure;
using Oqtane.Repository.Databases.Interfaces;
using OpenEugene.Module.LittleHelpBook.Models;

namespace OpenEugene.Module.LittleHelpBook.Repository
{
    public class LittleHelpBookContext : DBContextBase, ITransientService, IMultiDatabase
    {
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Attribute> Attribute { get; set; }
        public virtual DbSet<PhoneNumber> PhoneNumber { get; set; }
        public virtual DbSet<Provider> Provider { get; set; }
        public virtual DbSet<ProviderAttribute> ProviderAttribute { get; set; }
 
        public LittleHelpBookContext(IDBContextDependencies DBContextDependencies) : base(DBContextDependencies)
        {
            // ContextBase handles multi-tenant database connections
        }

       
    }
}
