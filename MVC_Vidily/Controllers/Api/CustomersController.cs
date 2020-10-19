using AutoMapper;
using Microsoft.Ajax.Utilities;
using MVC_Vidily.DTO;
using MVC_Vidily.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MVC_Vidily.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private DataContext _context;
        public CustomersController()
        {
            _context = new DataContext();
        }
        //GET/api/customers
        public IEnumerable<CustomerDTO> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer,CustomerDTO>);

        }
        //GET/api/customer/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return NotFound();

            return Ok (Mapper.Map<Customer, CustomerDTO>(customer));
        }
        //POST/api/customers
        [HttpPost]
       public IHttpActionResult CreateCustomer (CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDTO, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id= customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id.ToString()), customerDto);
        }
        //PUT/api/customer/1
        [HttpPut]
        public void UpdateCustomer(int id ,CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerInDb = _context.Customers.SingleOrDefault(c=>c.Id==id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);


            Mapper.Map(customerDto, customerInDb);
           

            _context.SaveChanges();

        }
        //DELETE/api/customer/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                return NotFound();

              _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return Ok();

        }
    }
}
