using AuthorityManagement.Web.Models;
using DotNetStudy.Web.Models;
using DotNetStudy.Web.ViewModels.MyOrdersModels;
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
        
        public DbSet<User> Users { get; set; }
 
        public DbSet<Role> Roles { get; set; }
        public DbSet<RolePermission> RolePermissions{ get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        //....
        public DbSet<RoleClaims> RoleClaims { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(e =>
            {
                e.ToTable("Users");
                e.HasKey(k => k.Id);
                e.Property(p => p.UserName).HasMaxLength(256);
            });
         

            modelBuilder.Entity<RoleClaims>(e =>
            {
                e.ToTable("RoleClaims");
                e.HasKey(k => k.Id);             
                e.HasOne(RoleClaims => RoleClaims.Role).WithMany(m => m.RoleClaims).HasForeignKey(x => x.RoleId);
            });
          

            modelBuilder.Entity<UserRole>(e =>
            {
                e.ToTable("UserRole");
                 e.HasKey(k => k.Id);
                e.HasOne(UserRole => UserRole.User).WithMany(m => m.UserRole).HasForeignKey(x => x.UserId);
            });

            modelBuilder.Entity<Role>(e =>
            {
                e.ToTable("Role");
                e.HasKey(k => k.Id);
                e.Property(p => p.DisPlayName).HasMaxLength(128);
            });

            modelBuilder.Entity<RolePermission>(e =>
            {
                e.ToTable("RolePermission");
                e.HasKey(k => k.Id);
                e.Property(p => p.PermissionName).HasMaxLength(256);
                
            });


          
            base.OnModelCreating(modelBuilder);
        }
    }
}
