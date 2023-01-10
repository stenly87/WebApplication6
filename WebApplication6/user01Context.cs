using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication6
{
    public partial class user01Context : DbContext
    {
        public user01Context()
        {
        }

        public user01Context(DbContextOptions<user01Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Session> Sessions { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=192.168.200.35;user=user01;password=83328;database=user01;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Session>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK_Sessions_1");

                entity.Property(e => e.IdUser)
                    .ValueGeneratedNever()
                    .HasColumnName("id_user");

                entity.Property(e => e.Expiration)
                    .HasColumnType("datetime")
                    .HasColumnName("expiration");

                entity.Property(e => e.SessionKey)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("session_key");

                entity.Property(e => e.Start)
                    .HasColumnType("datetime")
                    .HasColumnName("start");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithOne(p => p.Session)
                    .HasForeignKey<Session>(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Sessions_Users");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Fio)
                    .HasMaxLength(250)
                    .HasColumnName("fio");

                entity.Property(e => e.Login)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("login");

                entity.Property(e => e.Password)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("password");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
