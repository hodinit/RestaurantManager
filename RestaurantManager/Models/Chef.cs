using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestaurantManager.Models
{
    public class Chef
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Specialty is required")]
        [StringLength(50)]
        public string Specialty { get; set; }

        [Required(ErrorMessage = "Experience years is required")]
        [Range(0, 50, ErrorMessage = "Experience years must be between 0 and 50")]
        public int Experience_years { get; set; }

        [Required(ErrorMessage = "Temper is required")]
        [StringLength(50)]
        public string Temper { get; set; }

        public ICollection<Kitchen>? Kitchens { get; set; }
    }
}
