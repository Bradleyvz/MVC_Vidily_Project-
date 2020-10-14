using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Vidily.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }

        //Section 3 Exercise 1 
        public string MembershipTypeName { get; set; }

        public byte DiscountRate { get; set; }
    }
}