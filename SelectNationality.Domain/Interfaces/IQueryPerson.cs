using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SelectNationality.Domain.Entities;

namespace SelectNationality.Domain.Interfaces
{
    public interface IQueryPerson
    {
        IEnumerable<Person> GetAll();
    }
}
