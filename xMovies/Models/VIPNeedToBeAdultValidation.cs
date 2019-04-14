using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace xMovies.Models
{
    public class VIPNeedToBeAdultValidation: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId != MembershipType.ShortTermVip &&
                customer.MembershipTypeId != MembershipType.LongTermVip)
            {
                return ValidationResult.Success;
            }
            if (customer.IsAdult)
            {
                return ValidationResult.Success;
            }
            return new ValidationResult("You need to be adult to be a VIP member ;)");
        }
    }
}