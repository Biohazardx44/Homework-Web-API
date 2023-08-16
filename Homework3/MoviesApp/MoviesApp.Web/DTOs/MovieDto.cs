using MoviesApp.Web.Models.Enums;

namespace MoviesApp.Web.DTOs
{
    public class MovieDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Year { get; set; }
        public Genre Genre { get; set; }
    }
}