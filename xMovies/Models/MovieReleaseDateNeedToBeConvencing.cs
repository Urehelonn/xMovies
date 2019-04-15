using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace xMovies.Models
{
    public class MovieReleaseDateNeedToBeConvencing : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;
            var mtime = "01/01/1990";
            if((DateTime)movie.ReleaseDate > Convert.ToDateTime(mtime))
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("You sure this movie is that old?");
        }
    }
}