using System;
using System.ComponentModel.DataAnnotations;


namespace FilmCollection.Models
{
    public class FilmCollectionResponse
    {
        [Required]
        [Key]
        public int MovieID { get; set; }

        //[Required(ErrorMessage = "Category must be specified")]
        //public string Category { get; set; }

        [Required(ErrorMessage = "Title must be specified")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Director must be specified")]
        public string Director { get; set; }

        [Range(1888,2022, ErrorMessage = "Year must be specified")]
        public short Year { get; set; }

        [Required(ErrorMessage ="Rating must be specified")]
        public string Rating { get; set; }

        public bool Edited { get; set; }
        public string LentTo { get; set; }

        [MaxLength(25)]
        public string Notes { get; set; }

        //foreign key relationship
        [Required(ErrorMessage = "Category must be specified")]
        public int Categoryid { get; set; }
        public Categories Categories { get; set; }
        //public int MajorID { get; set; }
        //public Major Major { get; set; } EXAMPLE


    }
}
