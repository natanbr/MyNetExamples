namespace Visitor.Before
{
    internal class DiscountItem : ILineItem
    {
        public string Description { get; set; }
        public decimal Value { get; set; }
    }
}