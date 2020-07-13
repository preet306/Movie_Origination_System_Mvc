using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Movie_Origination_System_Mvc.Models;

namespace Movie_Origination_System_Mvc.Data
{
    public class Movie_Origination_System_MvcContext : DbContext
    {
        public Movie_Origination_System_MvcContext (DbContextOptions<Movie_Origination_System_MvcContext> options)
            : base(options)
        {
        }

        public DbSet<Movie_Origination_System_Mvc.Models.Movie_details> Movie_details { get; set; }

        public DbSet<Movie_Origination_System_Mvc.Models.Producer_details> Producer_details { get; set; }

        public DbSet<Movie_Origination_System_Mvc.Models.Director_details> Director_details { get; set; }

        public DbSet<Movie_Origination_System_Mvc.Models.Movie_Origination_Table> Movie_Origination_Table { get; set; }
    }
}
