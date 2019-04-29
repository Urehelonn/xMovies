using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace xMovies.Models
{
    public class CustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool EmailSubscribed { get; set; }
        public byte MembershipTypeId { get; set; }
        public short MembershipDurationLeftInMonth { get; set; }
        public bool IsAdult { get; set; }
    }
}