using PointOfScale.DTOs;
using PointOfScale.Presentation.Abstract;
using System;
using System.Collections.Generic;

namespace PointOfScale.ConsoleApp.Main
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
            var products = new List<ProductDTO>
            {
                new ProductDTO { Code = "A", RetailPrice = 1.25m, VolumePrice = 3m, VolumeQuantity = 3 },
                new ProductDTO { Code = "B", RetailPrice = 4.25m },
                new ProductDTO { Code = "C", RetailPrice = 1m, VolumePrice = 5m, VolumeQuantity = 6 },
                new ProductDTO { Code = "D", RetailPrice = 0.75m}
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
