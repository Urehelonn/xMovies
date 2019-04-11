using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using xMovies.Models;

namespace xMovies.ViewModels
{
    public class CreateCustomerViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}