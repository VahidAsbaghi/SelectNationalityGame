using System;
using System.Collections.Generic;
using System.Text;
using Persistence.Repositories;
using SelectNationality.Domain.Entities;
using SelectNationality.Domain.Interfaces;
using SelectNationality.Domain.ModelMapper;

namespace SelectNationality.Domain.Services
{
    public class CommandPersonService:ICommandPerson
    {
        private readonly PersonRepository _personRepository;

        public CommandPersonService(PersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public async void AddAsync(Person person)
        {
            _personRepository.Add(EntityDataMapper.MapPerson(person));
            await _personRepository.SaveChangesAsync();
        }

        public async void AddRangeAsync(IEnumerable<Person> people)
        {
            foreach (var person in people)
            {
                _personRepository.Add(EntityDataMapper.MapPerson(person));
            }
            await _personRepository.SaveChangesAsync();
        }
    }
}
