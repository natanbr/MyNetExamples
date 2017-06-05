using System.Collections.Generic;

namespace Factory.After
{
    internal class DollarInvoiceFactory : IInvoiceFactory
    {
        public IInvoice Create(List<LineItem> lineItems)
        {
            return new InvoiceInDollars(lineItems);
        }
    }
}