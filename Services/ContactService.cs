using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using Entities;
using Repository;

namespace Services
{
    public class ContactService : IContactService
    {
        private static Repository<Contact> _contactRepo;

        static ContactService() => _contactRepo = new Repository<Contact>(new ApplicationDbContext());

        public void AddContact(ContactBusinessModel contact)
        {
            var contactEntity = new Contact()
            {
                FirstName = contact.FirstName,
                LastName = contact.LastName,
                Email = contact.Email,
                PhoneNumber = contact.PhoneNumber,
                Status = true,
                CreatedByUserId = contact.CreatedByUserId,
                CreatedDate = DateTime.Now,
            };
            _contactRepo.Insert(contactEntity);
        }
        public List<Contact> GetContacts()
        {
            return _contactRepo.GetAll().Where(c => c.Status).ToList<Contact>();
        }
        public string UpdateContact(ContactBusinessModel contact)
        {
            var contactEntity = new Contact();
            if (contact.Id != null)
            {
                contactEntity = _contactRepo.Get(contact.Id.Value);
            }

            contactEntity.FirstName = contact.FirstName;
            contactEntity.LastName = contact.LastName;
            contactEntity.Email = contact.Email;
            contactEntity.PhoneNumber = contact.PhoneNumber;
            contactEntity.ModifiedByUserId = contact.ModifiedByUserId;
            contactEntity.ModifiedDate = DateTime.Now;

            _contactRepo.Update(contactEntity);
            return "Successfully Updated";
        }

        public bool UpdateStatus(int id, bool status, int modifiedByUserId)
        {
            var contactEntity = _contactRepo.Get(id);
            if (contactEntity != null)
            {
                contactEntity.Status = status;
                contactEntity.ModifiedByUserId = modifiedByUserId;
                contactEntity.ModifiedDate = DateTime.Now;
                _contactRepo.Update(contactEntity);
                return true;
            }
            return false;

            return true;
        }
    }
}
