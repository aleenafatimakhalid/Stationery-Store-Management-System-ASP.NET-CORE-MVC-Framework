using KMAstationeryStore.Models;
using Microsoft.EntityFrameworkCore;

namespace KMAstationeryStore.Data
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) //passing the options to base class
        {
            
        }

        //using the code first approach, where we write code and then create database models
        public DbSet<ProductItem> Product_Items { get; set; }
        public DbSet<PromotionalOffers> Promotional_Offers { get; set; }
        public DbSet<Stock> stock { get; set; }
        public DbSet<Customer> customer { get; set; }
        public DbSet<Admin> admins { get; set; }
        public DbSet<Bill> bills { get; set; }
        public DbSet<Cart> cart { get; set; }
    }
}
