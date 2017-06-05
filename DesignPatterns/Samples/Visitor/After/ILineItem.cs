namespace Visitor.After
{
    internal interface ILineItem
    {
        string Description { get; }
        decimal Value { get; }

        void Accept(IAddItemVisitor visitor);
    }
}