using System;
using System.Collections.Generic;

#nullable disable

namespace EF_Core_Demo_Project.Models.Entities
{
    public partial class Adressbok
    {
        public string Personnr { get; set; }
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
        public string Gata { get; set; }
        public string Ort { get; set; }
        public string Postnr { get; set; }
        public string Kontakttyp { get; set; }
        public string Kontaktuppgift { get; set; }
    }
}
