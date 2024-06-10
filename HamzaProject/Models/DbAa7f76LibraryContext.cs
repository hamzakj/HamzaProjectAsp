using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HamzaProject.Models
{
    public partial class DbAa7f76LibraryContext : DbContext
    {
        public DbAa7f76LibraryContext()
        {
        }

        public DbAa7f76LibraryContext(DbContextOptions<DbAa7f76LibraryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Books { get; set; }

        public virtual DbSet<Student> Students { get; set; }

        public virtual DbSet<StudentBorrow> StudentBorrows { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=SQL6032.site4now.net;Initial Catalog=db_aa7f76_library;User Id=db_aa7f76_library_admin;Password=library@123");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Books__3214EC27AB6DE03F");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Students__3214EC27DB546C55");

                entity.HasIndex(e => e.Number).IsUnique().HasDatabaseName("UQ__Students__78A1A19DDB903B9D");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.Name).HasMaxLength(100);
                entity.Property(e => e.Number).HasMaxLength(50);
            });

            modelBuilder.Entity<StudentBorrow>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__StudentB__3214EC275C611D63");

                entity.Property(e => e.Id).HasColumnName("ID");
                entity.Property(e => e.BookId).HasColumnName("BookID");
                entity.Property(e => e.StudentId).HasColumnName("StudentID");

                entity.HasOne(d => d.Book).WithMany(p => p.StudentBorrows)
                    .HasForeignKey(d => d.BookId)
                    .HasConstraintName("FK__StudentBo__BookI__571DF1D5");

                entity.HasOne(d => d.Student).WithMany(p => p.StudentBorrows)
                    .HasForeignKey(d => d.StudentId)
                    .HasConstraintName("FK__StudentBo__Stude__5812160E");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
