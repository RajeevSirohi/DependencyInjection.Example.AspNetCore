namespace DependencyInjection.Example.AspNetCore.Interfaces
{
    public interface IOrderService
    {
        string PlaceOrder();
    }

    public interface IUserSessionService
    {
        string GetSessionId();
    }
}