using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Services.Description;

namespace MVC_Vidily.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string CustomerName { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
   
        //Section 3 Exercise 2 

        [Column(TypeName = "Date")]// Change DateTime type to Date.
        public DateTime?  Birthdate  { get; set; }

        public MembershipType MembershipType { get; set; }//Navigation property , navigation from one type to another , Customer 
        public byte MembershipTypeID { get; set; }//Treats this property as a foreign key 
    }
}