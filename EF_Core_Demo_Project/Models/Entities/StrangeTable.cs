using System;
using System.Collections.Generic;

#nullable disable

namespace EF_Core_Demo_Project.Models.Entities
{
    public partial class StrangeTable
    {
        public string Insert { get; set; }
        public string Update { get; set; }
        public int? Delete { get; set; }
    }
}
