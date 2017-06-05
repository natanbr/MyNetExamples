namespace Visitor.After
{
    internal class ProductItem : ILineItem
    {
        public string Description { get; set; }
        public decimal Value { get; set; }

        public void Accept(IAddItemVisitor visitor)
        {
            visitor.AddItem(this);
        }
    }
}