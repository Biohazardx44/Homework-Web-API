using MoviesApp.DataAccess.Data;
using MoviesApp.DataAccess.Repositories.Abstraction;
using MoviesApp.Domain.Models;

namespace MoviesApp.DataAccess.Repositories.Implementation.EntityFrameworkImplementation
{
    public class MovieRepositoryEntity : IRepository<Movie>
    {
        private readonly MoviesAppDbContext _moviesAppDbContext;

        public MovieRepositoryEntity(MoviesAppDbContext moviesAppDbContext)
        {
            _moviesAppDbContext = moviesAppDbContext;
        }

        public void Add(Movie entity)
        {
            _moviesAppDbContext.Movies.Add(entity);
            _moviesAppDbContext.SaveChanges();
        }

        public void Delete(Movie entity)
        {
            _moviesAppDbContext.Movies.Remove(entity);
            _moviesAppDbContext.SaveChanges();
        }

        public List<Movie> GetAll()
        {
            return _moviesAppDbContext.Movies.ToList();
        }

        public Movie GetById(int id)
        {
            return _moviesAppDbContext.Movies
            .SingleOrDefault(x => x.Id == id);
        }

        public void Update(Movie entity)
        {
            _moviesAppDbContext.Movies.Update(entity);
            _moviesAppDbContext.SaveChanges();
        }
    }
}