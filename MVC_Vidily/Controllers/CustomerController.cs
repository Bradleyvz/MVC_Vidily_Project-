using MVC_Vidily.Models;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//Add Using Statement 
using System.Data.Entity;
using MVC_Vidily.ViewModel;
using Microsoft.Owin.Security.Provider;

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
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                //Customer Default Values will be initialized.
                Customer=new Customer(),
                MembershipTypes = membershipTypes

            };
            return View("CustomerForm",viewModel);
        }
        //Post Method to post form back to the server 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {

                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                 };
                    return View("CustomerForm",viewModel);
           }

            if (customer.Id ==0)
            _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                customerInDb.CustomerName = customer.CustomerName;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeID = customer.MembershipTypeID;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;

            }
            _context.SaveChanges();

            return RedirectToAction("Index","Customer");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c=>c.Id==id);
            if (customer==null)
            
                return HttpNotFound();
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes=_context.MembershipTypes.ToList()

            };
                return View("CustomerForm",viewModel);
        }
    }
}
