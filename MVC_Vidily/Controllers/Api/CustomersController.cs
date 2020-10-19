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
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();

        }
        //GET/api/customer/1
        public Customer GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return customer;
        }
        //POST/api/customers
        [HttpPost]
       public Customer CreateCustomer (Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _context.Customers.Add(customer);
            _context.SaveChanges();
            return customer;

        }
        //PUT/api/customer/1
        [HttpPut]
        public void UpdateCustomer(int id ,Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerInDb = _context.Customers.SingleOrDefault(c=>c.Id==id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            customerInDb.CustomerName = customer.CustomerName;
            customerInDb.Birthdate = customer.Birthdate;
            customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            customerInDb.MembershipTypeID = customer.MembershipTypeID;

            _context.SaveChanges();

        }
        //DELETE/api/customer/1
        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

              _context.Customers.Remove(customerInDb);

        }
    }
}
