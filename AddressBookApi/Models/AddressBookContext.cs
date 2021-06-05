using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddressBookApi.Models
{
    public class AddressBookContext : DbContext
    {
        //public DbSet<City> Cities { get; set; }
        //public DbSet<Person> People { get; set; }
        public DbSet<AddressModel> Addresses { get; set; }
        public AddressBookContext( DbContextOptions options) : base(options)
        {
        }
        
    }
}
