using System.Collections.Generic;
using System.Linq;
using Castle.Windsor;
using Castle.Windsor.Installer;

namespace CastleDemo
{
    class Customer
    {
        public string Name { get; set; }
        public int CreditPoints { get; set; }
    }

    class Database
    {
        private readonly Dictionary<int, Product> _productIdToProduct = new Dictionary<int, Product>();
        private readonly Dictionary<int, int> _productIdToQuantity = new Dictionary<int, int>();

        public int InsertProductAndReturnId (Product product, int quantity)
        {
            int lastId = _productIdToProduct.Keys.Last();
            int newId = lastId + 1;
            
            _productIdToProduct.Add(newId, product);
            _productIdToQuantity.Add(newId, quantity);

            return newId;
        }

        public void DeleteProduct(int productId)
        {
            if (_productIdToQuantity.ContainsKey(productId))
            {
                _productIdToProduct.Remove(productId);
                _productIdToQuantity.Remove(productId);
            }
        }

        public void UpdateQuantity(int productId, int quantity)
        {
            if (_productIdToQuantity.ContainsKey(productId))
            {
                _productIdToQuantity[productId] = quantity;
            }
        }

        public int GetQuantity(int productId)
        {
            if (_productIdToQuantity.ContainsKey(productId))
            {
                return _productIdToQuantity[productId];
            }
            return -1;
        }

        public Product GetProductDetails(int productId)
        {
            if (_productIdToProduct.ContainsKey(productId))
            {
                return _productIdToProduct[productId];
            }
            return null;
        }
    }

    class Inventory
    {
        private Pricelist _priceList = new Pricelist();
        Database _productDatabase = new Database();

        public int GetQuantity(Product product)
        {
            return _productDatabase.GetQuantities().
        }
    }

    class Pricelist
    {

    }

    class DiscountCalculator
    {

    }

    class Supermarket
    {

    }

    class Product
    {
        public int ProductId { get; set; }
        public string Category { get; set; }
    }

    static class Program
    {
        class Database
        {
            void Write(string name, int value)
            {
            }

            int Read(string name)
            {
                return 0;
            }
        }

    
        private static void Main(string[] args)
        {
        }
    }
}