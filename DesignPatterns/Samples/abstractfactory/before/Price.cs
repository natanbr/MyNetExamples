namespace AbstractFactory.Before
{
    internal class Price
    {
        public Currency Currency { get; set; }
        public decimal Value { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", Value, Currency);
        }
    }
}