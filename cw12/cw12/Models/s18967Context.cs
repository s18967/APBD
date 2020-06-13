using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace cw12.Models
{
    public partial class s18967Context : DbContext
    {
        public s18967Context()
        {
        }

        public s18967Context(DbContextOptions<s18967Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Doctors> Doctors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s18967;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctors>(entity =>
            {
                entity.HasKey(e => e.IdDoctor);

                entity.HasIndex(e => e.DoctorIdDoctor);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.HasOne(d => d.DoctorIdDoctorNavigation)
                    .WithMany(p => p.InverseDoctorIdDoctorNavigation)
                    .HasForeignKey(d => d.DoctorIdDoctor);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
