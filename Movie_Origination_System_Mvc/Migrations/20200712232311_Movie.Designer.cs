﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Movie_Origination_System_Mvc.Data;

namespace Movie_Origination_System_Mvc.Migrations
{
    [DbContext(typeof(Movie_Origination_System_MvcContext))]
    [Migration("20200712232311_Movie")]
    partial class Movie
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Movie_Origination_System_Mvc.Models.Director_details", b =>
                {
                    b.Property<int>("Movie_Director_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Movie_Director_Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Movie_Director_Mobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Movie_Director_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Movie_Director_Occupations")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Movie_Director_ID");

                    b.ToTable("Director_details");
                });

            modelBuilder.Entity("Movie_Origination_System_Mvc.Models.Movie_Origination_Table", b =>
                {
                    b.Property<int>("Movie_Origination_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Director_detailsMovie_Director_ID")
                        .HasColumnType("int");

                    b.Property<int>("Movie_Director_ID")
                        .HasColumnType("int");

                    b.Property<int>("Movie_ID")
                        .HasColumnType("int");

                    b.Property<int>("Movie_Producer_ID")
                        .HasColumnType("int");

                    b.Property<int?>("Movie_detailsMovie_ID")
                        .HasColumnType("int");

                    b.Property<int?>("Producer_detailsMovie_Producer_ID")
                        .HasColumnType("int");

                    b.HasKey("Movie_Origination_ID");

                    b.HasIndex("Director_detailsMovie_Director_ID");

                    b.HasIndex("Movie_detailsMovie_ID");

                    b.HasIndex("Producer_detailsMovie_Producer_ID");

                    b.ToTable("Movie_Origination_Table");
                });

            modelBuilder.Entity("Movie_Origination_System_Mvc.Models.Movie_details", b =>
                {
                    b.Property<int>("Movie_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Movie_Language")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Movie_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Movie_Release_Date")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Movie_Running_Time")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Movie_ID");

                    b.ToTable("Movie_details");
                });

            modelBuilder.Entity("Movie_Origination_System_Mvc.Models.Producer_details", b =>
                {
                    b.Property<int>("Movie_Producer_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Movie_Producer_Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Movie_Producer_Mobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Movie_Producer_Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Movie_Producer_Occupations")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Movie_Producer_ID");

                    b.ToTable("Producer_details");
                });

            modelBuilder.Entity("Movie_Origination_System_Mvc.Models.Movie_Origination_Table", b =>
                {
                    b.HasOne("Movie_Origination_System_Mvc.Models.Director_details", "Director_details")
                        .WithMany()
                        .HasForeignKey("Director_detailsMovie_Director_ID");

                    b.HasOne("Movie_Origination_System_Mvc.Models.Movie_details", "Movie_details")
                        .WithMany()
                        .HasForeignKey("Movie_detailsMovie_ID");

                    b.HasOne("Movie_Origination_System_Mvc.Models.Producer_details", "Producer_details")
                        .WithMany()
                        .HasForeignKey("Producer_detailsMovie_Producer_ID");
                });
#pragma warning restore 612, 618
        }
    }
}
