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
        [Display(Name="Membership Type")]
        [VIPNeedToBeAdultValidation]
        public byte MembershipTypeId { get; set; }
        //will need to add user id as well to create one-one binding between user identity and customer
        public MembershipType MembershipType { get; set; }
        public short MembershipDurationLeftInMonth { get; set; }
        public bool IsAdult { get; set; }
        public List<int> MovieList { get; set; }
        
        public string UserEmail { get; set; }
    }
}