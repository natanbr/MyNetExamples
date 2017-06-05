using System.Collections.Generic;

namespace AbstractFactory.After
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var factory = new DollarInvoiceFactory();

            var server = new Server(factory);

            server.PrintDetailedInvoice(new List<LineItem>
            {
                new LineItem {Product = "Peas", Price = factory.CreatePrice(10)},
                new LineItem {Product = "Rice", Price = factory.CreatePrice(5)}
            });

            server.PrintInvoiceTotal(new List<LineItem>
            {
                new LineItem {Product = "Beans", Price = factory.CreatePrice(10)},
                new LineItem {Product = "Tomatoes", Price = factory.CreatePrice(5)}
            });
        }
    }
}