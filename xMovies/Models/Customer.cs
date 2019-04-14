using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace xMovies.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool EmailSubscribed { get; set; }
        public MembershipType MembershipType { get; set; }
        [Display(Name="Membership Type")]
        [VIPNeedToBeAdultValidation]
        public byte MembershipTypeId { get; set; }
        public short MembershipDurationLeftInMonth { get; set; }
        public bool IsAdult { get; set; }
    }
}