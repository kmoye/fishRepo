﻿// <auto-generated />
using System;
using FishDumpRepo;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace fishRepo_EF.Migrations
{
    [DbContext(typeof(FishDumpContext))]
    [Migration("20200323141243_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FishDumpRepo.Characteristic", b =>
                {
                    b.Property<string>("CharacteristicID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FishCount")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FishID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FishLength")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FishNameID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("StructureType")
                        .HasColumnType("int");

                    b.Property<string>("Trophic")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CharacteristicID");

                    b.HasIndex("FishNameID");

                    b.ToTable("Characteristics");
                });

            modelBuilder.Entity("FishDumpRepo.FishName", b =>
                {
                    b.Property<string>("FishNameID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("CommonName")
                        .HasColumnType("int");

                    b.Property<string>("Family")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FishID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecificName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FishNameID");

                    b.ToTable("FishName");
                });

            modelBuilder.Entity("FishDumpRepo.Locations", b =>
                {
                    b.Property<int>("LocationsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CharacteristicID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FishID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FishLocaID")
                        .HasColumnType("int");

                    b.Property<string>("Latitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Longtitude")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StudyAreas")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SurveyID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LocationsID");

                    b.HasIndex("CharacteristicID");

                    b.HasIndex("SurveyID");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("FishDumpRepo.Region", b =>
                {
                    b.Property<int>("RegionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FishID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LocationsID")
                        .HasColumnType("int");

                    b.Property<string>("Regions")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RegionID");

                    b.HasIndex("LocationsID");

                    b.ToTable("Regions");
                });

            modelBuilder.Entity("FishDumpRepo.SubRegion", b =>
                {
                    b.Property<int>("SubRegionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("FishID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("RegionID")
                        .HasColumnType("int");

                    b.Property<string>("SubRegions")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SubRegionID");

                    b.HasIndex("RegionID");

                    b.ToTable("SubRegions");
                });

            modelBuilder.Entity("FishDumpRepo.Survey", b =>
                {
                    b.Property<string>("SurveyID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("BatchCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FishID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Management")
                        .HasColumnType("int");

                    b.Property<string>("SurveyDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SurveyIndex")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SurveyID");

                    b.ToTable("Survey");
                });

            modelBuilder.Entity("FishDumpRepo.Characteristic", b =>
                {
                    b.HasOne("FishDumpRepo.FishName", null)
                        .WithMany("Characteristics")
                        .HasForeignKey("FishNameID");
                });

            modelBuilder.Entity("FishDumpRepo.Locations", b =>
                {
                    b.HasOne("FishDumpRepo.Characteristic", null)
                        .WithMany("Locations")
                        .HasForeignKey("CharacteristicID");

                    b.HasOne("FishDumpRepo.Survey", null)
                        .WithMany("Locations")
                        .HasForeignKey("SurveyID");
                });

            modelBuilder.Entity("FishDumpRepo.Region", b =>
                {
                    b.HasOne("FishDumpRepo.Locations", null)
                        .WithMany("Regions")
                        .HasForeignKey("LocationsID");
                });

            modelBuilder.Entity("FishDumpRepo.SubRegion", b =>
                {
                    b.HasOne("FishDumpRepo.Region", null)
                        .WithMany("SubRegions")
                        .HasForeignKey("RegionID");
                });
#pragma warning restore 612, 618
        }
    }
}
