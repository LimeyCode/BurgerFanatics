using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using BurgerFnatics.Models;

namespace BurgerFnatics.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<BurgerFnatics.Models.Location> Location { get; set; }
        public DbSet<BurgerFnatics.Models.Menu> Menu { get; set; }
        public DbSet<BurgerFnatics.Models.MenuGroup> MenuGroup { get; set; }
        public DbSet<BurgerFnatics.Models.Restaurant> Restaurant { get; set; }
        public DbSet<BurgerFnatics.Models.MenuItem> MenuItem { get; set; }
        public DbSet<BurgerFnatics.Models.Review> Review { get; set; }

        //Overiding cascade to allow for cycle database connections
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<MenuGroup>().HasOne(m => m.Menu).WithOne().OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<MenuItem>().HasOne(m => m.Menu).WithOne().OnDelete(DeleteBehavior.ClientCascade);
            modelBuilder.Entity<MenuItem>().HasOne(m => m.MenuGroup).WithOne().OnDelete(DeleteBehavior.ClientCascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
