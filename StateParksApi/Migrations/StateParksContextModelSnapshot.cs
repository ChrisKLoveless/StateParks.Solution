﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StateParks.Models;

#nullable disable

namespace StateParksApi.Migrations
{
  [DbContext(typeof(StateParksContext))]
  partial class StateParksContextModelSnapshot : ModelSnapshot
  {
    protected override void BuildModel(ModelBuilder modelBuilder)
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
#pragma warning restore 612, 618
    }
  }
}
