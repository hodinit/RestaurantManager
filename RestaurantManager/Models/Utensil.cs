using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestaurantManager.Models
{
    public class Utensil
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Name is required")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Material is required")]
        [StringLength(30)]
        public string Material { get; set; }

        [Required(ErrorMessage = "Ease of cleaning is required")]
        public string Ease_of_cleaning { get; set; }

        public ICollection<Kitchen>? Kitchens { get; set; }
    }
}
