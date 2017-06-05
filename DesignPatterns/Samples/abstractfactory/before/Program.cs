using System.Collections.Generic;

namespace AbstractFactory.Before
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var server = new Server(new DollarInvoiceFactory());

            server.PrintDetailedInvoice(new List<LineItem>
            {
                new LineItem {Product = "Peas", Price = new Price {Value = 10, Currency = Currency.Shekels}},
                new LineItem {Product = "Rice", Price = new Price {Value = 5, Currency = Currency.Shekels}},
            });

            server.PrintInvoiceTotal(new List<LineItem>
            {
                new LineItem {Product = "Beans", Price = new Price {Value = 10, Currency = Currency.Shekels}},
                new LineItem {Product = "Tomatoes", Price = new Price {Value = 5, Currency = Currency.Shekels}},
            });
        }
    }
}