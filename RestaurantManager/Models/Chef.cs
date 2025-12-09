namespace RestaurantManager.Models
{
    public class Chef
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }
        public int Experience_years { get; set; }
        public string Temper { get; set; }

        public ICollection<Kitchen>? Kitchens { get; set; }
    }
}
