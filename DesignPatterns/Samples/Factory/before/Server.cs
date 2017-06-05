using System.Collections.Generic;

namespace Factory.Before
{
    internal class Server
    {
        private readonly Currency _currency;

        public Server(Currency currency)
        {
            _currency = currency;
        }

        public void PrintDetailedInvoice(List<LineItem> lineItems)
        {
            if (_currency == Currency.Shekels)
            {
                var invoice = new InvoiceInShekels(lineItems);
                invoice.PrintDetail();
            }
            else
            {
                var invoice = new InvoiceInDollars(lineItems);
                invoice.PrintDetail();
            }
        }

        public void PrintInvoiceTotal(List<LineItem> lineItems)
        {
            if (_currency == Currency.Shekels)
            {
                var invoice = new InvoiceInShekels(lineItems);
                invoice.PrintTotal();
            }
            else
            {
                var invoice = new InvoiceInDollars(lineItems);
                invoice.PrintTotal();
            }
        }
    }
}