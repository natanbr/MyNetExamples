using System;

namespace Visitor.Before
{
    internal class CouponItem : ILineItem
    {
        public DateTime ExpirationDate { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }
    }
}