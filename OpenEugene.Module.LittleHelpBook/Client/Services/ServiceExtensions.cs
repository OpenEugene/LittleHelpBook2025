using Oqtane.Models;
using Oqtane.Services;
using System;

namespace OpenEugene.Module.LittleHelpBook.Services
{
    internal static class ServiceExtensions
    {
        public static void EnsureIAuditable(this IAuditable item)
        {
            item.CreatedBy = "";
            item.CreatedOn = DateTime.UtcNow;
            item.ModifiedBy = "";
            item.ModifiedOn = DateTime.UtcNow;
        }
    }
}
