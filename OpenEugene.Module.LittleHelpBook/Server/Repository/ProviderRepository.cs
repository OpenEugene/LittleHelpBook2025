using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Oqtane.Modules;
using System.Security.Cryptography;
using OpenEugene.Module.LittleHelpBook.ViewModels;
using OpenEugene.Module.LittleHelpBook.Models;

namespace OpenEugene.Module.LittleHelpBook.Repository
{
    public partial class LittleHelpBookRepository
    {

        public List<Provider> GetProviders()
        {
            using var db = _factory.CreateDbContext();
            var list = db.Provider.AsNoTracking();
            return list.ToList(); // need to realize the resuls before the db connection closes
        }

        public Provider GetProvider(int id)
        {
            return GetProvider(id, true);
        }

        public Provider GetProvider(int id, bool tracking) {
            using var db = _factory.CreateDbContext();
            return tracking ? db.Provider.Find(id) 
                : db.Provider.AsNoTracking().FirstOrDefault(item => item.ProviderId == id);
        }

        public ProviderViewModel GetProviderViewModel(int id) {
            var provider = GetProvider(id);
            if (provider == null)
            {
                return null;
            }
            var vm = new ProviderViewModel(provider) {
                Addresses = GetAddressesByProviderId(id),
                PhoneNumbers = GetPhoneNumbersByProviderId(id),
                ProviderAttributes = GetProviderAttributesByProviderId(id)
            };

            return vm;
        }


        public Provider AddProvider(Provider item)
        {
            using var db = _factory.CreateDbContext();
            db.Provider.Add(item);
            db.SaveChanges();
            return item;
        }

        public Provider UpdateProvider(Provider provider)
        {
            using var db = _factory.CreateDbContext();
            db.Entry(provider).State = EntityState.Modified;
            db.SaveChanges();
            return provider;
        }
        public ProviderViewModel UpdateProvider(ProviderViewModel providerVm)
        {
            using var db = _factory.CreateDbContext();
            // update provider
            db.Entry<Provider>(providerVm as Provider).State = EntityState.Modified;

            //addresses
            foreach(var address in providerVm.Addresses)
            {
                if (address.AddressId == 0)
                {
                    // add new address
                    db.Address.Add(address);

                    //I think we need to add a new ProviderAddress row too.
                }
                else
                {
                    // update existing address
                    db.Entry<Address>(address).State = EntityState.Modified;
                }
            }
            //phones
            foreach (var phone in providerVm.PhoneNumbers) {
                if (phone.PhoneNumberId == 0) {
                    // add new address
                    db.PhoneNumber.Add(phone);

                    //I think we need to add a new ProviderPhone row too.
                    
                }
                else {
                    // update existing address
                    db.Entry<PhoneNumber>(phone).State = EntityState.Modified;
                }
            }

            db.SaveChanges();

            return providerVm;
        }

        public void DeleteProvider(int providerId)
        {
            using var db = _factory.CreateDbContext();
            var item = db.Provider.Find(providerId);

            if (item == null) return;
            db.Provider.Remove(item);
            db.SaveChanges();

        }

        // Provider Attributes could be a separate file, but it's all the same partial class

        public List<ProviderAttributeViewModel> GetProviderAttributesByProviderId(int providerId, bool tracking = false)
        {
            using var db = _factory.CreateDbContext();
            // get a list of attributes for a provider
            var list = from p in db.ProviderAttribute
                       join a in db.Attribute on p.AttributeId equals a.AttributeId
                       where p.ProviderId == providerId
                       select new ProviderAttributeViewModel
                       {
                           ProviderAttributeId = p.ProviderAttributeId,
                           ProviderId = p.ProviderId,
                           AttributeId = p.AttributeId,
                           Attribute = a,
                       };

            return list.ToList();
        }

        public ProviderAttribute GetProviderAttribute(int id, bool tracking = false)
        {
            using var db = _factory.CreateDbContext();
            // get a list of attributes for a provider
            var item = db.ProviderAttribute.Find(id);

            return item;
        }

        public ProviderAttribute AddProviderAttribute(ProviderAttribute item)
        {
            using var db = _factory.CreateDbContext();
            db.ProviderAttribute.Add(item);
            db.SaveChanges();
            return item;
        }

        public void DeleteProviderAttribute(int providerAttributeId)
        {
            using var db = _factory.CreateDbContext();
            var item = db.ProviderAttribute.Find(providerAttributeId);

            if (item == null) return;
            db.ProviderAttribute.Remove(item);
            db.SaveChanges();

        }

    }
}
