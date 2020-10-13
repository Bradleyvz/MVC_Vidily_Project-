using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace MVC_Vidily.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }
        
        //Navigation Prperty Allow you to load objects together 
        //Need MembershipType MembershipType and MembershipTypeId to create foreign key in database 
        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeID { get; set; }
    }
}