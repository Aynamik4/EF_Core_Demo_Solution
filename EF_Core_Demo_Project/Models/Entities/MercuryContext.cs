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
        public virtual DbSet<Adressbok> Adressboks { get; set; }
        public virtual DbSet<Fruit> Fruits { get; set; }
        public virtual DbSet<HistoricalPrice> HistoricalPrices { get; set; }
        public virtual DbSet<Kontaktuppgifter> Kontaktuppgifters { get; set; }
        public virtual DbSet<P2a> P2as { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<Person1> Persons1 { get; set; }
        public virtual DbSet<Personal> Personals { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Select> Selects { get; set; }
        public virtual DbSet<StrangeTable> StrangeTables { get; set; }

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
                entity.HasIndex(e => new { e.Street, e.City, e.ZipCode }, "UQ__Addresse__8F22AFF0E25A98B9")
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

            modelBuilder.Entity<Adressbok>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("Adressbok");

                entity.Property(e => e.Efternamn)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Förnamn)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Gata)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Kontakttyp)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Kontaktuppgift)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Ort)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Personnr)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.Postnr)
                    .HasMaxLength(16)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Fruit>(entity =>
            {
                entity.HasIndex(e => new { e.FruitType, e.FruitName }, "UQ__Fruits__FE7D1CBD5525D6FE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FruitName)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.FruitType)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.PricePerKg).HasColumnType("money");
            });

            modelBuilder.Entity<HistoricalPrice>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ChangeDate).HasColumnType("datetime");

                entity.Property(e => e.NewPrice).HasColumnType("money");

                entity.Property(e => e.OldPrice).HasColumnType("money");

                entity.Property(e => e.ProductsId).HasColumnName("ProductsID");

                entity.HasOne(d => d.Products)
                    .WithMany(p => p.HistoricalPrices)
                    .HasForeignKey(d => d.ProductsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Historica__Produ__2B0A656D");
            });

            modelBuilder.Entity<Kontaktuppgifter>(entity =>
            {
                entity.ToTable("Kontaktuppgifter");

                entity.HasIndex(e => e.Kontaktuppgift, "UQ__Kontaktu__E23393663D36DCA4")
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
                    .HasConstraintName("FK__Kontaktup__Perso__60A75C0F");
            });

            modelBuilder.Entity<P2a>(entity =>
            {
                entity.ToTable("P2A");

                entity.HasIndex(e => new { e.PersonsId, e.AddressesId }, "UQ__P2A__215206A3BABC7E1E")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AddressesId).HasColumnName("AddressesID");

                entity.Property(e => e.PersonsId).HasColumnName("PersonsID");

                entity.HasOne(d => d.Addresses)
                    .WithMany(p => p.P2as)
                    .HasForeignKey(d => d.AddressesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__P2A__AddressesID__71D1E811");

                entity.HasOne(d => d.Persons)
                    .WithMany(p => p.P2as)
                    .HasForeignKey(d => d.PersonsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__P2A__PersonsID__70DDC3D8");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasIndex(e => e.Personnr, "UQ__Persons__AA2D17265EF7815E")
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

            modelBuilder.Entity<Person1>(entity =>
            {
                entity.ToTable("Persons", "HR");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.SomeValue)
                    .HasMaxLength(32)
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
                    .HasConstraintName("FK__Personal__ChefsI__5CD6CB2B");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateChanged2).HasDefaultValueSql("(getutcdate())");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(32)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Select>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Select");
            });

            modelBuilder.Entity<StrangeTable>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Strange Table");

                entity.Property(e => e.Insert)
                    .HasMaxLength(32)
                    .IsUnicode(false);

                entity.Property(e => e.Update)
                    .IsRequired()
                    .HasMaxLength(64)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
