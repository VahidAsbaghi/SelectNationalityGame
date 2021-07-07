using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace SelectNationality.Domain.Entities
{
    public class User
    {
        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
