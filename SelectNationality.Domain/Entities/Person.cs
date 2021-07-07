using System;
using System.Collections.Generic;
using System.Text;
using SelectNationality.Domain.ValueObjects;

namespace SelectNationality.Domain.Entities
{
    public class Person
    {
        public Guid PersonId { get; set; }
        public int ImageId { get; set; }
        public string Name { get; set; }
        public virtual Nationality Nationality { get; set; }
    }
}
