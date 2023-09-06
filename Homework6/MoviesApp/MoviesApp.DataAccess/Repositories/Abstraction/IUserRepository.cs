using MoviesApp.Domain.Models;

namespace MoviesApp.DataAccess.Repositories.Abstraction
{
    public interface IUserRepository : IRepository<User>
    {
        User GetUserByUsername(string username);
        User LoginUser(string username, string hashedPassword);
        void SaveChanges();
    }
}