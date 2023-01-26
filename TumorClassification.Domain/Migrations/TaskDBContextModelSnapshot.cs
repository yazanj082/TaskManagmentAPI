﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TasksAPI.Persistence.Data;

#nullable disable

namespace TasksAPI.Persistence.Migrations
{
    [DbContext(typeof(TaskDBContext))]
    partial class TaskDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TasksAPI.Persistence.Data.TaskData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.HasIndex("Title", "UserId")
                        .IsUnique();

                    b.ToTable("Task");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            EndDate = new DateTime(2023, 1, 26, 8, 41, 57, 746, DateTimeKind.Utc).AddTicks(3222),
                            StartDate = new DateTime(2023, 1, 26, 11, 41, 57, 746, DateTimeKind.Local).AddTicks(3152),
                            Title = "Study",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("TasksAPI.Persistence.Data.UserData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserName")
                        .IsUnique();

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Password = "MTIzNDU2dGhpcyBpcyBteSBjdXN0b20gU2VjcmV0IGtleSBmb3IgYXV0aG5ldGljYXRpb24=",
                            UserName = "yazan"
                        });
                });

            modelBuilder.Entity("TasksAPI.Persistence.Data.TaskData", b =>
                {
                    b.HasOne("TasksAPI.Persistence.Data.UserData", "Owner")
                        .WithMany("Tasks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("TasksAPI.Persistence.Data.UserData", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
