using System.Collections.Generic;

namespace Factory.After
{
    internal class ShekelInvoiceFactory : IInvoiceFactory
    {
        public IInvoice Create(List<LineItem> lineItems)
        {
            return new InvoiceInShekels(lineItems);
        }
    }
}