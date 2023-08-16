using MoviesApp.Web.Models.Enums;

namespace MoviesApp.Web.Models
{
    public class Movie : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int Year { get; set; }
        public Genre Genre { get; set; }
    }
}