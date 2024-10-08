﻿using EntityLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Concrete
{
    public class SignalRContext : IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = DESKTOP-S5STNHF; initial catalog = SignalRDb; integrated security=true; trustservercertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Basket>(entry =>
            {
                entry.ToTable("Baskets", tb => tb.HasTrigger("ActiveTable"));
                entry.ToTable("Baskets", tb => tb.HasTrigger("TotalPriceCounting"));
            });
            modelBuilder.Entity<Order>(entry =>
            {
                entry.ToTable("Orders", tb => tb.HasTrigger("SumMoneyCases"));
                entry.ToTable("Orders", tb => tb.HasTrigger("trg_AfterInsertOrders"));
            });
            modelBuilder.Entity<OrderDetail>(entry =>
            {
                entry.ToTable("OrderDetails", tb => tb.HasTrigger("DecreaseOrderTotalPrice"));
                entry.ToTable("OrderDetails", tb => tb.HasTrigger("IncreaseOrderTotalPrice"));
            });
			modelBuilder.Entity<Booking>(entry =>
			{
				entry.ToTable("Bookings", tb => tb.HasTrigger("trg_AfterInsertBookings"));
			});
		}

        public DbSet<About> Abouts { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SocialMedia> Socialmedias { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<MoneyCase> Moneycases { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Message> Messages { get; set; }
    }
}
