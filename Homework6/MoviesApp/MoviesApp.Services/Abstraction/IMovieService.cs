using MoviesApp.Domain.Enums;
using MoviesApp.DTOs.MovieDTOs;

namespace MoviesApp.Services.Abstraction
{
    public interface IMovieService
    {
        List<MovieDto> GetAllMovies(int userId);
        MovieDto GetById(int id);
        void AddMovie(MovieAddDto movieAddDto);
        void UpdateMovie(MovieUpdateDto movieUpdateDto);
        void DeleteMovie(int id);
        List<MovieDto> FilterMovies(Genre? genre, int? year, int userId);
    }
}