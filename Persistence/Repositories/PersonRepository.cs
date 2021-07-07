using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Persistence.DataModels;

namespace Persistence.Repositories
{
    public class PersonRepository
    {
        private readonly PersonDataContext _personContext;

        public PersonRepository(PersonDataContext personContext)
        {
            _personContext = personContext;
        }
        public void Add(Person person)
        {
            _personContext.Add(person);
        }

        public IQueryable<Person> GetAll()
        {
            return _personContext.Set<Person>();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _personContext.SaveChangesAsync();
        }
        //Todo add async methods
    }
}
