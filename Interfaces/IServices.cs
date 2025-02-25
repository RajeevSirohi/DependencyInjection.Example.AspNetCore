namespace DependencyInjection.Example.AspNetCore.Interfaces
{
    public interface IProductService
    {
        string GetProduct();
    }

    public interface ICartService
    {
        void AddToCart(int userId, string product);
        List<string> GetCartItems(int userId);
    }

    public interface IDiscountService
    {
        double ApplyDiscount(double total);
    }

}
