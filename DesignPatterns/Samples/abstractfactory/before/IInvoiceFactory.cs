using System.Collections.Generic;

namespace AbstractFactory.Before
{
    internal interface IInvoiceFactory
    {
        IInvoice Create(List<LineItem> lineItems);
    }
}