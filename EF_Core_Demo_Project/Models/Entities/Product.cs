using System;
using System.Collections.Generic;

#nullable disable

namespace EF_Core_Demo_Project.Models.Entities
{
    public partial class Product
    {
        public Product()
        {
            HistoricalPrices = new HashSet<HistoricalPrice>();
        }

        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<HistoricalPrice> HistoricalPrices { get; set; }
    }
}
