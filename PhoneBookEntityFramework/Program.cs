using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PhoneBookEntityFramework
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ContactRepository contactsRepository = new ContactRepository();
            contactsRepository.Create(new ContactModel() { Id = 15, Name = "Fabi", PhoneNumber = "+541234213" });
          //  contactsRepository.Delete(contactsRepository.GetById(12));
          foreach(var c in contactsRepository.Search(new ContactParameters()))
            Console.WriteLine(c.ToString());
        }
    }
}