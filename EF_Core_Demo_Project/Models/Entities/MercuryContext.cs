using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace EF_Core_Demo_Project.Models.Entities
{
    public partial class MercuryContext : DbContext
    {
        public MercuryContext()
        {
        }

        public MercuryContext(DbContextOptions<MercuryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Kontaktuppgifter> Kontaktuppgifters { get; set; }
        public virtual DbSet<P2a> P2as { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Personal> Personals { get; set; }
        public virtual DbSet<Personal1> Personals1 { get; set; }
        public virtual DbSet<Sektion1> Sektion1s { get; set; }
        public virtual DbSet<Sektion2> Sektion2s { get; set; }
        public virtual DbSet<StrangeTable> StrangeTables { get; set; }
        public virtual DbSet<TestTabell> TestTabells { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Mercury;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasIndex(e => new { e.Street, e.City, e.ZipCode }, "UQ__Addresse__8F22AFF071FDAD2D")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdated).HasColumnType("datetime");

                entity.Property(e => e.Street)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(16)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Kontaktuppgifter>(entity =>
            {
                entity.ToTable("Kontaktuppgifter");

                entity.HasIndex(e => e.Kontaktuppgift, "UQ__Kontaktu__E2339366B478945E")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Kontakttyp)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Kontaktuppgift)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.PersonsId).HasColumnName("PersonsID");

                entity.HasOne(d => d.Persons)
                    .WithMany(p => p.Kontaktuppgifters)
                    .HasForeignKey(d => d.PersonsId)
                    .HasConstraintName("FK__Kontaktup__Perso__5165187F");
            });

            modelBuilder.Entity<P2a>(entity =>
            {
                entity.ToTable("P2A");

                entity.HasIndex(e => new { e.PersonsId, e.AddressesId }, "UQ__P2A__215206A3FD5450CA")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AddressesId).HasColumnName("AddressesID");

                entity.Property(e => e.PersonsId).HasColumnName("PersonsID");

                entity.HasOne(d => d.Addresses)
                    .WithMany(p => p.P2as)
                    .HasForeignKey(d => d.AddressesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__P2A__AddressesID__5DCAEF64");

                entity.HasOne(d => d.Persons)
                    .WithMany(p => p.P2as)
                    .HasForeignKey(d => d.PersonsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__P2A__PersonsID__5CD6CB2B");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasIndex(e => e.Personnr, "UQ__Persons__AA2D1726378364F1")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FirstName)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Personnr)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Personal>(entity =>
            {
                entity.ToTable("Personal");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.ChefsId).HasColumnName("ChefsID");

                entity.Property(e => e.Lön).HasColumnType("money");

                entity.Property(e => e.Namn)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Titel)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.HasOne(d => d.Chefs)
                    .WithMany(p => p.InverseChefs)
                    .HasForeignKey(d => d.ChefsId)
                    .HasConstraintName("FK__Personal__ChefsI__398D8EEE");
            });

            modelBuilder.Entity<Personal1>(entity =>
            {
                entity.ToTable("Personal", "HR");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<Sektion1>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Sektion1");

                entity.Property(e => e.ChefsId).HasColumnName("ChefsID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Lön).HasColumnType("money");

                entity.Property(e => e.Namn)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Titel)
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sektion2>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Sektion2");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Salary).HasColumnType("money");

                entity.Property(e => e.Title)
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<StrangeTable>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Strange Table");

                entity.Property(e => e.Insert)
                    .HasMaxLength(6)
                    .IsUnicode(false)
                    .HasComment("SQL_Latin1_General_CP1_CI_AS");

                entity.Property(e => e.Update)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasComment("SQL_Latin1_General_CP1_CI_AS");
            });

            modelBuilder.Entity<TestTabell>(entity =>
            {
                entity.ToTable("TestTabell", "HR");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
