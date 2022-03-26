using GroceryDeliveryAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GroceryDeliveryAPI
{
    public class GroceryDeliveryServiceContext : DbContext
    {
        public GroceryDeliveryServiceContext(DbContextOptions<GroceryDeliveryServiceContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            new CategoriesMap(builder.Entity<Category>());
            new ProductsMap(builder.Entity<Product>());
            new OrdersMap(builder.Entity<Order>());
            new OrderItemsMap(builder.Entity<OrderItem>());
        }
    }

    internal class CategoriesMap
    {
        public CategoriesMap(EntityTypeBuilder<Category> entityBuilder)
        {
            entityBuilder.HasKey(x => x.ID);
            entityBuilder.ToTable("categories");

            // Columns
            entityBuilder.Property(x => x.ID).HasColumnName("id").ValueGeneratedOnAdd();
            entityBuilder.Property(x => x.CategoryName).HasColumnName("category_name");
        }
    }

    internal class ProductsMap
    {
        public ProductsMap(EntityTypeBuilder<Product> entityBuilder)
        {
            entityBuilder.HasKey(x => x.ID);
            entityBuilder.ToTable("products");

            // Columns
            entityBuilder.Property(x => x.ID).HasColumnName("id").ValueGeneratedOnAdd();
            entityBuilder.Property(x => x.CategoryId).HasColumnName("category_id");
            entityBuilder.Property(x => x.Name).HasColumnName("name");
            entityBuilder.Property(x => x.Description).HasColumnName("description");
            entityBuilder.Property(x => x.Price).HasColumnName("price");
        }
    }

    internal class OrderItemsMap
    {
        public OrderItemsMap(EntityTypeBuilder<OrderItem> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.ToTable("orderitems");

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
            entityBuilder.ToTable("orders");

            entityBuilder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();
            entityBuilder.Property(x => x.OrderId).HasColumnName("order_id").IsRequired(true);
            entityBuilder.Property(x => x.CustomerId).HasColumnName("customer_id").IsRequired(true);
            entityBuilder.Property(x => x.OrderStatus).HasColumnName("order_status").IsRequired(true).HasMaxLength(2);
            entityBuilder.Property(x => x.Total).HasColumnName("total");
        }
    }
}