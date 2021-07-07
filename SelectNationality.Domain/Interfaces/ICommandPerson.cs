using System;
using System.Collections.Generic;
using System.Text;
using SelectNationality.Domain.Entities;

namespace SelectNationality.Domain.Interfaces
{
    public interface ICommandPerson
    {
        void AddAsync(Person person);
        void AddRangeAsync(IEnumerable<Person> people);
    }
}
