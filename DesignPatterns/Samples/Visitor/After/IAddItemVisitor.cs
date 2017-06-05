namespace Visitor.After
{
    internal interface IAddItemVisitor
    {
        void AddItem(DiscountItem discountItem);
        void AddItem(ProductItem productItem);
        void AddItem(CouponItem couponItem);
    }
}