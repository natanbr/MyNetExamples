namespace Visitor.Before
{
    internal class ProductItem : ILineItem
    {
        public string Description { get; set; }
        public decimal Value { get; set; }
    }
}