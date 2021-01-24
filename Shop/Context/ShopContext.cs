using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop.Host.Models.Identity;
using Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Context
{
    public class ShopContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>,
      ApplicationUserRole, IdentityUserLogin<string>,
      IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public ShopContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<Tags> Tags { get; set; }
        public virtual DbSet<Vender> vender { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>().ToTable("User");
            modelBuilder.Entity<ApplicationRole>().ToTable("Role"); 

            modelBuilder.Entity<Tags>()
                .HasOne<Vender>(s => s.Vender)
                .WithMany(g => g.Tags)
                .HasForeignKey(s => s.VenderId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<ApplicationUserRole>().HasKey(x => x.Id);


            modelBuilder.Entity<ApplicationUserRole>()
                .HasOne(u => u.User)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(fk => fk.UserId);


            modelBuilder.Entity<ApplicationUserRole>()
                .HasOne(u => u.Role)
                .WithMany(r => r.ApplicationUserRole)
                .HasForeignKey(fk => fk.RoleId);

            modelBuilder.Entity<ApplicationUserRole>().ToTable("UserRole");

            modelBuilder.Ignore<IdentityRoleClaim<string>>();
            modelBuilder.Ignore<IdentityUserClaim<string>>();
            modelBuilder.Ignore<IdentityUserLogin<string>>();
            modelBuilder.Ignore<IdentityUserToken<string>>();
        }
    }
}
