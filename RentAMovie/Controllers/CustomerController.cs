using RentAMovie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using RentAMovie.ViewModel;

namespace RentAMovie.Controllers
{
    public class CustomerController : Controller
    {
        // creating object for DB context
        private ApplicationDbContext dbContext = null;

        public CustomerController()
        {
            dbContext = new ApplicationDbContext();

        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        // GET: Customer
        public ActionResult Index()
        {
            //   var customer = GetCustomer();
            //  return View(customer);
            List<Customer> customers = dbContext.Customers.Include(mem =>mem.Membership ).ToList();
            return View(customers);

        }

        public ActionResult Details(int id)

        {
            var customer = dbContext.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        [HttpGet]
        public ActionResult Create()
        {
            CustomerMembershipViewModel viewModel = new CustomerMembershipViewModel();
            Customer customer = new Customer();
            var membershipTypes = dbContext.MembershipTypes.ToList();
            viewModel.Customer = customer;
            viewModel.MembershipTypes = membershipTypes;
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            dbContext.Customers.Add(customer);
            dbContext.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }

        public List<Customer> GetCustomer()
        {
            List<Customer> customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "Indhu" , DateOfBirth= Convert.ToDateTime("12-04-1995")},
            new Customer { Id = 2, Name = "Greenie"   , DateOfBirth= Convert.ToDateTime("03-12-1994")},
            new Customer { Id = 3, Name = "Vichu"    ,DateOfBirth= Convert.ToDateTime("05-01-2003")},
        };
            return customers;

        }

        
    }
}