using System;
using System.Collections.Generic;

#nullable disable

namespace EF_Core_Demo_Project.Models.Entities
{
    public partial class HistoricalPrice
    {
        public int Id { get; set; }
        public int ProductsId { get; set; }
        public DateTime ChangeDate { get; set; }
        public decimal NewPrice { get; set; }
        public decimal OldPrice { get; set; }

        public virtual Product Products { get; set; }
    }
}
