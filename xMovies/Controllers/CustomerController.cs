using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using xMovies.Models;
using xMovies.ViewModels;

namespace xMovies.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            List<Customer> customers = new List<Customer>
            {
                new Customer{ Id=1, Name="Peter Parker" },
                new Customer{ Id=1, Name="John Doe" },
                new Customer{ Id=1, Name="Valak" },
                new Customer{ Id=1, Name="Wed Welson" },
                new Customer{ Id=1, Name="Dr. Von Doom" },
                new Customer{ Id=1, Name="Pikachu" },
            };

            var CustomerV = new CustomerIndexViewModel {
                Customers = customers
            };
            return View(CustomerV);
        }

        [Route("customer/detail/{Id}")]
        public ActionResult Show(int Id)
        {
            List<Customer> customers = new List<Customer>
            {
                new Customer{ Id=1, Name="Peter Parker" },
                new Customer{ Id=1, Name="John Doe" },
                new Customer{ Id=1, Name="Valak" },
                new Customer{ Id=1, Name="Wed Welson" },
                new Customer{ Id=1, Name="Dr. Von Doom" },
                new Customer{ Id=1, Name="Pikachu" },
            };
            var customer = customers[Id - 1];

            return View(customer);
        }
    }
}