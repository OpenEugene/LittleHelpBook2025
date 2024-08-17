using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;

using System.Security.Cryptography;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using OpenEugene.Module.LittleHelpBook.Models;

namespace OpenEugene.Module.LittleHelpBook.Repository
{
    public partial class LittleHelpBookRepository
    {

        public IEnumerable<Attribute> GetAttributes() {
            using var db = _factory.CreateDbContext();
            var list = from a in db.Attribute.AsNoTracking()
                       select a;
            return list;
        }

    }
}