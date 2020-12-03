using System;
using System.Collections.Generic;

#nullable disable

namespace EF_Core_Demo_Project.Models.Entities
{
    public partial class Kontaktuppgifter
    {
        public int Id { get; set; }
        public string Kontakttyp { get; set; }
        public string Kontaktuppgift { get; set; }
        public int? PersonsId { get; set; }

        public virtual Person Persons { get; set; }
    }
}
