using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace xMovies.Models
{
    public class MovieAccessRecord
    {
        [Key]
        public int Id { set; get; }
        [Required]
        public int CustomerId { set; get; }
        [Required]
        public int MovieId { set; get; }
        public DateTime DateHappened { get; set; }
    }
}