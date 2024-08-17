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

        public IEnumerable<Provider> GetProviders()
        {
            var list = _db.Provider.AsNoTracking();
            return list;
        }

        public Provider GetProvider(int id)
        {
            return GetProvider(id, true);
        }

        public Provider GetProvider(int id, bool tracking) {
            return tracking ? _db.Provider.Find(id) : _db.Provider.AsNoTracking().FirstOrDefault(item => item.ProviderId == id);
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
            _db.Provider.Add(item);
            _db.SaveChanges();
            return item;
        }

        public Provider UpdateProvider(Provider provider)
        {
            _db.Entry(provider).State = EntityState.Modified;
            _db.SaveChanges();
            return provider;
        }
        public ProviderViewModel UpdateProvider(ProviderViewModel providerVm)
        {
            // update provider
            _db.Entry<Provider>(providerVm as Provider).State = EntityState.Modified;

            //addresses
            foreach(var address in providerVm.Addresses)
            {
                if (address.AddressId == 0)
                {
                    // add new address
                    _db.Address.Add(address);

                    //I think we need to add a new ProviderAddress row too.
                }
                else
                {
                    // update existing address
                    _db.Entry<Address>(address).State = EntityState.Modified;
                }
            }
            //phones
            foreach (var phone in providerVm.PhoneNumbers) {
                if (phone.PhoneNumberId == 0) {
                    // add new address
                    _db.PhoneNumber.Add(phone);

                    //I think we need to add a new ProviderPhone row too.
                    
                }
                else {
                    // update existing address
                    _db.Entry<PhoneNumber>(phone).State = EntityState.Modified;
                }
            }

            _db.SaveChanges();

            return providerVm;
        }

        public void DeleteProvider(int providerId)
        {
            var item = _db.Provider.Find(providerId);

            if (item == null) return;
            _db.Provider.Remove(item);
            _db.SaveChanges();

        }

        // Provider Attributes could be a separate file, but it's all the same partial class

        public List<ProviderAttributeViewModel> GetProviderAttributesByProviderId(int providerId, bool tracking = false)
        {
            // get a list of attributes for a provider
            var list = from p in _db.ProviderAttribute
                       join a in _db.Attribute on p.AttributeId equals a.AttributeId
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
            // get a list of attributes for a provider
            var item = _db.ProviderAttribute.Find(id);

            return item;
        }

        public ProviderAttribute AddProviderAttribute(ProviderAttribute item)
        {
            _db.ProviderAttribute.Add(item);
            _db.SaveChanges();
            return item;
        }

        public void DeleteProviderAttribute(int providerAttributeId)
        {
            var item = _db.ProviderAttribute.Find(providerAttributeId);

            if (item == null) return;
            _db.ProviderAttribute.Remove(item);
            _db.SaveChanges();

        }

    }
}
