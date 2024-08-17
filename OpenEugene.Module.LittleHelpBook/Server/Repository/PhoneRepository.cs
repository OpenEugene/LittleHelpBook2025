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
            using var db = _factory.CreateDbContext();
            var nums = from p in db.PhoneNumber
                        where p.ProviderId == providerId
                        select p;
            return nums.ToList();
        }

        public PhoneNumber GetPhoneNumberByPhoneNumberId(int phoneNumberId) {
            return GetPhoneNumber(phoneNumberId, true);
        }

        public PhoneNumber GetPhoneNumber(int phoneNumberId, bool tracking) {
            using var db = _factory.CreateDbContext();
            return tracking 
                ? db.PhoneNumber.Find(phoneNumberId) 
                : db.PhoneNumber.AsNoTracking().FirstOrDefault(item => item.PhoneNumberId == phoneNumberId);
        }

        public PhoneNumber AddPhoneNumber(PhoneNumber item) {
            using var db = _factory.CreateDbContext(); 
            db.PhoneNumber.Add(item);
            db.SaveChanges();
            return item;
        }

        public PhoneNumber UpdatePhoneNumber(PhoneNumber phoneNumberId) {
            using var db = _factory.CreateDbContext(); 
            db.Entry(phoneNumberId).State = EntityState.Modified;
            db.SaveChanges();
            return phoneNumberId;
        }

        public void DeletePhoneNumber(int phoneNumberId) {
            using var db = _factory.CreateDbContext(); 
            var item = db.PhoneNumber.Find(phoneNumberId);

            if (item == null) return;
            db.PhoneNumber.Remove(item);
            db.SaveChanges();
        }
    }
}