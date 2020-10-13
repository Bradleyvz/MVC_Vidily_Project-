using MVC_Vidily.Models;
using MVC_Vidily.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVC_Vidily.Data
{
    public class DataContext : DbContext
    {
        public DataContext() : base("VidilyConnection")
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> movies { get; set; }
    }
}