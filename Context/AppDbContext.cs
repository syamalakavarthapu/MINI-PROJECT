using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MINI_PROJECT.Models;

namespace MINI_PROJECT.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }

        public DbSet<User>  Mini_Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
         modelBuilder.Entity<User>().ToTable("Mini_Users");
        }
    }
}