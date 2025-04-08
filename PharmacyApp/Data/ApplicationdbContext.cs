using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PharmacyApp.Models;

namespace PharmacyApp.Data
{
    public class ApplicationdbContext : IdentityDbContext
    {
        public ApplicationdbContext(DbContextOptions<ApplicationdbContext> options) : base(options)
        {

        }

        //Add tables
        public DbSet<Models.Customers> Customers { get; set; } = default!;
        public DbSet<Models.OrderDetails> OrderDetails { get; set; } = default!;
        public DbSet<Models.Products> Products { get; set; } = default!;
        public DbSet<Models.PrescriptionOrders> PrescriptionOrders { get; set; } = default!;
        public DbSet<Models.Payments> Payments { get; set; } = default!;
        public DbSet<Models.Cart> Cart { get; set; } = default!;
        public DbSet<Models.FeedbackForm> FeedbackForm { get; set; }    

        public DbSet<Models.Form2> form2s { get; set; } = default!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Payments>()
            .HasOne(p => p.PrescriptionOrder)
            .WithMany()
            .HasForeignKey(p => p.PrescriptionOrderId)
            .OnDelete(DeleteBehavior.NoAction); 

            modelBuilder.Entity<Payments>()
            .HasOne(p => p.Customer)
            .WithMany()
            .HasForeignKey(p => p.CustomerId)
            .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
