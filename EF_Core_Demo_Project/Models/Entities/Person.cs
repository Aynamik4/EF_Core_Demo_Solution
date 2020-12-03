using System;
using System.Collections.Generic;

#nullable disable

namespace EF_Core_Demo_Project.Models.Entities
{
    public partial class Person
    {
        public Person()
        {
            Kontaktuppgifters = new HashSet<Kontaktuppgifter>();
            P2as = new HashSet<P2a>();
        }

        public int Id { get; set; }
        public string Personnr { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? YearOfBirth { get; set; }

        public virtual ICollection<Kontaktuppgifter> Kontaktuppgifters { get; set; }
        public virtual ICollection<P2a> P2as { get; set; }
    }
}
