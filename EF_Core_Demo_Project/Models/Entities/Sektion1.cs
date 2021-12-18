using System;
using System.Collections.Generic;

#nullable disable

namespace EF_Core_Demo_Project.Models.Entities
{
    public partial class Sektion1
    {
        public int Id { get; set; }
        public int? Sektion { get; set; }
        public string Titel { get; set; }
        public string Namn { get; set; }
        public decimal Lön { get; set; }
        public int? ChefsId { get; set; }
    }
}
