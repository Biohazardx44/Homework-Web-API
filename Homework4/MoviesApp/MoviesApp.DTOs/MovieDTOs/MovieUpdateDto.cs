using MoviesApp.Domain.Enums;

namespace MoviesApp.DTOs.MovieDTOs
{
    public class MovieUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Year { get; set; }
        public Genre Genre { get; set; }
    }
}