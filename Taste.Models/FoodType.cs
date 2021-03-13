using System.ComponentModel.DataAnnotations;

namespace Grouper.Models
{
    public class FoodType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "FoodType")]
        public string Name { get; set; }

    }
}