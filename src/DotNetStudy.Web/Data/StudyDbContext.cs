using DotNetStudy.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetStudy.Web.Data
{
    public class StudyDbContext : DbContext
    {
        public StudyDbContext(DbContextOptions options) : base(options)
        {

        }
        public StudyDbContext()
        {

        }
        public DbSet<Goods> Goods { get; set; }
        public DbSet<GoodsImgae> GoodsImgaes { get; set; }
        public DbSet<GoodsType> GoodsTypes { get; set; }
        public DbSet<GoodsAttribute> GoodsAttributes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> orderDetails { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Purse> Purses { get; set; } 
        public DbSet<MyAddress> MyAddresses { get; set; }
        public DbSet<Trade> Trades { get; set; }
        //....

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(e =>
            {
                e.ToTable("Users");
                e.HasKey(k => k.Id);
                e.Property(p => p.UserName).HasMaxLength(256);
            });
            modelBuilder.Entity<Order>(e =>
            {
                e.ToTable("Orders");
                e.HasKey(k => k.Id);
                e.Property(p => p.OrderNo).HasMaxLength(256);
                e.Property(p => p.Amount).HasColumnType("decimal(10,2)");
                e.Property(p => p.OrderStatus).HasMaxLength(128);
               
            });          
            modelBuilder.Entity<OrderDetail>(e =>
            {
                e.ToTable("OrderDetails");
                e.HasKey(k => k.Id);
                e.Property(p => p.ProductName).HasMaxLength(512);
                e.Property(p => p.UnitPrice).HasColumnType("decimal(10,2)");
                e.HasOne(orderDetail => orderDetail.Order).WithMany(m => m.OrderDetails).HasForeignKey(x => x.OrderId);
               
            });
            modelBuilder.Entity<Cart>(e =>
            {
                e.ToTable("Carts");
                e.HasKey(k => k.Id);
                e.Property(p => p.ProductName).HasMaxLength(256);
                e.Property(p => p.UnitPrice).HasColumnType("decimal(10,2)");
                e.Property(p => p.UserName).HasMaxLength(256);
            });
            modelBuilder.Entity<Address>(e =>
            {
                e.ToTable("Addresses");
                e.HasKey(k => k.Id);
                e.Property(p => p.Consignee).HasMaxLength(128);
                e.Property(p => p.DeliveryAddress).HasMaxLength(512);
                e.HasOne(address => address.Order).WithOne(m => m.Address).HasForeignKey<Address>(x => x.OrderId);
            });
            modelBuilder.Entity<MyAddress>(e =>
            {
                e.ToTable("MyAddresses");
                e.HasKey(k => k.Id);
                e.Property(p => p.Receiver).HasMaxLength(128);
                e.Property(p => p.Phone).HasMaxLength(128);
                e.Property(p => p.Address).HasMaxLength(128);
                e.Property(p => p.AddressInfo).HasMaxLength(512);
            });
            modelBuilder.Entity<Purse>(e =>
            {
                e.ToTable("Purses");
                e.HasKey(k => k.Id);
                e.Property(p => p.Balance).HasColumnType("decimal(10,2)");
            });
            modelBuilder.Entity<Goods>(e =>
            {
                e.ToTable("Goods");
                e.HasKey(k => k.GoodsId);
                e.Property(p => p.GoodsName).HasMaxLength(256);
                e.Property(p => p.Price).HasColumnType("decimal(10,2)");
                e.Property(p => p.Desc).HasMaxLength(1024);
            });
            modelBuilder.Entity<GoodsType>(e =>
            {
                e.ToTable("GoodsType");
                e.HasKey(k => k.GoodsTypeId);
                e.Property(p => p.GoodsTypeName).HasMaxLength(256);
            });

            modelBuilder.Entity<GoodsImgae>(e =>
            {
                e.ToTable("GoodsImgae");
                e.HasKey(k => k.Id);
                e.Property(p => p.GoodsImgaeName).HasMaxLength(256);
                e.Property(p => p.Size).HasColumnType("decimal(10,2)");
            });
            modelBuilder.Entity<GoodsAttribute>(e =>
            {
                e.ToTable("GoodsAttribute");
                e.HasKey(k => k.GoodsAttributeId);
                e.Property(p => p.GoodsAttributeName).HasMaxLength(64);
                e.Property(p => p.GoodsAttributeValue).HasMaxLength(256);
            });
            modelBuilder.Entity<Trade>(e =>
            {
                e.ToTable("Trades");
                e.HasKey(k => k.Id);
                e.Property(p => p.No).HasMaxLength(128);
                e.Property(p => p.Amount).HasColumnType("decimal(10,2)");
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
