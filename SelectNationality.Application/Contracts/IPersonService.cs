using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SelectNationality.Domain.Entities;

namespace SelectNationality.Application.Contracts
{
    public interface IPersonService
    {
        IEnumerable<Person> GetAll();
        void Add(Person person);
    }
}
