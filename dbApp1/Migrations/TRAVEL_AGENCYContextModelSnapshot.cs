﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dbApp1;

namespace dbApp1.Migrations
{
    [DbContext(typeof(TRAVEL_AGENCYContext))]
    partial class TRAVEL_AGENCYContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("dbApp1.Care", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("TicketId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TicketId");

                    b.ToTable("CARE");
                });

            modelBuilder.Entity("dbApp1.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CardId")
                        .HasColumnType("int")
                        .HasColumnName("CardID");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("PhoneNumber")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "CardId", "PhoneNumber" }, "UQ__CLIENT__DDA1796C7F277D7D")
                        .IsUnique()
                        .HasFilter("[PhoneNumber] IS NOT NULL");

                    b.ToTable("CLIENT");
                });

            modelBuilder.Entity("dbApp1.Company", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("WorkerNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("COMPANY");
                });

            modelBuilder.Entity("dbApp1.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Name" }, "UQ_COUNTRY_Name")
                        .IsUnique();

                    b.ToTable("COUNTRY");
                });

            modelBuilder.Entity("dbApp1.CountryResort", b =>
                {
                    b.Property<string>("CountryName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("ResortName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.ToView("CountryResort");
                });

            modelBuilder.Entity("dbApp1.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bed")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool?>("Conditioner")
                        .HasColumnType("bit");

                    b.Property<bool?>("MiniBar")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int?>("ResortId")
                        .HasColumnType("int");

                    b.Property<string>("Room")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool?>("Safe")
                        .HasColumnType("bit");

                    b.Property<int>("StarsNumber")
                        .HasColumnType("int");

                    b.Property<bool?>("WiFi")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("ResortId");

                    b.ToTable("HOTEL");
                });

            modelBuilder.Entity("dbApp1.NewClient", b =>
                {
                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("ClientName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime?>("FirstTime")
                        .HasColumnType("date");

                    b.Property<string>("HotelName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("NumTicket")
                        .HasColumnType("int");

                    b.Property<string>("ResortName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime?>("SecondTime")
                        .HasColumnType("date");

                    b.ToView("NewClient");
                });

            modelBuilder.Entity("dbApp1.Ordering", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<int>("TicketNumber")
                        .HasColumnType("int");

                    b.Property<int?>("WorkerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("WorkerId");

                    b.ToTable("ORDERING");
                });

            modelBuilder.Entity("dbApp1.Resort", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.HasIndex(new[] { "Name" }, "UQ_RESORT_Name")
                        .IsUnique();

                    b.ToTable("RESORT");
                });

            modelBuilder.Entity("dbApp1.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cost")
                        .HasColumnType("int");

                    b.Property<int?>("HotelId")
                        .HasColumnType("int");

                    b.Property<int?>("OrderingId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("TimeArrival")
                        .HasColumnType("date");

                    b.Property<DateTime?>("TimeDeparture")
                        .HasColumnType("date");

                    b.Property<int>("TouristNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("HotelId");

                    b.HasIndex("OrderingId");

                    b.ToTable("TICKET");
                });

            modelBuilder.Entity("dbApp1.Worker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<double>("Bonus")
                        .HasColumnType("float");

                    b.Property<int>("CardId")
                        .HasColumnType("int")
                        .HasColumnName("CardID");

                    b.Property<int>("CodeId")
                        .HasColumnType("int")
                        .HasColumnName("CodeID");

                    b.Property<int?>("CompanyId")
                        .HasColumnType("int");

                    b.Property<string>("MiddleName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("PhoneNumber")
                        .HasColumnType("int");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("Wage")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex(new[] { "CardId", "CodeId", "PhoneNumber" }, "UQ__WORKER__2116D40233C00CD6")
                        .IsUnique();

                    b.ToTable("WORKER");
                });

            modelBuilder.Entity("dbApp1.Care", b =>
                {
                    b.HasOne("dbApp1.Ticket", "Ticket")
                        .WithMany("Cares")
                        .HasForeignKey("TicketId")
                        .HasConstraintName("FK_CARE_To_TICKET")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Ticket");
                });

            modelBuilder.Entity("dbApp1.Hotel", b =>
                {
                    b.HasOne("dbApp1.Resort", "Resort")
                        .WithMany("Hotels")
                        .HasForeignKey("ResortId")
                        .HasConstraintName("FK_HOTEL_To_RESORT")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Resort");
                });

            modelBuilder.Entity("dbApp1.Ordering", b =>
                {
                    b.HasOne("dbApp1.Client", "Client")
                        .WithMany("Orderings")
                        .HasForeignKey("ClientId")
                        .HasConstraintName("FK_ORDERING_To_CLIENT")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("dbApp1.Worker", "Worker")
                        .WithMany("Orderings")
                        .HasForeignKey("WorkerId")
                        .HasConstraintName("FK_ORDERING_To_WORKER")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Client");

                    b.Navigation("Worker");
                });

            modelBuilder.Entity("dbApp1.Resort", b =>
                {
                    b.HasOne("dbApp1.Country", "Country")
                        .WithMany("Resorts")
                        .HasForeignKey("CountryId")
                        .HasConstraintName("FK_RESORT_To_COUNTRY")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Country");
                });

            modelBuilder.Entity("dbApp1.Ticket", b =>
                {
                    b.HasOne("dbApp1.Hotel", "Hotel")
                        .WithMany("Tickets")
                        .HasForeignKey("HotelId")
                        .HasConstraintName("FK_TICKET_To_HOTEL")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("dbApp1.Ordering", "Ordering")
                        .WithMany("Tickets")
                        .HasForeignKey("OrderingId")
                        .HasConstraintName("FK_TICKET_To_ORDERING")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Hotel");

                    b.Navigation("Ordering");
                });

            modelBuilder.Entity("dbApp1.Worker", b =>
                {
                    b.HasOne("dbApp1.Company", "Company")
                        .WithMany("Workers")
                        .HasForeignKey("CompanyId")
                        .HasConstraintName("FK_WORKER_To_COMPANY")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Company");
                });

            modelBuilder.Entity("dbApp1.Client", b =>
                {
                    b.Navigation("Orderings");
                });

            modelBuilder.Entity("dbApp1.Company", b =>
                {
                    b.Navigation("Workers");
                });

            modelBuilder.Entity("dbApp1.Country", b =>
                {
                    b.Navigation("Resorts");
                });

            modelBuilder.Entity("dbApp1.Hotel", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("dbApp1.Ordering", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("dbApp1.Resort", b =>
                {
                    b.Navigation("Hotels");
                });

            modelBuilder.Entity("dbApp1.Ticket", b =>
                {
                    b.Navigation("Cares");
                });

            modelBuilder.Entity("dbApp1.Worker", b =>
                {
                    b.Navigation("Orderings");
                });
#pragma warning restore 612, 618
        }
    }
}
