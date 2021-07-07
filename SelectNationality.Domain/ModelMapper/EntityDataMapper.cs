using System;
using System.Collections.Generic;
using System.Text;
using Persistence.DataModels;

namespace SelectNationality.Domain.ModelMapper
{
    public class EntityDataMapper
    {
        public static Person MapPerson(Entities.Person person)
        {
            return new Person() {ImageId = person.ImageId, Nationality = person.Nationality.Name};
        }
    }
}
