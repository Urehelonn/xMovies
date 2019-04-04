using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace xMovies.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public short SighUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        //members have access on all un-star movie, vip have access to all movies
        public byte MembershipClass { get; set; }
    }
}