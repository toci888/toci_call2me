using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Toci.Call2Me.Database.Persistence.Models
{
    public partial class TociCall2MeContext : DbContext
    {
        public TociCall2MeContext()
        {
        }

        public TociCall2MeContext(DbContextOptions<TociCall2MeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Friend> Friends { get; set; } = null!;
        public virtual DbSet<Incall> Incalls { get; set; } = null!;
        public virtual DbSet<Preference> Preferences { get; set; } = null!;
        public virtual DbSet<Status> Statuses { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=Toci.Call2Me;Username=postgres;Password=beatka");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Friend>(entity =>
            {
                entity.ToTable("friends");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Idusers).HasColumnName("idusers");

                entity.Property(e => e.Idusersfriend).HasColumnName("idusersfriend");

                entity.HasOne(d => d.IdusersNavigation)
                    .WithMany(p => p.FriendIdusersNavigations)
                    .HasForeignKey(d => d.Idusers)
                    .HasConstraintName("friends_idusers_fkey");

                entity.HasOne(d => d.IdusersfriendNavigation)
                    .WithMany(p => p.FriendIdusersfriendNavigations)
                    .HasForeignKey(d => d.Idusersfriend)
                    .HasConstraintName("friends_idusersfriend_fkey");
            });

            modelBuilder.Entity<Incall>(entity =>
            {
                entity.ToTable("incall");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Idusers).HasColumnName("idusers");

                entity.Property(e => e.Iduserscall).HasColumnName("iduserscall");

                entity.HasOne(d => d.IdusersNavigation)
                    .WithMany(p => p.IncallIdusersNavigations)
                    .HasForeignKey(d => d.Idusers)
                    .HasConstraintName("incall_idusers_fkey");

                entity.HasOne(d => d.IduserscallNavigation)
                    .WithMany(p => p.IncallIduserscallNavigations)
                    .HasForeignKey(d => d.Iduserscall)
                    .HasConstraintName("incall_iduserscall_fkey");
            });

            modelBuilder.Entity<Preference>(entity =>
            {
                entity.ToTable("preferences");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Allowflag).HasColumnName("allowflag");

                entity.Property(e => e.Idusers).HasColumnName("idusers");

                entity.HasOne(d => d.IdusersNavigation)
                    .WithMany(p => p.Preferences)
                    .HasForeignKey(d => d.Idusers)
                    .HasConstraintName("preferences_idusers_fkey");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("status");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasColumnName("name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Idstatus).HasColumnName("idstatus");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Phonenumber).HasColumnName("phonenumber");

                entity.Property(e => e.Surname).HasColumnName("surname");

                entity.HasOne(d => d.IdstatusNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.Idstatus)
                    .HasConstraintName("users_idstatus_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
