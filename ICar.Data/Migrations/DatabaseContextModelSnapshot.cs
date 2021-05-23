﻿// <auto-generated />
using System;
using ICar.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ICar.Data.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ICar.Data.Models.Entities.Accounts.Company", b =>
                {
                    b.Property<string>("Cnpj")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("AccountCreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Cnpj");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("ICar.Data.Models.Entities.Accounts.User", b =>
                {
                    b.Property<string>("Cpf")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("AccountCreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Cpf");

                    b.HasIndex("CityId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ICar.Data.Models.Entities.CarImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CarPlate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyCarPlate")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ImageStream")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserCarPlate")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyCarPlate");

                    b.HasIndex("UserCarPlate");

                    b.ToTable("CarImage");
                });

            modelBuilder.Entity("ICar.Data.Models.Entities.Cars.CompanyCar", b =>
                {
                    b.Property<string>("Plate")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("AcceptsChange")
                        .HasColumnType("bit");

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("Color")
                        .HasColumnType("int");

                    b.Property<string>("CompanyCnpj")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("GasolineType")
                        .HasColumnType("int");

                    b.Property<bool>("IpvaIsPaid")
                        .HasColumnType("bit");

                    b.Property<bool>("IsArmored")
                        .HasColumnType("bit");

                    b.Property<bool>("IsLicensed")
                        .HasColumnType("bit");

                    b.Property<double>("KilometersTraveled")
                        .HasColumnType("float");

                    b.Property<int>("MakeDate")
                        .HasColumnType("int");

                    b.Property<int>("MakedDate")
                        .HasColumnType("int");

                    b.Property<string>("Maker")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Message")
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("NumberOfViews")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("TypeOfExchange")
                        .HasColumnType("int");

                    b.HasKey("Plate");

                    b.HasIndex("CityId");

                    b.HasIndex("CompanyCnpj");

                    b.ToTable("CompanyCars");
                });

            modelBuilder.Entity("ICar.Data.Models.Entities.Cars.UserCar", b =>
                {
                    b.Property<string>("Plate")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("AcceptsChange")
                        .HasColumnType("bit");

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<int>("Color")
                        .HasColumnType("int");

                    b.Property<int>("GasolineType")
                        .HasColumnType("int");

                    b.Property<bool>("IpvaIsPaid")
                        .HasColumnType("bit");

                    b.Property<bool>("IsArmored")
                        .HasColumnType("bit");

                    b.Property<bool>("IsLicensed")
                        .HasColumnType("bit");

                    b.Property<double>("KilometersTraveled")
                        .HasColumnType("float");

                    b.Property<int>("MakeDate")
                        .HasColumnType("int");

                    b.Property<int>("MakedDate")
                        .HasColumnType("int");

                    b.Property<string>("Maker")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Message")
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int>("NumberOfViews")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("TypeOfExchange")
                        .HasColumnType("int");

                    b.Property<string>("UserCpf")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Plate");

                    b.HasIndex("CityId");

                    b.HasIndex("UserCpf");

                    b.ToTable("UserCars");
                });

            modelBuilder.Entity("ICar.Data.Models.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyCnpj")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyCnpj");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("ICar.Data.Models.Entities.Logins.CompanyLogin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyCnpj")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CompanyCnpj");

                    b.ToTable("CompanyLogins");
                });

            modelBuilder.Entity("ICar.Data.Models.Entities.Logins.IUserLoginRepository", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserCpf")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserCpf");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("ICar.Data.Models.Entities.News.CompanyNews", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PublishedByCnpj")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.HasIndex("PublishedByCnpj");

                    b.ToTable("CompanyNews");
                });

            modelBuilder.Entity("ICar.Data.Models.Entities.News.UserNews", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PublishedByCpf")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.HasIndex("PublishedByCpf");

                    b.ToTable("UserNews");
                });

            modelBuilder.Entity("ICar.Data.Models.Entities.Accounts.User", b =>
                {
                    b.HasOne("ICar.Data.Models.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.Navigation("City");
                });

            modelBuilder.Entity("ICar.Data.Models.Entities.CarImage", b =>
                {
                    b.HasOne("ICar.Data.Models.Entities.Cars.CompanyCar", null)
                        .WithMany("CarImages")
                        .HasForeignKey("CompanyCarPlate");

                    b.HasOne("ICar.Data.Models.Entities.Cars.UserCar", null)
                        .WithMany("CarImages")
                        .HasForeignKey("UserCarPlate");
                });

            modelBuilder.Entity("ICar.Data.Models.Entities.Cars.CompanyCar", b =>
                {
                    b.HasOne("ICar.Data.Models.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("ICar.Data.Models.Entities.Accounts.Company", "Company")
                        .WithMany("CompanyCars")
                        .HasForeignKey("CompanyCnpj");

                    b.Navigation("City");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("ICar.Data.Models.Entities.Cars.UserCar", b =>
                {
                    b.HasOne("ICar.Data.Models.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("ICar.Data.Models.Entities.Accounts.User", "User")
                        .WithMany("UserCars")
                        .HasForeignKey("UserCpf");

                    b.Navigation("City");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ICar.Data.Models.Entities.City", b =>
                {
                    b.HasOne("ICar.Data.Models.Entities.Accounts.Company", null)
                        .WithMany("Cities")
                        .HasForeignKey("CompanyCnpj");
                });

            modelBuilder.Entity("ICar.Data.Models.Entities.Logins.CompanyLogin", b =>
                {
                    b.HasOne("ICar.Data.Models.Entities.Accounts.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyCnpj");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("ICar.Data.Models.Entities.Logins.IUserLoginRepository", b =>
                {
                    b.HasOne("ICar.Data.Models.Entities.Accounts.User", "User")
                        .WithMany()
                        .HasForeignKey("UserCpf");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ICar.Data.Models.Entities.News.CompanyNews", b =>
                {
                    b.HasOne("ICar.Data.Models.Entities.Accounts.Company", "PublishedBy")
                        .WithMany()
                        .HasForeignKey("PublishedByCnpj");

                    b.Navigation("PublishedBy");
                });

            modelBuilder.Entity("ICar.Data.Models.Entities.News.UserNews", b =>
                {
                    b.HasOne("ICar.Data.Models.Entities.Accounts.User", "PublishedBy")
                        .WithMany()
                        .HasForeignKey("PublishedByCpf");

                    b.Navigation("PublishedBy");
                });

            modelBuilder.Entity("ICar.Data.Models.Entities.Accounts.Company", b =>
                {
                    b.Navigation("Cities");

                    b.Navigation("CompanyCars");
                });

            modelBuilder.Entity("ICar.Data.Models.Entities.Accounts.User", b =>
                {
                    b.Navigation("UserCars");
                });

            modelBuilder.Entity("ICar.Data.Models.Entities.Cars.CompanyCar", b =>
                {
                    b.Navigation("CarImages");
                });

            modelBuilder.Entity("ICar.Data.Models.Entities.Cars.UserCar", b =>
                {
                    b.Navigation("CarImages");
                });
#pragma warning restore 612, 618
        }
    }
}
