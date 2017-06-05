using System.Collections.Generic;

namespace AbstractFactory.Before
{
    internal class ShekelInvoiceFactory : IInvoiceFactory
    {
        public IInvoice Create(List<LineItem> lineItems)
        {
            return new InvoiceInShekels(lineItems);
        }
    }
}