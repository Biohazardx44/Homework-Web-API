using MoviesApp.DataAccess.Data;
using MoviesApp.DataAccess.Repositories.Abstraction;
using MoviesApp.Domain.Models;

namespace MoviesApp.DataAccess.Repositories.Implementation.EntityFrameworkImplementation
{
    public class UserRepositoryEntity : IUserRepository
    {
        private readonly MoviesAppDbContext _moviesAppDbContext;
        public UserRepositoryEntity(MoviesAppDbContext moviesAppDbContext)
        {
            _moviesAppDbContext = moviesAppDbContext;
        }

        public void Add(User entity)
        {
            _moviesAppDbContext.Users.Add(entity);
            _moviesAppDbContext.SaveChanges();
        }

        public void Delete(User entity)
        {
            _moviesAppDbContext.Users.Remove(entity);
            _moviesAppDbContext.SaveChanges();
        }

        public List<User> GetAll()
        {
            return _moviesAppDbContext.Users.ToList();
        }

        public User GetById(int id)
        {
            return _moviesAppDbContext.Users
            .SingleOrDefault(user => user.Id == id);
        }

        public User GetUserByUsername(string username)
        {
            return _moviesAppDbContext.Users.SingleOrDefault(user => user.Username == username);
        }

        public User LoginUser(string username, string hashedPassword)
        {
            return _moviesAppDbContext.Users.FirstOrDefault(user =>
            user.Username.ToLower() == username.ToLower() &&
            user.Password == hashedPassword);
        }

        public void SaveChanges()
        {
            _moviesAppDbContext.SaveChanges();
        }

        public void Update(User entity)
        {
            _moviesAppDbContext.Users.Update(entity);
            _moviesAppDbContext.SaveChanges();
        }
    }
}