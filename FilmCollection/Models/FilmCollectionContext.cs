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

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<FilmCollectionResponse>().HasData(
                new FilmCollectionResponse
                {
                    MovieID = 1,
                    Category = "Family",
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
                    Category = "Sci-Fi",
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
                    Category = "Drama",
                    Title = "Good Will Hunting",
                    Director = "Gus Vant Sant",
                    Year = 1997,
                    Rating = "R",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                }




            );
        }
    }
}
