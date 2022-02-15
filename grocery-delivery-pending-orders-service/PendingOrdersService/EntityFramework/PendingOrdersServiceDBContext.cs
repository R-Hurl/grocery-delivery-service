using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PendingOrdersService.Models;

namespace PendingOrdersService.EntityFramework
{
    public class PendingOrdersServiceDBContext : DbContext
    {
        public PendingOrdersServiceDBContext(DbContextOptions<PendingOrdersServiceDBContext> options) : base(options)
        {
        }

        public DbSet<Models.Order> Orders { get; set; }
        public DbSet<Models.OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            new OrdersMap(builder.Entity<Models.Order>());
            new OrderItemsMap(builder.Entity<Models.OrderItem>());
        }
    }

    internal class OrderItemsMap
    {
        public OrderItemsMap(EntityTypeBuilder<OrderItem> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.ToTable("orders");

            // Columns
            entityBuilder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            entityBuilder.Property(x => x.ProductId).HasColumnName("product_id").IsRequired(true);
            entityBuilder.Property(x => x.Quantity).HasColumnName("quantity").IsRequired(true);
            entityBuilder.Property(x => x.OrderId).HasColumnName("order_id").IsRequired(true);
        }
    }

    internal class OrdersMap
    {

        public OrdersMap(EntityTypeBuilder<Models.Order> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.ToTable("orderitems");

            entityBuilder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            entityBuilder.Property(x => x.OrderId).HasColumnName("order_id").IsRequired(true);
            entityBuilder.Property(x => x.CustomerId).HasColumnName("customer_id").IsRequired(true);
            entityBuilder.Property(x => x.OrderStatus).HasColumnName("order_status").IsRequired(true).HasMaxLength(2);
            entityBuilder.Property(x => x.Total).HasColumnName("total");
        }
    }
}