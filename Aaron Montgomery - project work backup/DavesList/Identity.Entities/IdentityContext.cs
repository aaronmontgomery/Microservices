using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Identity.Entities
{
    public partial class IdentityContext : IdentityDbContext<
        ApplicationUser,
        ApplicationRole,
        int,
        ApplicationUserClaim,
        ApplicationUserRole,
        ApplicationUserLogin,
        ApplicationRoleClaim,
        ApplicationUserToken>
    {
        public IdentityContext()
        {
        }

        public IdentityContext(DbContextOptions<IdentityContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ApplicationRole> ApplicationRoles { get; set; } = null!;
        public virtual DbSet<ApplicationRoleClaim> ApplicationRoleClaims { get; set; } = null!;
        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;
        public virtual DbSet<ApplicationUserClaim> ApplicationUserClaims { get; set; } = null!;
        public virtual DbSet<ApplicationUserLogin> ApplicationUserLogins { get; set; } = null!;
        public virtual DbSet<ApplicationUserRole> ApplicationUserRoles { get; set; } = null!;
        public virtual DbSet<ApplicationUserToken> ApplicationUserTokens { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=Identity;User ID=sa;Password=localadmin");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationRole>(entity =>
            {
                entity.ToTable("ApplicationRole");
            });

            modelBuilder.Entity<ApplicationRoleClaim>(entity =>
            {
                entity.ToTable("ApplicationRoleClaim");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.ApplicationRoleClaims)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApplicationRoleClaim_RoleId");
            });

            modelBuilder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable("ApplicationUser");
            });

            modelBuilder.Entity<ApplicationUserClaim>(entity =>
            {
                entity.ToTable("ApplicationUserClaim");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ApplicationUserClaims)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApplicationUserClaim_ApplicationUser");
            });

            modelBuilder.Entity<ApplicationUserLogin>(entity =>
            {
                entity.ToTable("ApplicationUserLogin");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ApplicationUserLogins)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApplicationUserLogin_UserId");
            });

            modelBuilder.Entity<ApplicationUserRole>(entity =>
            {
                entity.HasKey(e => new { e.RoleId, e.UserId });

                entity.ToTable("ApplicationUserRole");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.ApplicationUserRoles)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApplicationUserRole_ApplicationRole");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ApplicationUserRoles)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApplicationUserRole_ApplicationUser");
            });

            modelBuilder.Entity<ApplicationUserToken>(entity =>
            {
                entity.ToTable("ApplicationUserToken");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ApplicationUserTokens)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ApplicationUserToken_UserId");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
