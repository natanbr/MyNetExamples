namespace Visitor.Before
{
    internal interface ILineItem
    {
        string Description { get; }
        decimal Value { get; }
    }
}