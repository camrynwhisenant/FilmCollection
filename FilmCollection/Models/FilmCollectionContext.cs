using System;
using Microsoft.EntityFrameworkCore;

namespace FilmCollection.Models
{
    public class FilmCollectionContext : DbContext
    {
        public FilmCollectionContext(DbContextOptions<FilmCollectionContext>options) : base (options)
        {

        }

        public DbSet<FilmCollectionResponse> Movies { get; set; }
        public DbSet<Categories> categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<FilmCollectionResponse>().HasData(
                new FilmCollectionResponse
                {
                    MovieID = 1,
                    Categoryid = 4,
                    Title = "Big Hero 6",
                    Director = "Chris Williams",
                    Year = 2014,
                    Rating = "PG",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                },
                new FilmCollectionResponse
                {
                    MovieID = 2,
                    Categoryid = 2,
                    Title = "Star Wars: Episode IV - A New Hope",
                    Director = "George Lucas",
                    Year = 1977,
                    Rating = "PG",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                },
                new FilmCollectionResponse
                {
                    MovieID = 3,
                    Categoryid = 3,
                    Title = "Good Will Hunting",
                    Director = "Gus Vant Sant",
                    Year = 1997,
                    Rating = "R",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                }
                );

            mb.Entity<Categories>().HasData(
                new Categories { Categoryid = 1, CategoryName = "Action" },
                new Categories { Categoryid = 2, CategoryName = "Sci-Fi" },
                new Categories { Categoryid = 3, CategoryName = "Drama" },
                new Categories { Categoryid = 4, CategoryName = "Family" });

        }
    }
}
