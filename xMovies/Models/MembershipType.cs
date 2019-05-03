using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace xMovies.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        [Display(Name = "Membership Choice")]
        public string MembershipName { get; set; }
        public short SighUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        //members have access on all un-star movie, vip have access to all movies
        //1,2 as member. 3,4 as vip, vip has to be adult
        public byte MembershipClass { get; set; }

        public static readonly byte ShortTermMember = 1;
        public static readonly byte LongTermMember = 2;
        public static readonly byte ShortTermVip= 3;
        public static readonly byte LongTermVip = 4;
    }
}