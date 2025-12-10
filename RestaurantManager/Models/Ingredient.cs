using System.ComponentModel.DataAnnotations;

namespace RestaurantManager.Models
{
    public class Ingredient
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(0, 1000, ErrorMessage = "Quantity must be between 0 and 1000")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Cost per unit is required")]
        [Range(0.01, 1000, ErrorMessage = "Cost per unit must be between 0.01 and 1000")]
        public int Cost_per_unit { get; set; }

        [Required(ErrorMessage = "Measure unit is required")]
        [StringLength(10)]
        public string Measure_unit { get; set; }

        public bool Refrigerated { get; set; }

        public int? SupplierID { get; set; }

        public Supplier? Supplier { get; set; }
    }
}
