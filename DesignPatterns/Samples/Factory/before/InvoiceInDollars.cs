using System;
using System.Collections.Generic;
using System.Linq;

namespace Factory.Before
{
    internal class InvoiceInDollars
    {
        private readonly List<LineItem> _lineItems;

        public InvoiceInDollars(List<LineItem> lineItems)
        {
            _lineItems = lineItems;
        }

        public void PrintTotal()
        {
            decimal totalPrice = _lineItems.Sum(lineItem => lineItem.Price);

            Console.WriteLine("Invoice Summary: total = {0} USD", totalPrice);
        }

        public void PrintDetail()
        {
            Console.WriteLine("Detailed USD Invoice:");

            decimal totalPrice = 0m;

            foreach (LineItem lineItem in _lineItems)
            {
                Console.WriteLine("\t{0} : {1}", lineItem.Product, lineItem.Price);
                totalPrice += lineItem.Price;
            }

            Console.WriteLine("Total : {0} USD", totalPrice);
        }
    }
}