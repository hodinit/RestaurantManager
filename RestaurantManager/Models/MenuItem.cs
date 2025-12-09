namespace RestaurantManager.Models
{
    public class MenuItem
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int? IngredientID { get; set; }
        public int? KitchenID { get; set; }
        public string Category { get; set; }
        public int Calories { get; set; }
        public int Prep_time { get; set; }
        public int Price { get; set; }

        public Ingredient? Ingredient { get; set; }
        public Kitchen? Kitchen { get; set; }
    }
}
