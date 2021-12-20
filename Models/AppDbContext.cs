using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace IMDBService.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> Options) :base(Options)
        {

        }

        public DbSet<Movie> Movies { get; set; }
       
        public DbSet<User> Users { get; set; }
    }
}
