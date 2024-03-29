﻿// <auto-generated />
using System;
using Belt_exam.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Belt_exam.Migrations
{
    [DbContext(typeof(BeltContext))]
    partial class BeltContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Belt_exam.Models.Act", b =>
                {
                    b.Property<int>("ActId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CoordinatorId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<DateTime>("Date");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<int>("Duration");

                    b.Property<string>("DurationType");

                    b.Property<DateTime>("Time");

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("ActId");

                    b.HasIndex("CoordinatorId");

                    b.ToTable("activities");
                });

            modelBuilder.Entity("Belt_exam.Models.Attending", b =>
                {
                    b.Property<int>("AttendingId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("ThisActId");

                    b.Property<int>("ThisUserId");

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("AttendingId");

                    b.HasIndex("ThisActId");

                    b.HasIndex("ThisUserId");

                    b.ToTable("attendees");
                });

            modelBuilder.Entity("Belt_exam.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("UserId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Belt_exam.Models.Act", b =>
                {
                    b.HasOne("Belt_exam.Models.User", "Coordinator")
                        .WithMany()
                        .HasForeignKey("CoordinatorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Belt_exam.Models.Attending", b =>
                {
                    b.HasOne("Belt_exam.Models.Act", "ThisAct")
                        .WithMany("UsersAttending")
                        .HasForeignKey("ThisActId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Belt_exam.Models.User", "ThisUser")
                        .WithMany("ActAttending")
                        .HasForeignKey("ThisUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
