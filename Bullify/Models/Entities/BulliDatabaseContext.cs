using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Bullify.Models.Entities
{
    public partial class BulliDatabaseContext : DbContext
    {
        public virtual DbSet<Consultants> Consultants { get; set; }
        public virtual DbSet<Skills> Skills { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BullyDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Consultants>(entity =>
            {
                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("nchar(500)");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnType("nchar(50)");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnType("nchar(50)");
            });

            modelBuilder.Entity<Skills>(entity =>
            {
                entity.Property(e => e.ConsultantsId).HasColumnName("Consultants_Id");

                entity.Property(e => e.Skillset)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Consultants)
                    .WithMany(p => p.Skills)
                    .HasForeignKey(d => d.ConsultantsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Skills_ToTable");
            });
        }
    }
}
