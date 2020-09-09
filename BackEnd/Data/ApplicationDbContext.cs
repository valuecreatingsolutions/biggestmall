using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Pomelo.EntityFrameworkCore.MySql;

using BackEnd.Models;

namespace BackEnd.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string, IdentityUserClaim<string>, ApplicationUserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>(entity => entity.HasIndex(k => k.UserName).IsUnique(true));
            //builder.Entity<ApplicationUser>(entity => entity.HasIndex(k => k.Email).IsUnique(true));
            builder.Entity<ApplicationUser>().ToTable("ems_users").HasKey(k => new { k.Id });
            builder.Entity<ApplicationRole>().ToTable("ems_roles").HasKey(k => new { k.Id });
            builder.Entity<ApplicationUserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });
                userRole.HasOne(ur => ur.Role)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.RoleId)
                .IsRequired();
                userRole.HasOne(ur => ur.User)
                .WithMany(r => r.UserRoles)
                .HasForeignKey(ur => ur.UserId)
                .IsRequired();
            });
            builder.Entity<ApplicationUserRole>().ToTable("ems_user_roles").HasKey(k => new { k.UserId, k.RoleId });
            builder.Entity<IdentityUserLogin<string>>().ToTable("ems_user_logins").HasKey(k => new { k.LoginProvider, k.ProviderKey, k.UserId });
            builder.Entity<IdentityUserClaim<string>>().ToTable("ems_user_claims").HasKey(k => new { k.Id });
            builder.Entity<IdentityUserToken<string>>().ToTable("ems_user_tokens").HasKey(k => new { k.UserId });
            builder.Entity<IdentityRoleClaim<string>>().ToTable("ems_role_claims").HasKey(k => new { k.Id });
        }
    }
}
