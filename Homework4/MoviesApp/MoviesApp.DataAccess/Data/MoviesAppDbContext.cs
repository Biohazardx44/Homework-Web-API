using Microsoft.EntityFrameworkCore;
using MoviesApp.Domain.Enums;
using MoviesApp.Domain.Models;

namespace MoviesApp.DataAccess.Data
{
    public class MoviesAppDbContext : DbContext
    {
        public MoviesAppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // MOVIE

            // Validations
            modelBuilder.Entity<Movie>()
                .Property(x => x.Title)
                .IsRequired();

            modelBuilder.Entity<Movie>()
                .Property(x => x.Description)
                .HasMaxLength(250);

            modelBuilder.Entity<Movie>()
                .Property(x => x.Year)
                .IsRequired();

            modelBuilder.Entity<Movie>()
                .Property(x => x.Genre)
                .IsRequired();

            // Seed initial data
            modelBuilder.Entity<Movie>()
                .HasData(new Movie
                {
                    Id = 1,
                    Title = "Action Movie",
                    Description = "First Movie, Yay!",
                    Year = 1994,
                    Genre = Genre.Action
                });

            modelBuilder.Entity<Movie>()
                .HasData(new Movie
                {
                    Id = 2,
                    Title = "Thriller Movie",
                    Description = "Second Movie, Yay!",
                    Year = 1999,
                    Genre = Genre.Thriller
                });

            modelBuilder.Entity<Movie>()
                .HasData(new Movie
                {
                    Id = 3,
                    Title = "Better Action Movie",
                    Description = "Third Movie, Yay!",
                    Year = 2021,
                    Genre = Genre.Action
                });

            modelBuilder.Entity<Movie>()
                .HasData(new Movie
                {
                    Id = 4,
                    Title = "Comedy Movie",
                    Description = "Last Movie, Yay!",
                    Year = 1899,
                    Genre = Genre.Comedy
                });
        }
    }
}