using System;
using System.Collections.Generic;

#nullable disable

namespace EF_Core_Demo_Project.Models.Entities
{
    public partial class Address
    {
        public Address()
        {
            P2as = new HashSet<P2a>();
        }

        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public DateTime LastUpdated { get; set; }

        public virtual ICollection<P2a> P2as { get; set; }
    }
}
