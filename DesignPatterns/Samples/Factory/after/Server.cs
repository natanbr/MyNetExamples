using System.Collections.Generic;

namespace Factory.After
{
    internal class Server
    {
        private readonly IInvoiceFactory _factory;

        public Server(IInvoiceFactory factory)
        {
            _factory = factory;
        }

        public void PrintDetailedInvoice(List<LineItem> lineItems)
        {
            IInvoice invoice = _factory.Create(lineItems);
            invoice.PrintDetail();
        }

        public void PrintInvoiceTotal(List<LineItem> lineItems)
        {
            IInvoice invoice = _factory.Create(lineItems);
            invoice.PrintTotal();
        }
    }
}