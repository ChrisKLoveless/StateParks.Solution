﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StateParks.Models;

#nullable disable

namespace StateParksApi.Migrations
{
  [DbContext(typeof(StateParksContext))]
  [Migration("20230120230414_AddUser")]
  partial class AddUser
  {
    protected override void BuildTargetModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
      modelBuilder
          .HasAnnotation("ProductVersion", "6.0.0")
          .HasAnnotation("Relational:MaxIdentifierLength", 64);

      modelBuilder.Entity("StateParks.Models.Park", b =>
          {
            b.Property<int>("ParkId")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("int");

            b.Property<string>("Name")
                      .HasColumnType("longtext");

            b.Property<int>("StateId")
                      .HasColumnType("int");

            b.HasKey("ParkId");

            b.ToTable("Parks");

            b.HasData(
                      new
                  {
                    ParkId = 1,
                    Name = "Crater Lake",
                    StateId = 1
                  },
                      new
                  {
                    ParkId = 2,
                    Name = "Lewis and Clark",
                    StateId = 2
                  },
                      new
                  {
                    ParkId = 3,
                    Name = "Golden Gate",
                    StateId = 3
                  });
          });

      modelBuilder.Entity("StateParks.Models.State", b =>
          {
            b.Property<int>("StateId")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("int");

            b.Property<string>("Name")
                      .HasColumnType("longtext");

            b.HasKey("StateId");

            b.ToTable("States");

            b.HasData(
                      new
                  {
                    StateId = 1,
                    Name = "Oregon"
                  },
                      new
                  {
                    StateId = 2,
                    Name = "Washington"
                  },
                      new
                  {
                    StateId = 3,
                    Name = "California"
                  });
          });

      modelBuilder.Entity("StateParks.Models.User", b =>
          {
            b.Property<int>("UserId")
                      .ValueGeneratedOnAdd()
                      .HasColumnType("int");

            b.Property<string>("EmailAddress")
                      .HasColumnType("longtext");

            b.Property<string>("Password")
                      .HasColumnType("longtext");

            b.Property<string>("Role")
                      .HasColumnType("longtext");

            b.Property<string>("Username")
                      .HasColumnType("longtext");

            b.HasKey("UserId");

            b.ToTable("Users");

            b.HasData(
                      new
                  {
                    UserId = 1,
                    EmailAddress = "chris_admin@email.com",
                    Password = "chris123",
                    Role = "Administrator",
                    Username = "chris"
                  });
          });
#pragma warning restore 612, 618
    }
  }
}
