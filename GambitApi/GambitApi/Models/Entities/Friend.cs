using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GambitApi.Models.Entities
{
    public class Friend
    {
        public int Id { get; set; }

        public Address Address { get; set; }

        public Details Details { get; set; }

        public string Number { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string Name2 { get; set; }

        public string Surname { get; set; }
    }
}