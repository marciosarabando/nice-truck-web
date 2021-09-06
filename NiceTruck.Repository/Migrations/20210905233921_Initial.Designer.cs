﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NiceTruck.Repository.Data;

namespace NiceTruck.Repository.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20210905233921_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.9");

            modelBuilder.Entity("NiceTruck.Domain.Entities.Truck", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<bool>("Active")
                        .HasColumnType("INTEGER")
                        .HasColumnName("st_active");

                    b.Property<DateTime>("DateTimeCreated")
                        .HasColumnType("TEXT")
                        .HasColumnName("dt_created");

                    b.Property<DateTime?>("DateTimeUpdated")
                        .HasColumnType("TEXT")
                        .HasColumnName("dt_updated");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT")
                        .HasColumnName("ds_description");

                    b.Property<int>("FabricationYear")
                        .HasColumnType("INTEGER")
                        .HasColumnName("cd_fab_year");

                    b.Property<int>("IdTruckModel")
                        .HasColumnType("INTEGER")
                        .HasColumnName("id_truck_model");

                    b.Property<int>("ModelYear")
                        .HasColumnType("INTEGER")
                        .HasColumnName("cd_model_year");

                    b.HasKey("Id");

                    b.HasIndex("IdTruckModel");

                    b.ToTable("tb_truck");
                });

            modelBuilder.Entity("NiceTruck.Domain.Entities.TruckModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<bool>("Active")
                        .HasColumnType("INTEGER")
                        .HasColumnName("st_active");

                    b.Property<DateTime>("DateTimeCreated")
                        .HasColumnType("TEXT")
                        .HasColumnName("dt_created");

                    b.Property<DateTime?>("DateTimeUpdated")
                        .HasColumnType("TEXT")
                        .HasColumnName("dt_updated");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT")
                        .HasColumnName("ds_description");

                    b.HasKey("Id");

                    b.ToTable("tb_truck_model");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Active = true,
                            DateTimeCreated = new DateTime(2021, 9, 5, 20, 39, 21, 204, DateTimeKind.Local).AddTicks(1100),
                            Description = "FH"
                        },
                        new
                        {
                            Id = 2,
                            Active = true,
                            DateTimeCreated = new DateTime(2021, 9, 5, 20, 39, 21, 225, DateTimeKind.Local).AddTicks(8850),
                            Description = "FM"
                        });
                });

            modelBuilder.Entity("NiceTruck.Domain.Entities.Truck", b =>
                {
                    b.HasOne("NiceTruck.Domain.Entities.TruckModel", "TruckModel")
                        .WithMany("Trucks")
                        .HasForeignKey("IdTruckModel")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TruckModel");
                });

            modelBuilder.Entity("NiceTruck.Domain.Entities.TruckModel", b =>
                {
                    b.Navigation("Trucks");
                });
#pragma warning restore 612, 618
        }
    }
}
