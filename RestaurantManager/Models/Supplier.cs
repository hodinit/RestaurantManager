namespace RestaurantManager.Models
{
    public class Supplier
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Delivery_estimate { get; set; }

        public ICollection<Ingredient>? Ingredients { get; set; }
    }
}
