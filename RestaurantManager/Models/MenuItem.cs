using System.ComponentModel.DataAnnotations;

namespace RestaurantManager.Models
{
    public class MenuItem
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50)]
        public string Name { get; set; }

        public int? IngredientID { get; set; }

        public int? KitchenID { get; set; }

        [Required(ErrorMessage = "Category is required")]
        [StringLength(50)]
        public string Category { get; set; }

        [Required(ErrorMessage = "Calories is required")]
        [Range(0, 5000, ErrorMessage = "Calories must be between 0 and 5000")]
        public int Calories { get; set; }

        [Required(ErrorMessage = "Prep time is required")]
        [Range(1, 300, ErrorMessage = "Prep time must be between 1 and 300 minutes")]
        public int Prep_time { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0.01, 1000, ErrorMessage = "Price must be between 0.01 and 1000")]
        public int Price { get; set; }

        public Ingredient? Ingredient { get; set; }
        public Kitchen? Kitchen { get; set; }
    }
}
