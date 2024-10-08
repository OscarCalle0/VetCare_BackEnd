﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VetCare_BackEnd.Data;

#nullable disable

namespace VetCare_BackEnd.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240910155601_InsertDataInUsersTable")]
    partial class InsertDataInUsersTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("VetCare_BackEnd.Models.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AppointmentTypeId")
                        .HasColumnType("int");

                    b.Property<bool>("Available")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Description")
                        .HasMaxLength(260)
                        .HasColumnType("varchar(260)");

                    b.Property<DateOnly>("EndDate")
                        .HasColumnType("date");

                    b.Property<int>("PetId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("StartDate")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.ToTable("appointments");
                });

            modelBuilder.Entity("VetCare_BackEnd.Models.AppointmentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("appointmentTypes");
                });

            modelBuilder.Entity("VetCare_BackEnd.Models.DocumentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("documentTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Cédula de Ciudadanía"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Tarjeta de Identidad"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Pasaporte"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Número de Identificación Tributaria"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Cédula de Extranjería"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Registro Civil"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Permiso Especial de Permanencia"
                        });
                });

            modelBuilder.Entity("VetCare_BackEnd.Models.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly>("BirthDate")
                        .HasMaxLength(10)
                        .HasColumnType("date");

                    b.Property<string>("Breed")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Sex")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Weight")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("pets");
                });

            modelBuilder.Entity("VetCare_BackEnd.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Administrator"
                        },
                        new
                        {
                            Id = 2,
                            Name = "User"
                        });
                });

            modelBuilder.Entity("VetCare_BackEnd.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateOnly?>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("DocumentNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<int>("DocumentTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("varchar(15)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDate = new DateOnly(2024, 3, 27),
                            DocumentNumber = "z6yb0q7lch",
                            DocumentTypeId = 136,
                            Email = "Ettie.Green7@hotmail.com",
                            LastName = "Morar",
                            Name = "Ora",
                            Password = "_GecPSCeV5",
                            PhoneNumber = "514 514 88 21",
                            RoleId = 48
                        },
                        new
                        {
                            Id = 2,
                            BirthDate = new DateOnly(2024, 5, 26),
                            DocumentNumber = "hr7hb8yvh1",
                            DocumentTypeId = 82,
                            Email = "Vesta10@gmail.com",
                            LastName = "Schiller",
                            Name = "Alfredo",
                            Password = "1jnmtHKbcV",
                            PhoneNumber = "897 871 28 15",
                            RoleId = 121
                        },
                        new
                        {
                            Id = 3,
                            BirthDate = new DateOnly(2023, 12, 19),
                            DocumentNumber = "fo7ul3jc01",
                            DocumentTypeId = 197,
                            Email = "Obie_Strosin46@gmail.com",
                            LastName = "McLaughlin",
                            Name = "Shawna",
                            Password = "jWepjNWwIf",
                            PhoneNumber = "533 787 37 66",
                            RoleId = 254
                        },
                        new
                        {
                            Id = 4,
                            BirthDate = new DateOnly(2024, 1, 12),
                            DocumentNumber = "rj0me3egmt",
                            DocumentTypeId = 89,
                            Email = "Tara9@hotmail.com",
                            LastName = "Mayer",
                            Name = "Jack",
                            Password = "mHvwLQJrLU",
                            PhoneNumber = "721 237 82 10",
                            RoleId = 229
                        },
                        new
                        {
                            Id = 5,
                            BirthDate = new DateOnly(2024, 5, 4),
                            DocumentNumber = "zy4ah7s136",
                            DocumentTypeId = 182,
                            Email = "Loraine_Fay91@gmail.com",
                            LastName = "Stamm",
                            Name = "Jewell",
                            Password = "t7FsnAvREY",
                            PhoneNumber = "090 595 80 81",
                            RoleId = 71
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
