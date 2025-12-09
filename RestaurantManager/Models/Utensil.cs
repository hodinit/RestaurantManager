namespace RestaurantManager.Models
{
    public class Utensil
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Material { get; set; }
        public string Ease_of_cleaning { get; set; }

        public ICollection<Kitchen>? Kitchens { get; set; }
    }
}
