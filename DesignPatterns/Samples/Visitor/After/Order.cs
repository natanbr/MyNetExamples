using System;

namespace Visitor.After
{
    internal class Order : IAddItemVisitor
    {
        private decimal _discount;
        private decimal _totalPrice;

        public void AddItem(DiscountItem discountItem)
        {
            _discount += discountItem.Value;
        }

        public void AddItem(ProductItem productItem)
        {
            _totalPrice += productItem.Value;
        }

        public void AddItem(CouponItem couponItem)
        {
            if (couponItem.ExpirationDate > DateTime.Now)
            {
                _totalPrice -= couponItem.Value;
            }
        }

        public void AddLineItem(ILineItem lineItem)
        {
            lineItem.Accept(this);
        }

        public decimal GetTotal()
        {
            return _totalPrice*(1 - _discount);
        }
    }
}