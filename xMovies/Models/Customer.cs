using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace xMovies.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool EmailSubscribed { get; set; }
        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeId{ get; set; }
    }
}