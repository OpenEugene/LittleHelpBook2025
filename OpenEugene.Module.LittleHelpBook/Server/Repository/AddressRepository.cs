using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;
using System.Security.Cryptography;
using OpenEugene.Module.LittleHelpBook.Models;

namespace OpenEugene.Module.LittleHelpBook.Repository
{
    public partial class LittleHelpBookRepository
    {

        public List<Address> GetAddressesByProviderId(int providerId, bool tracking = false) {

            using var db = _factory.CreateDbContext();
            // get a list of addresses for a provider
            var addrs = from a in db.Address
                        where a.ProviderId == providerId
                        select a;
            return addrs.ToList();
        }

        public Address GetAddressByAddressId(int addressId) {
            return GetAddress(addressId, true);
        }

        public Address GetAddress(int addressId, bool tracking) {
            using var db = _factory.CreateDbContext();
            return tracking ? db.Address.Find(addressId) : db.Address.AsNoTracking().FirstOrDefault(item => item.AddressId == addressId);
        }

        public Address AddAddress(Address item) {
            using var db = _factory.CreateDbContext();
            db.Address.Add(item);
            db.SaveChanges();
            return item;
        }

        public Address UpdateAddress(Address addressId) {
            using var db = _factory.CreateDbContext();
            db.Entry(addressId).State = EntityState.Modified;
            db.SaveChanges();
            return addressId;
        }

        public void DeleteAddress(int addressId) {
            using var db = _factory.CreateDbContext();
            var item = db.Address.Find(addressId);

            if (item == null) return;
            db.Address.Remove(item);
            db.SaveChanges();
        }
    }
}