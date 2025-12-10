using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestaurantManager.Models
{
    public class Supplier
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Delivery estimate is required")]
        [Range(1, 30, ErrorMessage = "Must be between 1 and 30 days")]
        public int Delivery_estimate { get; set; }

        public ICollection<Ingredient>? Ingredients { get; set; }
    }
}
