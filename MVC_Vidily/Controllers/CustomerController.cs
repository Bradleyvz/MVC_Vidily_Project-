using MVC_Vidily.Models;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//Add Using Statement 
using System.Data.Entity;

namespace MVC_Vidily.Controllers
{
    public class CustomerController : Controller
    {
        private DataContext _context;
        public CustomerController()
        {
            _context = new DataContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Customers
        public ViewResult Index()
        {
            //Eager Loading/ Using the Include Method to load the whole customer object
            //Added Using System.Data.Entity MembershipType is in a different NameSpace 
            var customers = _context.Customers.Include(c =>c.MembershipType).ToList();

            return View(customers);
        }


        public ActionResult Details(int id)
        {
            //var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id==id);
          

            if (customer == null)
                return HttpNotFound();

            return View(customer);

        }
    }
}