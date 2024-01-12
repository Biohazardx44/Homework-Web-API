using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MoviesApp.DataAccess.Data;
using MoviesApp.DataAccess.Repositories.Abstraction;
using MoviesApp.DataAccess.Repositories.Implementation.EntityFrameworkImplementation;
using MoviesApp.Domain.Models;
using MoviesApp.Services.Abstraction;
using MoviesApp.Services.Implementation;

namespace MoviesApp.Helpers
{
    public static class DependencyInjectionHelper
    {
        public static void InjectServices(this IServiceCollection services)
        {
            services.AddTransient<IMovieService, MovieService>();
            services.AddTransient<IUserService, UserService>();
        }

        public static void InjectRepositories(this IServiceCollection services)
        {
            // Entity Framework
            services.AddTransient<IRepository<Movie>, MovieRepositoryEntity>();
            services.AddTransient<IUserRepository, UserRepositoryEntity>();
        }

        public static void InjectDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<MoviesAppDbContext>(options =>
                options.UseSqlServer(connectionString));
        }
    }
}