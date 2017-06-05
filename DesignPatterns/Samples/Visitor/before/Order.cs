using System;

namespace Visitor.Before
{
    internal class Order
    {
        private decimal _discount;
        private decimal _totalPrice;

        public void AddLineItem(ILineItem lineItem)
        {
            if (lineItem is DiscountItem)
                _discount += lineItem.Value;

            if (lineItem is ProductItem)
                _totalPrice += lineItem.Value;

            var couponItem = lineItem as CouponItem;
            if (couponItem != null)
            {
                if (couponItem.ExpirationDate > DateTime.Now)
                {
                    _totalPrice -= couponItem.Value;
                }
            }
        }

        public decimal GetTotal()
        {
            return _totalPrice*(1 - _discount);
        }
    }
}