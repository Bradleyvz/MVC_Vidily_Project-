using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace MVC_Vidily.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }

        [Column(TypeName = "Date")]// Change DateTime type to Date.
        public DateTime ReleaseDate { get; set; }

        [Column(TypeName = "Date")]// Change DateTime type to Date.
        public DateTime DateAdded { get; set; }

        public int NumInStock { get; set; }
    }
}