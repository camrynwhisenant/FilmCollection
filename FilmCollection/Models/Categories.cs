using System;
using System.ComponentModel.DataAnnotations;
namespace FilmCollection.Models

{
    public class Categories
    {
        [Key]
        [Required]
        //foreign key relationship to responses
        public int Categoryid { get; set; }
        public string CategoryName { get; set; }
    }
}
