using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.Example.AspNetCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShopController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ICartService _cartService;
        private readonly IDiscountService _discountService;

        public ShopController(IProductService productService, ICartService cartService, IDiscountService discountService)
        {
            _productService = productService;
            _cartService = cartService;
            _discountService = discountService;
        }

        [HttpPost("add-to-cart/{userId}")]
        public IActionResult AddToCart(int userId)
        {
            _cartService.AddToCart(userId, "Laptop");
            return Ok(new { Message = "Laptop added to cart!" });
        }

        [HttpGet("cart-items/{userId}")]
        public IActionResult GetCartItems(int userId)
        {
            var items = _cartService.GetCartItems(userId);
            return Ok(new { CartItems = items });
        }

        [HttpGet("checkout/{userId}")]
        public IActionResult Checkout(int userId)
        {
            var items = _cartService.GetCartItems(userId);
            double total = items.Count * 1000; // Assume each item is ₹1000
            double finalAmount = _discountService.ApplyDiscount(total); // Apply discount
            return Ok(new { TotalAmount = total, DiscountedAmount = finalAmount });
        }
    }
}