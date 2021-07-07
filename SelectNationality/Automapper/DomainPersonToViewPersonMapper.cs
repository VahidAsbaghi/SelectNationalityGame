using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using SelectNationality.Domain.Entities;

namespace SelectNationality.Automapper
{
    public class DomainPersonToViewPersonMapper : IMapper<Person, Models.Person>
    {
        public Models.Person Map(Person sourceModel)
        {
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<Person, Models.Person>()
                    .ForMember(destPerson =>
                        destPerson.ImageUri, sourcePerson =>
                        sourcePerson.MapFrom(p => $"images/{p.ImageId}.jpg")).
                    ForMember(destPerson=>
                        destPerson.Nationality,sourcePerson=>
                        sourcePerson.MapFrom(n=>n.Nationality.Name)));
            ;

            var mapper = config.CreateMapper();
            var viewModelPerson = mapper.Map<Models.Person>(sourceModel);
            return viewModelPerson;
        }
    }
}
