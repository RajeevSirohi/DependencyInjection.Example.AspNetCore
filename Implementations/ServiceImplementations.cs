using DependencyInjection.Example.AspNetCore.Interfaces;

namespace DependencyInjection.Example.AspNetCore.Implementations
{
    public class ProductService : IProductService
    {
        public string GetProduct()
        {
            return "Laptop";
        }
    }

    public class CartService : ICartService
    {
        private readonly List<string> _cartItems = new List<string>();

        public void AddToCart(string product)
        {
            _cartItems.Add(product);
        }

        public List<string> GetCartItems()
        {
            return _cartItems;
        }
    }

    public class DiscountService : IDiscountService
    {
        private readonly double _discountRate = 0.10; // 10% discount

        public double ApplyDiscount(double total)
        {
            return total - (total * _discountRate);
        }
    }

}
