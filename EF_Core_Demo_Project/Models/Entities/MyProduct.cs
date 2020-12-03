using System;
using System.Collections.Generic;
using System.Text;

namespace EF_Core_Demo_Project.Models.Entities
{
    public partial class Product
    {
        public override string ToString()
        {
            return $"{Id} {ProductName} {Price}";
        }
    }
}
