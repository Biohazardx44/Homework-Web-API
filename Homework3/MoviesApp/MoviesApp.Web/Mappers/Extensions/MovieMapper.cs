using MoviesApp.Web.DTOs;
using MoviesApp.Web.Models;

namespace MoviesApp.Web.Mappers.Extensions
{
    public static class MovieMapper
    {
        public static MovieDto MapToMovieDto(this Movie movie)
        {
            return new MovieDto
            {
                Id = movie.Id,
                Description = movie.Description,
                Genre = movie.Genre,
                Year = movie.Year,
                Title = movie.Title
            };
        }

        public static void UpdateMovieFromDto(this Movie movie, MovieUpdateDto updateDto)
        {
            movie.Title = updateDto.Title;
            movie.Description = updateDto.Description;
            movie.Year = updateDto.Year;
            movie.Genre = updateDto.Genre;
        }
    }
}