using System;

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
        private readonly ApplicationDbContext _dbContext;

        public CartService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddToCart(int userId, string productName)
        {
            var cart = _dbContext.Carts.Include(c => c.Items).FirstOrDefault(c => c.UserId == userId);
            if (cart == null)
            {
                cart = new Cart { UserId = userId };
                _dbContext.Carts.Add(cart);
            }

            cart.Items.Add(new CartItem { ProductName = productName });
            _dbContext.SaveChanges(); // Save changes to DB
        }

        public List<string> GetCartItems(int userId)
        {
            var cart = _dbContext.Carts.Include(c => c.Items).FirstOrDefault(c => c.UserId == userId);
            return cart?.Items.Select(i => i.ProductName).ToList() ?? new List<string>();
        }
    }


    public class DiscountService : IDiscountService
    {
        private readonly IUserSessionService _userSessionService;

        public DiscountService(IUserSessionService userSessionService) => _userSessionService = userSessionService;

        public double ApplyDiscount(double totalAmount)
        {
            Console.WriteLine($"Discount applied for Session: {_userSessionService.GetSessionId()}");
            return totalAmount * 0.9; // 10% discount
        }
    }

    public class OrderService : IOrderService
    {
        private readonly IDiscountService _discountService;
        private readonly IUserSessionService _userSessionService;
        private readonly string _orderInstanceId;

        public OrderService(IDiscountService discountService, IUserSessionService userSessionService)
        {
            _discountService = discountService;
            _userSessionService = userSessionService;
            _orderInstanceId = Guid.NewGuid().ToString(); // Unique ID per OrderService instance
        }

        public string PlaceOrder()
        {
            decimal totalAmount = 1000;
            decimal discountedAmount = (decimal)_discountService.ApplyDiscount((double)totalAmount);

            return $"Order {_orderInstanceId} placed with Session {_userSessionService.GetSessionId()} and final price {discountedAmount}.";
        }
    }


}
