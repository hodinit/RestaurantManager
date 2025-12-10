using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestaurantManager.Models
{
    public class Location
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(100)]
        public string Adress { get; set; }

        [Required(ErrorMessage = "Number is required")]
        [Range(1, 100, ErrorMessage = "Number must be between 1 and 100")]
        public int Number { get; set; }

        public ICollection<Kitchen>? Kitchens { get; set; }
    }
}
