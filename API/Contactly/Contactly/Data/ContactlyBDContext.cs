using Contactly.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace Contactly.Data
{
    public class ContactlyBDContext : DbContext
    {
        public ContactlyBDContext(DbContextOptions options) : base(options) 
        {

        }

        public DbSet<Contact> Contacts { get; set; }

    }
}
