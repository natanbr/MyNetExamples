using System;

namespace Visitor.After
{
    internal class CouponItem : ILineItem
    {
        public DateTime ExpirationDate { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }

        public void Accept(IAddItemVisitor visitor)
        {
            visitor.AddItem(this);
        }
    }
}