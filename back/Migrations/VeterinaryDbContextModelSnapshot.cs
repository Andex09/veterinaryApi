﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using back.Models;

#nullable disable

namespace back.Migrations
{
    [DbContext(typeof(VeterinaryDbContext))]
    partial class VeterinaryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("back.Models.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("Breet")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Color")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreationDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<float>("Weight")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("Pets", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 4,
                            Breet = "Cat",
                            Color = "Brown",
                            CreationDate = new DateTime(2023, 4, 7, 20, 21, 49, 355, DateTimeKind.Local).AddTicks(8892),
                            Name = "Misha",
                            Weight = 20f
                        },
                        new
                        {
                            Id = 2,
                            Age = 9,
                            Breet = "Dog",
                            Color = "Black",
                            CreationDate = new DateTime(2023, 4, 7, 20, 21, 49, 355, DateTimeKind.Local).AddTicks(8903),
                            Name = "Zombra",
                            Weight = 30f
                        });
                });
#pragma warning restore 612, 618
        }
    }
}