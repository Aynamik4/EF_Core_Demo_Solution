/*
1. Core project (Console, MVC, WinForms, WPF)
2. EF NuGet installation -- Wizard saknas.
3. EF-Scaffolding - D.v.s. generera Context och Entity klasser istället för wizard.
4. Include (Child tables)
5. Triggers now supported.

EF NuGet installation
=====================
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools

EF-Scaffolding - D.v.s. generera Context och Entity klasser.
============================================================
Scaffold-DbContext "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Mercury;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" Microsoft.EntityFrameworkCore.SqlServer -OutputDir "Models/Entities" -Context "MercuryContext" -Force
*/
using EF_Core_Demo_Project.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EF_Core_Demo_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            MercuryContext mercury = new MercuryContext();

            foreach (var product in mercury.Products.Include("HistoricalPrices"))
            {
                Console.WriteLine(product);

                foreach (var price in product.HistoricalPrices.OrderByDescending(hp => hp.ChangeDate))
                    Console.WriteLine($"\t{price.OldPrice}");

                Console.WriteLine("----------------------------------------------");
            }

            //Product aProduct = mercury.Products.Find(6);
            //aProduct.Price *= 1.25m;
            //mercury.SaveChanges();

            //foreach (var hp in mercury.HistoricalPrices.Where(p => p.ProductsId == 6))
            //{
            //    Console.WriteLine($"{hp.ProductsId} {hp.NewPrice}");
            //}
        }
    }
}
