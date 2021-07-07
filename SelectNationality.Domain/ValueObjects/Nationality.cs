using System.Collections.Generic;
using SelectNationality.Domain.Entities;

namespace SelectNationality.Domain.ValueObjects
{
    public class Nationality
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public virtual ICollection<Person> Person { get; set; }
    }

   
}
