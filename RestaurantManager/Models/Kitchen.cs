namespace RestaurantManager.Models
{
    public class Kitchen
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Temperature { get; set; }
        public string Setting { get; set; }
        public int? ChefID { get; set; }
        public int? UtensilID { get; set; }
        public int? LocationID { get; set; }

        public Chef? Chef { get; set; }
        public Utensil? Utensil { get; set; }
        public Location? Location { get; set; }
    }
}
