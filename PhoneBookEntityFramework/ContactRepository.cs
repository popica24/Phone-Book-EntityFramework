using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBookEntityFramework
{
    public class ContactRepository : IContacts<ContactModel,ContactParameters>
    {
        ContactsContext DbContext = new ContactsContext();

        public int Create(ContactModel entity)
        {
            DbContext.Add(entity);
            DbContext.SaveChanges();
            return entity.Id;
        }

        public void Delete(ContactModel entity)
        {
            DbContext.Remove(entity);
            DbContext.SaveChanges();
        }

        public ContactModel GetById(int entityId)
        {
            return DbContext.Contacts.Where(c => c.Id == entityId).First();
        }

        public List<ContactModel> Search(ContactParameters p)
        {
            if (!string.IsNullOrEmpty(p.Name))
                return DbContext.Contacts.Where(c => c.Name.Equals(p)).ToList();
            if (!string.IsNullOrEmpty(p.PhoneNumber))
                return DbContext.Contacts.Where(c => c.PhoneNumber.Equals(p)).ToList();
            return DbContext.Contacts.ToList();
        }

        public void Update(ContactModel C ,ContactParameters p)
        {
            if (!string.IsNullOrEmpty(p.Name))
            {
                C.Name = p.Name;
            }
            if (!string.IsNullOrEmpty(p.PhoneNumber))
            {
                C.PhoneNumber = p.PhoneNumber;
            }
        }
    }
}
