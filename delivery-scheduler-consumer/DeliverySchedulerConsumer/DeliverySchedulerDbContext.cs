using DeliverySchedulerConsumer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GroceryDeliveryAPI
{
    public class DeliverySchedulerDbContext : DbContext
    {
        public DeliverySchedulerDbContext(DbContextOptions<DeliverySchedulerDbContext> options) : base(options)
        {
        }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            new OrdersMap(builder.Entity<Order>());
        }

        internal class OrdersMap
        {

            public OrdersMap(EntityTypeBuilder<Order> entityBuilder)
            {
                entityBuilder.HasKey(x => x.Id);
                entityBuilder.ToTable("orders");

                entityBuilder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
                entityBuilder.Property(x => x.OrderId).HasColumnName("order_id").IsRequired(true);
                entityBuilder.Property(x => x.CustomerId).HasColumnName("customer_id").IsRequired(true);
                entityBuilder.Property(x => x.OrderStatus).HasColumnName("order_status").IsRequired(true).HasMaxLength(2);
                entityBuilder.Property(x => x.Total).HasColumnName("total");
            }
        }
    }
}