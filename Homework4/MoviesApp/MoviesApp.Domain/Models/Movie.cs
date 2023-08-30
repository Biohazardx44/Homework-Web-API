using MoviesApp.Domain.Enums;

namespace MoviesApp.Domain.Models
{
    public class Movie : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public int Year { get; set; }
        public Genre Genre { get; set; }
    }
}