using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ConsoleApp
{
    public class PersonContext : DbContext
    {
        public DbSet<Person> people { get; set; }

        public PersonContext():base("con") { }
    }
}
