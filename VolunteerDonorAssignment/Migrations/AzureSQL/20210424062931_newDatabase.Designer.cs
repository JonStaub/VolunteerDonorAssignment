﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VolunteerDonorAssignment.Data;

namespace VolunteerDonorAssignment.Migrations.AzureSQL
{
    [DbContext(typeof(AzureSQLContext))]
    [Migration("20210424062931_newDatabase")]
    partial class newDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VolunteerDonorAssignment.Models.Donation", b =>
                {
                    b.Property<int>("DonationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DonorId")
                        .HasColumnType("int");

                    b.HasKey("DonationId");

                    b.HasIndex("DonorId");

                    b.ToTable("Donations");
                });

            modelBuilder.Entity("VolunteerDonorAssignment.Models.Donor", b =>
                {
                    b.Property<int>("DonorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DonorId");

                    b.ToTable("Donors");
                });

            modelBuilder.Entity("VolunteerDonorAssignment.Models.DonorNote", b =>
                {
                    b.Property<int>("DonorNoteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DonorId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EntryDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VolunteerId")
                        .HasColumnType("int");

                    b.HasKey("DonorNoteId");

                    b.HasIndex("DonorId");

                    b.HasIndex("VolunteerId");

                    b.ToTable("DonorNotes");
                });

            modelBuilder.Entity("VolunteerDonorAssignment.Models.Email", b =>
                {
                    b.Property<int>("EmailId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DonorId")
                        .HasColumnType("int");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VolunteerId")
                        .HasColumnType("int");

                    b.HasKey("EmailId");

                    b.HasIndex("DonorId");

                    b.HasIndex("VolunteerId");

                    b.ToTable("Emails");
                });

            modelBuilder.Entity("VolunteerDonorAssignment.Models.Volunteer", b =>
                {
                    b.Property<int>("VolunteerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VolunteerId");

                    b.ToTable("Volunteers");
                });

            modelBuilder.Entity("VolunteerDonorAssignment.Models.Donation", b =>
                {
                    b.HasOne("VolunteerDonorAssignment.Models.Donor", "Donor")
                        .WithMany("Donations")
                        .HasForeignKey("DonorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Donor");
                });

            modelBuilder.Entity("VolunteerDonorAssignment.Models.DonorNote", b =>
                {
                    b.HasOne("VolunteerDonorAssignment.Models.Donor", "Donor")
                        .WithMany("DonorNotes")
                        .HasForeignKey("DonorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VolunteerDonorAssignment.Models.Volunteer", null)
                        .WithMany("DonorNotes")
                        .HasForeignKey("VolunteerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Donor");
                });

            modelBuilder.Entity("VolunteerDonorAssignment.Models.Email", b =>
                {
                    b.HasOne("VolunteerDonorAssignment.Models.Donor", "Donor")
                        .WithMany("Emails")
                        .HasForeignKey("DonorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VolunteerDonorAssignment.Models.Volunteer", "Volunteer")
                        .WithMany("Emails")
                        .HasForeignKey("VolunteerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Donor");

                    b.Navigation("Volunteer");
                });

            modelBuilder.Entity("VolunteerDonorAssignment.Models.Donor", b =>
                {
                    b.Navigation("Donations");

                    b.Navigation("DonorNotes");

                    b.Navigation("Emails");
                });

            modelBuilder.Entity("VolunteerDonorAssignment.Models.Volunteer", b =>
                {
                    b.Navigation("DonorNotes");

                    b.Navigation("Emails");
                });
#pragma warning restore 612, 618
        }
    }
}