﻿// <auto-generated />
using System;
using AlgorithmsApp.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AlgorithmsApp.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20190729210229_AlgStatDate")]
    partial class AlgStatDate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity("AlgorithmsApp.API.Models.Algorithm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Algorithms");
                });

            modelBuilder.Entity("AlgorithmsApp.API.Models.AlgorithmStatistic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AlgorithmId");

                    b.Property<DateTime>("Date");

                    b.Property<long>("ExecutedTime");

                    b.Property<int>("MockDataId");

                    b.HasKey("Id");

                    b.HasIndex("AlgorithmId");

                    b.HasIndex("MockDataId");

                    b.ToTable("AlgorithmStatistics");
                });

            modelBuilder.Entity("AlgorithmsApp.API.Models.MockData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<long>("NumberOfElements");

                    b.Property<string>("SetOfData");

                    b.HasKey("Id");

                    b.ToTable("MockDatas");
                });

            modelBuilder.Entity("AlgorithmsApp.API.Models.AlgorithmStatistic", b =>
                {
                    b.HasOne("AlgorithmsApp.API.Models.Algorithm", "Algorithm")
                        .WithMany()
                        .HasForeignKey("AlgorithmId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("AlgorithmsApp.API.Models.MockData", "MockData")
                        .WithMany()
                        .HasForeignKey("MockDataId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
