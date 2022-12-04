﻿// <auto-generated />
using System;
using HATC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HATC.Migrations
{
    [DbContext(typeof(HavenDbContext))]
    partial class HavenDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.31")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("HATC.Models.Character", b =>
                {
                    b.Property<int>("CharacterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("CharacterId");

                    b.HasIndex("UserId");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("HATC.Models.Monster", b =>
                {
                    b.Property<int>("MonsterId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<string>("Cr")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SessionId")
                        .HasColumnType("int");

                    b.HasKey("MonsterId");

                    b.HasIndex("SessionId");

                    b.ToTable("Monsters");
                });

            modelBuilder.Entity("HATC.Models.Session", b =>
                {
                    b.Property<int>("SessionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DM")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("InGameDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SessionDate")
                        .HasColumnType("datetime2");

                    b.HasKey("SessionId");

                    b.ToTable("Sessions");
                });

            modelBuilder.Entity("HATC.Models.SessionItem", b =>
                {
                    b.Property<int>("SessionItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ItemName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SessionId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<int>("Value")
                        .HasColumnType("int");

                    b.HasKey("SessionItemId");

                    b.HasIndex("SessionId");

                    b.ToTable("SessionItems");
                });

            modelBuilder.Entity("HATC.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<int?>("SessionId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.HasIndex("SessionId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("HATC.Models.Character", b =>
                {
                    b.HasOne("HATC.Models.User", null)
                        .WithMany("Characters")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("HATC.Models.Monster", b =>
                {
                    b.HasOne("HATC.Models.Session", null)
                        .WithMany("Monsters")
                        .HasForeignKey("SessionId");
                });

            modelBuilder.Entity("HATC.Models.SessionItem", b =>
                {
                    b.HasOne("HATC.Models.Session", null)
                        .WithMany("SessionItems")
                        .HasForeignKey("SessionId");
                });

            modelBuilder.Entity("HATC.Models.User", b =>
                {
                    b.HasOne("HATC.Models.Session", null)
                        .WithMany("Users")
                        .HasForeignKey("SessionId");
                });
#pragma warning restore 612, 618
        }
    }
}
