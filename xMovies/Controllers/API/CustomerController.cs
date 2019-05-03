using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using xMovies.Models;
using AutoMapper;
using System.Data.Entity;
using xMovies.Dto;
using System;

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
        public IHttpActionResult GetCustomers()
        {
            var customerDtos = _context.Customers
                .Include(c => c.MembershipType)
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);        
            return Ok(customerDtos);
        }

        //get: api/customer/:Id
        //return single customer with required Id
        public IHttpActionResult GetCustomer(int Id)
        {
            var customer = _context.Customers.SingleOrDefault(c=>c.Id==Id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        //post: api/customer
        //post new customer to database
        [HttpPost]
        public IHttpActionResult AddCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri+"/"+customer.Id), customerDto);
        }

        //put: api/customer
        //update existing customer and save to database
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int Id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var CustomerInDb = _context.Customers.SingleOrDefault(c => c.Id == Id);
            if (CustomerInDb == null)
            {
                return NotFound();
            }

            Mapper.Map(customerDto, CustomerInDb);
            _context.SaveChanges();

            return Ok();
        }

        //delete: api/customer/:Id
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int Id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c=>c.Id==Id);
            if (customerInDb == null) return NotFound();
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
