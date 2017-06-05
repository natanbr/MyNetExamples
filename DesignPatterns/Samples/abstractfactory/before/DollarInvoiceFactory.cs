using System.Collections.Generic;

namespace AbstractFactory.Before
{
    internal class DollarInvoiceFactory : IInvoiceFactory
    {
        public IInvoice Create(List<LineItem> lineItems)
        {
            return new InvoiceInDollars(lineItems);
        }
    }
}