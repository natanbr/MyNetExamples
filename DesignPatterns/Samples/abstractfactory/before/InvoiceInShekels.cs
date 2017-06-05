using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractFactory.Before
{
    internal class InvoiceInShekels : IInvoice
    {
        private readonly List<LineItem> _lineItems;

        public InvoiceInShekels(List<LineItem> lineItems)
        {
            _lineItems = lineItems;
        }

        public void PrintTotal()
        {
            decimal totalPrice = _lineItems.Sum(lineItem => lineItem.Price.Value);

            Console.WriteLine("Invoice Summary: total = {0} NIS", totalPrice);
        }

        public void PrintDetail()
        {
            Console.WriteLine("Detailed NIS Invoice:");

            decimal totalPrice = 0m;

            foreach (LineItem lineItem in _lineItems)
            {
                Console.WriteLine("\t{0} : {1}", lineItem.Product, lineItem.Price);
                totalPrice += lineItem.Price.Value;
            }

            Console.WriteLine("Total : {0} NIS", totalPrice);
        }
    }
}