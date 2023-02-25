using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

namespace MVCDemo.Models
{
    public class ApplicationContext: DbContext
    {

      
        public DbSet<Customer> Customers { get; set; }

        public DbSet<Language> Languages { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=mvc-App;Trusted_Connection=True;MultipleActiveResultSets=true"); 
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Customer>().Property(a=>a.FirstName).HasMaxLength(50).HasDefaultValue("First");

            modelBuilder.Entity<Customer>().Property(a => a.LastName).HasColumnName("NameLat");

            modelBuilder.Entity<Customer>().HasQueryFilter(p => !p.IsDeleted);

            base.OnModelCreating(modelBuilder);
        }
    }
}
