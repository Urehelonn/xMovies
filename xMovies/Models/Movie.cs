using System;
using System.ComponentModel.DataAnnotations;

namespace xMovies.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public Genre Genre { get; set; }
        [Required]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MMM, dd, yyyy}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; } = DateTime.Now;

        public bool Limit { get; set; } = false;
    }
}