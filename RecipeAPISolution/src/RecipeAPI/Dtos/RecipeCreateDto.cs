using System.ComponentModel.DataAnnotations;

namespace RecipeAPI.Dtos
{
    public class RecipeCreateDto
    {
        [Required]
        [MaxLength(250)]
        public string Title { get; set; }

        [Required]
        public string Ingredients { get; set; }

        [Required]
        public string Instructions { get; set; }

        public string Description { get; set; }

        public string Source { get; set; }

        public int Rating { get; set; }

        public string PrepTime { get; set; }
    }
}