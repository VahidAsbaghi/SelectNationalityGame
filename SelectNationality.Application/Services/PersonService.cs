using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SelectNationality.Application.Contracts;
using SelectNationality.Domain.Entities;
using SelectNationality.Domain.Interfaces;
using SelectNationality.Domain.ModelMapper;
using SelectNationality.Domain.ValueObjects;

namespace SelectNationality.Application.Services
{
    public class PersonService:IPersonService
    {
        private readonly IQueryPerson _queryPersonService;
        private readonly ICommandPerson _commandPersonService;

        public PersonService(IQueryPerson queryPersonService,ICommandPerson commandPersonService)
        {
            _queryPersonService = queryPersonService;
            _commandPersonService = commandPersonService;
        }
        public IEnumerable<Person> GetAll()
        {
            var people = _queryPersonService.GetAll().ToList();
            return !people.Any() ? GenerateSamplePersons() : people;
        }

        public void Add(Person person)
        {
            _commandPersonService.AddAsync(person);
        }

        //TODO generate sample persons in seed database 
        private IEnumerable<Person> GenerateSamplePersons()
        {
            var people = new List<Person>
            {
                new Person()
                {
                    ImageId = 1, Nationality = new Nationality() {Name = "Japanese"}, PersonId = new Guid()
                },
                new Person()
                {
                    ImageId = 2, Nationality = new Nationality() {Name = "Japanese"}, PersonId = new Guid()
                },
                new Person()
                {
                    ImageId = 3, Nationality = new Nationality() {Name = "Japanese"}, PersonId = new Guid()
                },
                new Person()
                {
                    ImageId = 4, Nationality = new Nationality() {Name = "Japanese"}, PersonId = new Guid()
                },
                new Person()
                {
                    ImageId = 5, Nationality = new Nationality() {Name = "Chinese"}, PersonId = new Guid()
                },
                new Person()
                {
                    ImageId = 6, Nationality = new Nationality() {Name = "Chinese"}, PersonId = new Guid()
                },
                new Person()
                {
                    ImageId = 7, Nationality = new Nationality() {Name = "Chinese"}, PersonId = new Guid()
                },
                new Person()
                {
                    ImageId = 8, Nationality = new Nationality() {Name = "Chinese"}, PersonId = new Guid()
                },
                new Person()
                {
                    ImageId = 9, Nationality = new Nationality() {Name = "Korean"}, PersonId = new Guid()
                },
                new Person()
                {
                    ImageId = 10, Nationality = new Nationality() {Name = "Korean"}, PersonId = new Guid()
                },
                new Person()
                {
                    ImageId = 11, Nationality = new Nationality() {Name = "Korean"}, PersonId = new Guid()
                },
                new Person()
                {
                    ImageId = 12, Nationality = new Nationality() {Name = "Korean"}, PersonId = new Guid()
                },
                new Person()
                {
                    ImageId = 13, Nationality = new Nationality() {Name = "Thai"}, PersonId = new Guid()
                },
                new Person()
                {
                    ImageId = 14, Nationality = new Nationality() {Name = "Thai"}, PersonId = new Guid()
                },
                new Person()
                {
                    ImageId = 15, Nationality = new Nationality() {Name = "Thai"}, PersonId = new Guid()
                }
            };
            _commandPersonService.AddRangeAsync(people);
            
            return people;
        }
    }
}
