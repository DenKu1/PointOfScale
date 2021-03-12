using PointOfSale.Models;
using PointOfSale.Presentation.Abstract;
using System;
using System.Collections.Generic;

namespace PointOfSale.ConsoleApp.Main
{
    class ConsoleApplication
    {
        private readonly IPointOfSaleTerminal terminal;

        public ConsoleApplication(IPointOfSaleTerminal terminal)
        {
            this.terminal = terminal;
        }

        public void Run()
        {
            var products = new List<ProductModel>
            {
                new ProductModel { Code = "A", RetailPrice = 1.25m, VolumePrice = 3m, VolumeQuantity = 3 },
                new ProductModel { Code = "B", RetailPrice = 4.25m },
                new ProductModel { Code = "C", RetailPrice = 1m, VolumePrice = 5m, VolumeQuantity = 6 },
                new ProductModel { Code = "D", RetailPrice = 0.75m}
            };
            
            terminal.SetPricing(products);
            terminal.Scan("A");
            terminal.Scan("B");
            terminal.Scan("C");
            terminal.Scan("D");
            terminal.Scan("A");
            terminal.Scan("B");
            terminal.Scan("A");

            Console.WriteLine($"ABCDABA = 13.25? Result: {terminal.CalculateTotal()}");   
            
            Console.ReadLine();
        }
    }
}
