namespace RecipeAPI.Dtos
{
    public class RecipeReadDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Ingredients { get; set; }
        public string Instructions { get; set; }
        public string Description { get; set; }
        public string Source { get; set; }
        public int Rating { get; set; }
        public string PrepTime { get; set; }
        public string ImageURL { get; set; }
    }
}