using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using xMovies.Models;
using AutoMapper;

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
        public IEnumerable<CustomerDto> GetCustomers()
        {
            IEnumerable<Customer> customers = _context.Customers.ToList();
            return customers.Select(Mapper.Map<Customer, CustomerDto>);
        }

        //get: api/customer/:Id
        //return single customer with required Id
        public CustomerDto GetCustomer(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(c=>c.Id==Id);
            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return Mapper.Map<Customer, CustomerDto>(customer);
        }

        //post: api/customer
        //post new customer to database
        [HttpPost]
        public CustomerDto AddCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;
            return customerDto;
        }

        //put: api/customer
        //update existing customer and save to database
        [HttpPut]
        public void UpdateCustomer(int Id, CustomerDto customerDto)
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

            Mapper.Map(customerDto, CustomerInDb);

            _context.SaveChanges();
        }

        [HttpDelete]
        public void DeleteCustomer(int Id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c=>c.Id==Id);
            if (customerInDb == null) throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
        }
    }
}
