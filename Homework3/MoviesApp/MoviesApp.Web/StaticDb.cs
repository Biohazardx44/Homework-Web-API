using MoviesApp.Web.Models;
using MoviesApp.Web.Models.Enums;

namespace MoviesApp.Web
{
    public static class StaticDb
    {
        public static List<Movie> Movies = new List<Movie>()
        {
            new Movie
            {
                Id = 1,
                Title = "Action Movie",
                Description = "First Movie, Yay!",
                Year = 1994,
                Genre = Genre.Action
            },
            new Movie
            {
                Id = 2,
                Title = "Thriller Movie",
                Description = "Second Movie, Yay!",
                Year = 1999,
                Genre = Genre.Thriller
            },
            new Movie
            {
                Id = 3,
                Title = "Better Action Movie",
                Description = "Third Movie, Yay!",
                Year = 2021,
                Genre = Genre.Action
            },
            new Movie
            {
                Id = 4,
                Title = "Comedy Movie",
                Description = "Last Movie, Yay!",
                Year = 1899,
                Genre = Genre.Comedy
            },
        };
    }
}