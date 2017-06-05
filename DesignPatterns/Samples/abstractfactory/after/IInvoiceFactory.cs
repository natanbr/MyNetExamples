using System.Collections.Generic;

namespace AbstractFactory.After
{
    internal interface IInvoiceFactory
    {
        IInvoice CreateInvoice(List<LineItem> lineItems);
        Price CreatePrice(decimal value);
    }
}