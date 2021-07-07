using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Persistence.DataModels;

namespace Persistence
{
    public class PersonDataContext:DbContext
    {
        public PersonDataContext(DbContextOptions<PersonDataContext> options):base(options)
        {
            
        }

        public DbSet<Person> Persons { get; set; }
    }
}
