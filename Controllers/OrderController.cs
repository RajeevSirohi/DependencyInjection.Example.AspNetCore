using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/orders")]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _orderService1;
    private readonly IOrderService _orderService2;
    private readonly IUserSessionService _userSessionService;

    public OrdersController(
        IOrderService orderService1,
        IOrderService orderService2,
        IUserSessionService userSessionService)
    {
        _orderService1 = orderService1;
        _orderService2 = orderService2;
        _userSessionService = userSessionService;
    }

    [HttpGet("place")]
    public IActionResult PlaceOrders()
    {
        return Ok(new
        {
            Order1 = _orderService1.PlaceOrder(),
            Order2 = _orderService2.PlaceOrder(),
            Session = _userSessionService.GetSessionId()
        });
    }
}
