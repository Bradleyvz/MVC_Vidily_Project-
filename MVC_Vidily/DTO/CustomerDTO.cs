﻿using MVC_Vidily.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Vidily.DTO
{
    public class CustomerDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//switch on autogenerateds
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string CustomerName { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }

        //Section 3 Exercise 2 

        [Column(TypeName = "Date")]// Change DateTime type to Date.

        //[Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }

        public byte MembershipTypeID { get; set; }//Treats this property as a foreign key 



    }
}