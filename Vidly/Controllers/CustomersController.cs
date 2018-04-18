using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            //var customers = GetCustomers();
            var customers = _context.Customers.Include(m=> m.MembershipType).ToList();
            var viewModel = new CustomersViewModel
            {
                Customers = customers
            };

            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            //var customer = GetCustomers().Where(x => x.Id == id).FirstOrDefault();
            var customer = _context.Customers.Include(m=> m.MembershipType).SingleOrDefault(x => x.Id == id);
            if (customer != null)
            {
                var viewModel = new CustomersViewModel
                {
                    Customer = customer
                };
                return View(viewModel);
            }

            return HttpNotFound();
        }

        private List<Customer> GetCustomers()
        {
            var customers = new List<Customer>
            {
                new Customer { Id = 1, Name =  "Customer 1" },
                new Customer { Id = 2, Name =  "Customer 2" },
                new Customer { Id = 3, Name =  "Customer 3" },
                new Customer { Id = 4, Name =  "Customer 4" },
            };
            return customers;
        }

    }
}