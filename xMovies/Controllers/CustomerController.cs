using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using xMovies.Dto;
using xMovies.Models;
using xMovies.ViewModels;
using Microsoft.AspNet.Identity;

namespace xMovies.Controllers
{
    public class CustomerController : Controller
    {
        private ApplicationDbContext _context;
        private ApplicationUser currUser;

        public CustomerController()
        {            
            _context = new ApplicationDbContext();
            var http = HttpContext.User.Identity;
            var id = http.GetUserId();
            currUser = _context.Users.Single(u => u.Id==id);
        }

        //dbcontext as disposable object needs to override this method
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customer
        public ViewResult Index()
        {
            if (User.IsInRole("CanManageMovies"))
                return View("Index");
            return View("ReadOnlyIndex");
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
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes,
                Email = currUser.Email
            };

            return View("CustomerForm", viewModel);
        }

        //Post: customer/create
        //get data from add customer page and store to database then redirect
        [Authorize(Roles = RoleName.CanManageMovies)]
        [HttpPost]
        public ActionResult Save(Customer customer)
        {
            //if invalid need user to re-enter required data
            if(!ModelState.IsValid){
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            //create new customer
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
                currUser.CustomerId = customer.Id;
            }
            //update existing customer with matching id
            else
            {
                var customerInDb = _context.Customers.Single(c=>c.Id==customer.Id);

                //update  
                customerInDb.Name = customer.Name;
                customerInDb.EmailSubscribed = customer.EmailSubscribed;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsAdult = customer.IsAdult;
            }
            

            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }

        //Get: customer/edit/:id
        //take id and direct to customer edit page
        public ActionResult Edit(int Id)
        {
            var customer = GetCustomerWithId(Id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
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