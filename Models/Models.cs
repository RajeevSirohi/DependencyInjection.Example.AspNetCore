

namespace DependencyInjection.Example.AspNetCore.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; } // Primary Key

        public int UserId { get; set; } // Associate cart with user

        public List<CartItem> Items { get; set; } = new List<CartItem>(); // Related cart items
    }

    public class CartItem
    {
        [Key]
        public int Id { get; set; }

        public int CartId { get; set; } // Foreign Key reference

        public string ProductName { get; set; }
    }

}
