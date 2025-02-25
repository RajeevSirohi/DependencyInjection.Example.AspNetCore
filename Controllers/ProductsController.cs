using DependencyInjection.Example.AspNetCore.Interfaces;
using Microsoft.AspNetCore.Mvc;

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

    [HttpGet("add-to-cart")]
    public IActionResult AddToCart()
    {
        string product = _productService.GetProduct(); // Gets a new instance every time
        _cartService.AddToCart(product); // Adds item to the cart
        return Ok(new { Message = $"{product} added to cart!" });
    }

    [HttpGet("cart-items")]
    public IActionResult GetCartItems()
    {
        var items = _cartService.GetCartItems(); // Retrieves cart items
        return Ok(new { CartItems = items });
    }

    [HttpGet("checkout")]
    public IActionResult Checkout()
    {
        var items = _cartService.GetCartItems();
        double total = items.Count * 1000; // Assume each item is ₹1000
        double finalAmount = _discountService.ApplyDiscount(total); // Apply discount
        return Ok(new { TotalAmount = total, DiscountedAmount = finalAmount });
    }
}
