namespace AdventureSWAPI.Models
{
    public class Product
    {
        public int Id { get; set; }          // Primary key, auto-incremented by default
        public string Name { get; set; }     // Product name
        public string Description { get; set; } // Product description
        public decimal Price { get; set; }    // Price of the product
        public int Stock { get; set; }        // Quantity of the product in stock
    }
}
