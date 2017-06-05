using System;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Before
{
    internal class InvoiceInShekels
    {
        private readonly List<LineItem> _lineItems;

        public InvoiceInShekels(List<LineItem> lineItems)
        {
            _lineItems = lineItems;
        }

        public void PrintTotal()
        {
            decimal totalPrice = _lineItems.Sum(lineItem => lineItem.Price);

            Console.WriteLine("Invoice Summary: total = {0} NIS", totalPrice);
        }

        public void PrintDetail()
        {
            Console.WriteLine("Detailed NIS Invoice:");

            decimal totalPrice = 0m;

            foreach (LineItem lineItem in _lineItems)
            {
                Console.WriteLine("\t{0} : {1}", lineItem.Product, lineItem.Price);
                totalPrice += lineItem.Price;
            }

            Console.WriteLine("Total : {0} NIS", totalPrice);
        }
    }
}