using System;
using System.Collections.Generic;
using System.Linq;

namespace AbstractFactory.After
{
    internal class InvoiceInDollars : IInvoice
    {
        private readonly List<LineItem> _lineItems;

        public InvoiceInDollars(List<LineItem> lineItems)
        {
            _lineItems = lineItems;
        }

        public void PrintTotal()
        {
            decimal totalPrice = _lineItems.Sum(lineItem => lineItem.Price.Value);

            Console.WriteLine("Invoice Summary: total = {0} USD", totalPrice);
        }

        public void PrintDetail()
        {
            Console.WriteLine("Detailed USD Invoice:");

            decimal totalPrice = 0m;

            foreach (LineItem lineItem in _lineItems)
            {
                Console.WriteLine("\t{0} : {1}", lineItem.Product, lineItem.Price);
                totalPrice += lineItem.Price.Value;
            }

            Console.WriteLine("Total : {0} USD", totalPrice);
        }
    }
}