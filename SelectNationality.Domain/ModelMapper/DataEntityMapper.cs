using System;
using System.Collections.Generic;
using System.Text;
using SelectNationality.Domain.Entities;
using SelectNationality.Domain.ValueObjects;

namespace SelectNationality.Domain.ModelMapper
{
    public class DataEntityMapper
    {
        public static Person MapPerson(Persistence.DataModels.Person person)
        {
            return new Person() { ImageId = person.ImageId, Nationality = new Nationality(){Name = person.Nationality },PersonId = new Guid()};
        }
    }
}
