using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SelectNationality.Models
{
    public class Person
    {
        public string Nationality { get; set; }
        public string Name { get; set; }
        public string ImageUri { get; set; }
    }

    public enum Nationality
    {
        Japanese,
        Chinese,
        Korean,
        Thai
    }
}
