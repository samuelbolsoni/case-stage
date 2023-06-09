﻿// <auto-generated />
using System;
using CaseStage.API.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CaseStage.API.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230609140117_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CaseStage.API.Models.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Areas");
                });

            modelBuilder.Entity("CaseStage.API.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("CaseStage.API.Models.Proccess", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int>("AreaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Documentation")
                        .HasMaxLength(800)
                        .HasColumnType("nvarchar(800)");

                    b.Property<int?>("IdParent")
                        .HasColumnType("int");

                    b.Property<int?>("PersonId")
                        .HasColumnType("int");

                    b.Property<int?>("SystemAppId")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.HasIndex("PersonId");

                    b.HasIndex("SystemAppId");

                    b.ToTable("Proccess");
                });

            modelBuilder.Entity("CaseStage.API.Models.ProccessFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProccessId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProccessId");

                    b.ToTable("ProccessFiles");
                });

            modelBuilder.Entity("CaseStage.API.Models.ProccessPerson", b =>
                {
                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<int>("ProccessId")
                        .HasColumnType("int");

                    b.HasIndex("PersonId");

                    b.HasIndex("ProccessId");

                    b.ToTable("ProccessPerson");
                });

            modelBuilder.Entity("CaseStage.API.Models.ProccessSystem", b =>
                {
                    b.Property<int>("ProccessId")
                        .HasColumnType("int");

                    b.Property<int>("SystemId")
                        .HasColumnType("int");

                    b.HasIndex("ProccessId");

                    b.HasIndex("SystemId");

                    b.ToTable("ProccessSystems");
                });

            modelBuilder.Entity("CaseStage.API.Models.SystemApp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("Active")
                        .HasMaxLength(800)
                        .HasColumnType("bit");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("SystemsApp");
                });

            modelBuilder.Entity("CaseStage.API.Models.Proccess", b =>
                {
                    b.HasOne("CaseStage.API.Models.Area", "Area")
                        .WithMany()
                        .HasForeignKey("AreaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CaseStage.API.Models.Person", null)
                        .WithMany("Proccess")
                        .HasForeignKey("PersonId");

                    b.HasOne("CaseStage.API.Models.SystemApp", null)
                        .WithMany("Proccess")
                        .HasForeignKey("SystemAppId");

                    b.Navigation("Area");
                });

            modelBuilder.Entity("CaseStage.API.Models.ProccessFile", b =>
                {
                    b.HasOne("CaseStage.API.Models.Proccess", "Proccess")
                        .WithMany()
                        .HasForeignKey("ProccessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proccess");
                });

            modelBuilder.Entity("CaseStage.API.Models.ProccessPerson", b =>
                {
                    b.HasOne("CaseStage.API.Models.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CaseStage.API.Models.Proccess", "Proccess")
                        .WithMany()
                        .HasForeignKey("ProccessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");

                    b.Navigation("Proccess");
                });

            modelBuilder.Entity("CaseStage.API.Models.ProccessSystem", b =>
                {
                    b.HasOne("CaseStage.API.Models.Proccess", "Proccess")
                        .WithMany()
                        .HasForeignKey("ProccessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CaseStage.API.Models.SystemApp", "System")
                        .WithMany()
                        .HasForeignKey("SystemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Proccess");

                    b.Navigation("System");
                });

            modelBuilder.Entity("CaseStage.API.Models.Person", b =>
                {
                    b.Navigation("Proccess");
                });

            modelBuilder.Entity("CaseStage.API.Models.SystemApp", b =>
                {
                    b.Navigation("Proccess");
                });
#pragma warning restore 612, 618
        }
    }
}
