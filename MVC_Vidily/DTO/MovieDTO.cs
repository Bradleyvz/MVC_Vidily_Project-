using MVC_Vidily.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_Vidily.DTO
{
    public class MovieDTO
    {
      
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public byte GenreId { get; set; }//Foreign Key

        public DateTime DateAdded { get; set; }


        public DateTime ReleaseDate { get; set; }

 
        [Range(1,20)]
        public byte NumInStock { get; set; }
    }
}
