using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using OpenEugene.Module.LittleHelpBook.Models;

namespace OpenEugene.Module.LittleHelpBook.Repository
{
    public partial class LittleHelpBookRepository
    {

        public List<PhoneNumber> GetPhoneNumbersByProviderId(int providerId, bool tracking = false) {
            // get a list of Phones for a provider
            var nums = from p in _db.PhoneNumber
                        where p.ProviderId == providerId
                        select p;
            return nums.ToList();
        }

        public PhoneNumber GetPhoneNumberByPhoneNumberId(int phoneNumberId) {
            return GetPhoneNumber(phoneNumberId, true);
        }

        public PhoneNumber GetPhoneNumber(int phoneNumberId, bool tracking) {
            return tracking ? _db.PhoneNumber.Find(phoneNumberId) : _db.PhoneNumber.AsNoTracking().FirstOrDefault(item => item.PhoneNumberId == phoneNumberId);
        }

        public PhoneNumber AddPhoneNumber(PhoneNumber item) {
            _db.PhoneNumber.Add(item);
            _db.SaveChanges();
            return item;
        }

        public PhoneNumber UpdatePhoneNumber(PhoneNumber phoneNumberId) {
            _db.Entry(phoneNumberId).State = EntityState.Modified;
            _db.SaveChanges();
            return phoneNumberId;
        }

        public void DeletePhoneNumber(int phoneNumberId) {
            var item = _db.PhoneNumber.Find(phoneNumberId);

            if (item == null) return;
            _db.PhoneNumber.Remove(item);
            _db.SaveChanges();
        }
    }
}