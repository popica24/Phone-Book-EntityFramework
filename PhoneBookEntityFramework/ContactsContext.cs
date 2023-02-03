using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.Extensions.Options;

namespace PhoneBookEntityFramework
{
    internal class ContactsContext : DbContext
    {
        public DbSet<ContactModel> Contacts { get; set; }
        public string DbPath { get; }

        public ContactsContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "contacts.db");
           Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder opt) => opt.UseSqlite($"Data Source = {DbPath}");
    }
}
