using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace dbApp1
{
    public partial class TRAVEL_AGENCYContext : DbContext
    {
        public TRAVEL_AGENCYContext()
        {
        }

        public TRAVEL_AGENCYContext(DbContextOptions<TRAVEL_AGENCYContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Care> Cares { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<CountryResort> CountryResorts { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }
        public virtual DbSet<NewClient> NewClients { get; set; }
        public virtual DbSet<Ordering> Orderings { get; set; }
        public virtual DbSet<Resort> Resorts { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<Worker> Workers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=MSI;Database=TRAVEL_AGENCY;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Care>(entity =>
            {
                entity.ToTable("CARE");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.Ticket)
                    .WithMany(p => p.Cares)
                    .HasForeignKey(d => d.TicketId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_CARE_To_TICKET");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("CLIENT");

                entity.HasIndex(e => new { e.CardId, e.PhoneNumber }, "UQ__CLIENT__DDA1796C7F277D7D")
                    .IsUnique();

                entity.Property(e => e.CardId).HasColumnName("CardID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("COMPANY");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("COUNTRY");

                entity.HasIndex(e => e.Name, "UQ_COUNTRY_Name")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<CountryResort>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("CountryResort");

                entity.Property(e => e.CountryName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.ResortName)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Hotel>(entity =>
            {
                entity.ToTable("HOTEL");

                entity.Property(e => e.Bed)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Room)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.Resort)
                    .WithMany(p => p.Hotels)
                    .HasForeignKey(d => d.ResortId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_HOTEL_To_RESORT");
            });

            modelBuilder.Entity<NewClient>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("NewClient");

                entity.Property(e => e.ClientName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.FirstTime).HasColumnType("date");

                entity.Property(e => e.HotelName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ResortName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.SecondTime).HasColumnType("date");
            });

            modelBuilder.Entity<Ordering>(entity =>
            {
                entity.ToTable("ORDERING");

                entity.HasOne(d => d.Client)
                    .WithMany(p => p.Orderings)
                    .HasForeignKey(d => d.ClientId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_ORDERING_To_CLIENT");

                entity.HasOne(d => d.Worker)
                    .WithMany(p => p.Orderings)
                    .HasForeignKey(d => d.WorkerId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_ORDERING_To_WORKER");
            });

            modelBuilder.Entity<Resort>(entity =>
            {
                entity.ToTable("RESORT");

                entity.HasIndex(e => e.Name, "UQ_RESORT_Name")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Resorts)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_RESORT_To_COUNTRY");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("TICKET");

                entity.Property(e => e.TimeArrival).HasColumnType("date");

                entity.Property(e => e.TimeDeparture).HasColumnType("date");

                entity.HasOne(d => d.Hotel)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.HotelId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_TICKET_To_HOTEL");

                entity.HasOne(d => d.Ordering)
                    .WithMany(p => p.Tickets)
                    .HasForeignKey(d => d.OrderingId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_TICKET_To_ORDERING");
            });

            modelBuilder.Entity<Worker>(entity =>
            {
                entity.ToTable("WORKER");

                entity.HasIndex(e => new { e.CardId, e.CodeId, e.PhoneNumber }, "UQ__WORKER__2116D40233C00CD6")
                    .IsUnique();

                entity.Property(e => e.Address).HasMaxLength(30);

                entity.Property(e => e.CardId).HasColumnName("CardID");

                entity.Property(e => e.CodeId).HasColumnName("CodeID");

                entity.Property(e => e.MiddleName).HasMaxLength(30);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Workers)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK_WORKER_To_COMPANY");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
