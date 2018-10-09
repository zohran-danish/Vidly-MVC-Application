using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
           
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();

            /*This viewModel is initialised for populating the membership types in the dropdown 
              and new instance of customer class is initialised so that the customer id is not null */

            var ViewModel = new CustomerFormViewModel()
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm",ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            //For validation of the attributes applied in models 
            if(!ModelState.IsValid)
            {
                var ViewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes
                };
                return View("CustomerForm", ViewModel);

            }

            //For new customers
            if (customer.Id == 0)
                _context.Customers.Add(customer);

            //For editing customers
            else
            {
                var CustomerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                CustomerInDb.Name = customer.Name;
                CustomerInDb.Birthdate = customer.Birthdate;
                CustomerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                CustomerInDb.MembershipTypeId = customer.MembershipTypeId;
            }


            _context.SaveChanges();
                
            return RedirectToAction("Index","Customer");
        }

        

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);

        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if(customer==null)
            {
                return HttpNotFound();
            }

            var ViewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes
            };
            return View("CustomerForm",ViewModel);
        }
    
    }
}
 