using SalesDatePrediction.Domain.Models;

namespace SalesDatePrediction.Test.Core.ModelsBuilder
{
    public class ProductBuilder
    {
        private int _productId;
        private string _productName;
        private int _supplierId;
        private int _categoryId;
        private decimal _unitPrice;
        private bool _discontinued;

        public ProductBuilder SetProductId(int productId)
        {
            _productId = productId;
            return this;
        }

        public ProductBuilder SetProductName(string productName)
        {
            _productName = productName;
            return this;
        }

        public ProductBuilder SetSupplierId(int supplierId)
        {
            _supplierId = supplierId;
            return this;
        }

        public ProductBuilder SetCategoryId(int categoryId)
        {
            _categoryId = categoryId;
            return this;
        }

        public ProductBuilder SetUnitPrice(decimal unitPrice)
        {
            _unitPrice = unitPrice;
            return this;
        }

        public ProductBuilder SetDiscontinued(bool discontinued)
        {
            _discontinued = discontinued;
            return this;
        }

        public Product Build()
        {
            return new Product
            {
                ProductId = _productId,
                ProductName = _productName,
                SupplierId = _supplierId,
                CategoryId = _categoryId,
                UnitPrice = _unitPrice,
                Discontinued = _discontinued
            };
        }

        public Product BuildDefault()
        {
            return new Product
            {
                ProductId = 1,
                ProductName = "Default Product",
                SupplierId = 1,
                CategoryId = 1,
                UnitPrice = 9.99m,
                Discontinued = false
            };
        }

        public List<Product> BuildDefaultList()
        {
            var defaultProduct = BuildDefault();
            return new List<Product> { defaultProduct };
        }
    }
}
