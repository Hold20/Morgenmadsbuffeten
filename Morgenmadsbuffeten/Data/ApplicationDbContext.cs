using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Morgenmadsbuffeten.Models;

namespace Morgenmadsbuffeten.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<RoomCheckedIn> RoomsCheckedIn { get; set; }
        public DbSet<Breakfast> Breakfasts { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Breakfast>()
                .HasData(
                    new Breakfast()
                    {
                        ID = 1,
                        Date = DateTime.Today,
                        Adults = 6,
                        Children = 10
                    }
                );

            modelBuilder.Entity<RoomCheckedIn>()
                .HasData(
                    new RoomCheckedIn()
                    {
                        ID = 1,
                        Date = DateTime.Today,
                        RoomNumber = 1,
                        Adults = 6,
                        Children = 10
                    },
                    
                    new RoomCheckedIn()
                    {
                        ID = 2, 
                        Date = DateTime.Today, 
                        RoomNumber = 2, 
                        Adults = 6, 
                        Children = 10
                    },

                    new RoomCheckedIn()
                    {
                        ID = 3,
                        Date = DateTime.Today,
                        RoomNumber = 3,
                        Adults = 6,
                        Children = 10
                    }

                );
        }
    }
}
