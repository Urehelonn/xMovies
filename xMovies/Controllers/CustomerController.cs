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
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        //dbcontext as disposable object needs to override this method
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customer
        public ViewResult Index()
        {
            var customers = GetCustomers().ToList();

            var CustomerV = new CustomerIndexViewModel {
                Customers = customers
            };
            return View(CustomerV);
        }

        [Route("customer/detail/{Id}")]
        public ActionResult Show(int Id)
        {
            var customer = GetCustomerWithId(Id);

            return View(customer);
        }


        //Get: customer/new
        //direct to add new customer page
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CreateCustomerViewModel
            {
                MembershipTypes = membershipTypes
            };

            return View(viewModel);
        }

        //Post: customer/create
        //get data from add customer page and store to database then redirect
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            //_context.Customers.Add(customer);
            //_context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }

        //Get: customer/edit/:id
        //take id and direct to customer edit page
        public ActionResult Edit(int Id)
        {
            return View();
        }



        //functions
        private IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers;
        }
        private Customer GetCustomerWithId(int Id)
        {
            return GetCustomers().SingleOrDefault(c=>c.Id==Id);
        }
    }
}