using Common;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IContactService
    {
        void AddContact(ContactBusinessModel contact);
        List<Contact> GetContacts();
        string UpdateContact(ContactBusinessModel contact);
        bool UpdateStatus(int id, bool status,int modifiedByUserId);
    }
}
