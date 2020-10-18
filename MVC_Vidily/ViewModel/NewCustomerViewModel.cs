using MVC_Vidily.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace MVC_Vidily.ViewModel
{
    public class NewCustomerViewModel
    {
        public IEnumerable<MembershipType>MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}