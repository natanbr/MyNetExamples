using System.Collections.Generic;

namespace AbstractFactory.After
{
    internal class ShekelInvoiceFactory : IInvoiceFactory
    {
        public IInvoice CreateInvoice(List<LineItem> lineItems)
        {
            return new InvoiceInShekels(lineItems);
        }

        public Price CreatePrice(decimal value)
        {
            return new Price {Currency = Currency.Shekels, Value = value};
        }
    }
}