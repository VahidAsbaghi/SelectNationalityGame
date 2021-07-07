using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Persistence.Repositories;
using SelectNationality.Domain.Entities;
using SelectNationality.Domain.Interfaces;
using SelectNationality.Domain.ModelMapper;

namespace SelectNationality.Domain.Services
{
    public class QueryPersonService:IQueryPerson
    {
        private readonly PersonRepository _personRepository;

        public QueryPersonService(PersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public IEnumerable<Person> GetAll()
        {
            var dataPersons = _personRepository.GetAll();
            foreach (var person in dataPersons)
            {
                var personEntity = DataEntityMapper.MapPerson(person);
                yield return personEntity;
            }
        }
    }
}
