using System;

namespace Visitor.Before
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var order = new Order();

            order.AddLineItem(new ProductItem {Description = "Potatoes", Value = 5.4m});
            order.AddLineItem(new ProductItem {Description = "Milk", Value = 3});
            order.AddLineItem(new ProductItem {Description = "Bread", Value = 6});
            order.AddLineItem(new DiscountItem {Description = "Member Discount", Value = 0.1m});
            order.AddLineItem(new CouponItem {Description = "Gift Voucher", Value = 5m, ExpirationDate = GetTomorrow()});

            if (order.GetTotal() == 8.46m)
                Console.WriteLine("Passed");
            else
                Console.WriteLine("Failed");
        }

        private static DateTime GetTomorrow()
        {
            return DateTime.Today + TimeSpan.FromDays(1);
        }
    }
}