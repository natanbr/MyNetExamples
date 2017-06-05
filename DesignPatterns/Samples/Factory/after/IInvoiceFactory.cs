using System.Collections.Generic;

namespace Factory.After
{
    internal interface IInvoiceFactory
    {
        IInvoice Create(List<LineItem> lineItems);
    }
}