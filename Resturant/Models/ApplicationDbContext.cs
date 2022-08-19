using Microsoft.EntityFrameworkCore;
using Resturant.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Reflection.Emit;

namespace Resturant.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext()
        { }
        public ApplicationDbContext(DbContextOptions options):base(options)
        { }
        public virtual DbSet<Subscriber> subscribers { get; set; }
        public virtual DbSet<Admin> admin { get; set; }
        public virtual DbSet<Request> requests { get; set; }
        public virtual DbSet<MealType> MealTypes { get; set; }
        public virtual DbSet<AddtionalMeals> AddtionalMeals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Request>()
                .HasMany(c => c.MealTypes)
                .WithOne(e => e.Request);
        }


    }
}
