using System.Collections.Generic;

namespace AbstractFactory.After
{
    internal class DollarInvoiceFactory : IInvoiceFactory
    {
        public IInvoice CreateInvoice(List<LineItem> lineItems)
        {
            return new InvoiceInDollars(lineItems);
        }

        public Price CreatePrice(decimal value)
        {
            return new Price {Currency = Currency.Dollars, Value = value};
        }
    }
}