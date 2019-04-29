using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using xMovies.Models;

namespace xMovies.Controllers.API
{
    public class CustomerController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        //get: api/customer
        //return all customers
        public IEnumerable<Customer> GetCustomers()
        {
            IEnumerable<Customer> customers = _context.Customers.ToList();
            return customers;
        }

        //get: api/customer/:Id
        //return single customer with required Id
        public Customer GetCustomer(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(c=>c.Id==Id);
            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return customer;
        }

        //post: api/customer
        //post new customer to database
        [HttpPost]
        public Customer AddCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer;
        }

        //put: api/customer
        //update existing customer and save to database
        [HttpPut]
        public void UpdateCustomer(int Id, Customer customer)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var CustomerInDb = _context.Customers.SingleOrDefault(c => c.Id == Id);
            if (CustomerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

        }
    }
}
