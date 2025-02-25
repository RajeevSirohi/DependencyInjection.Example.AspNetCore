namespace DependencyInjection.Example.AspNetCore.Interfaces
{
    public interface IProductService
    {
        string GetProduct();
    }

    public interface ICartService
    {
        void AddToCart(string product);
        List<string> GetCartItems();
    }

    public interface IDiscountService
    {
        double ApplyDiscount(double total);
    }

}
