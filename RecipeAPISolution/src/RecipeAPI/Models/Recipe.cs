using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RecipeAPI.Models
{
    public class Recipe
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string Title { get; set; }

        [Required]
        public List<string> Ingredients { get; set; }

        [Required]
        public string Instructions { get; set; }

        public string Description { get; set; }

        public string Source { get; set; }

        public int Rating { get; set; }

        public string PrepTime { get; set; }

        /*
        // Additional data:
        //image?
        //comments (probably an object of its own)
        */
    }
}