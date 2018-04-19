using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.ViewModels
{
    public class CustomersViewModel
    {
        public Customer Customer { get; set; }
        public List<Customer> Customers { get; set; }
        public List<MembershipType> MembershipTypes { get; set; }
    }
}