using System.ComponentModel.DataAnnotations;

namespace RestaurantManager.Models
{
    public class Kitchen
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Temperature is required")]
        [Range(10, 40, ErrorMessage = "Temperature must be between 10 and 40 degrees")]
        public int Temperature { get; set; }

        [Required(ErrorMessage = "Setting is required")]
        [StringLength(50)]
        public string Setting { get; set; }

        public int? ChefID { get; set; }
        public int? UtensilID { get; set; }
        public int? LocationID { get; set; }

        public Chef? Chef { get; set; }
        public Utensil? Utensil { get; set; }
        public Location? Location { get; set; }
    }
}
