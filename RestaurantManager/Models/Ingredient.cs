namespace RestaurantManager.Models
{
    public class Ingredient
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Cost_per_unit { get; set; }
        public string Measure_unit { get; set; }
        public bool Refrigerated { get; set; }
        public int? SupplierID { get; set; }

        public Supplier? Supplier { get; set; }
    }
}
