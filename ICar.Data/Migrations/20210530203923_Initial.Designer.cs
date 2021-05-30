﻿// <auto-generated />
using System;
using ICar.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ICar.Infrastructure.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20210530203923_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ICar.Data.Models.Entities.Accounts.Company", b =>
                {
                    b.Property<string>("Cnpj")
                        .HasColumnType("CHAR(18)");

                    b.Property<DateTime>("AccountCreationDate")
                        .HasColumnType("DATETIME");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(320)
                        .HasColumnType("NVARCHAR(320)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("NVARCHAR(60)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("NVARCHAR(60)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR(30)");

                    b.HasKey("Cnpj");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("ICar.Data.Models.Entities.Accounts.User", b =>
                {
                    b.Property<string>("Cpf")
                        .HasMaxLength(14)
                        .HasColumnType("CHAR(14)");

                    b.Property<DateTime>("AccountCreationDate")
                        .HasColumnType("DATETIME");

                    b.Property<int>("CityId")
                        .HasColumnType("INT");

                    b.Property<int?>("CityId1")
                        .HasColumnType("INT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(320)
                        .HasColumnType("NVARCHAR(320)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("NVARCHAR(60)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("NVARCHAR(60)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("NVARCHAR(30)");

                    b.HasKey("Cpf");

                    b.HasIndex("CityId")
                        .IsUnique();

                    b.HasIndex("CityId1");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ICar.Data.Models.Entities.CarImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CarPlate")
                        .HasColumnType("Char(8)");

                    b.Property<string>("CompanyCarPlate")
                        .HasColumnType("Char(8)");

                    b.Property<string>("ImageStream")
                        .IsRequired()
                        .HasColumnType("NVARCHAR");

                    b.Property<string>("UserCarPlate")
                        .HasColumnType("Char(8)");

                    b.HasKey("Id");

                    b.HasIndex("CarPlate");

                    b.HasIndex("CompanyCarPlate");

                    b.HasIndex("UserCarPlate");

                    b.ToTable("CarImages");
                });

            modelBuilder.Entity("ICar.Data.Models.Entities.Cars.CompanyCar", b =>
                {
                    b.Property<string>("Plate")
                        .HasColumnType("Char(8)");

                    b.Property<bool>("AcceptsChange")
                        .HasColumnType("BIT");

                    b.Property<int>("CityId")
                        .HasColumnType("INT");

                    b.Property<int?>("CityId1")
                        .HasColumnType("INT");

                    b.Property<int>("Color")
                        .HasMaxLength(3)
                        .HasColumnType("INT");

                    b.Property<string>("CompanyCnpj")
                        .HasColumnType("CHAR(18)");

                    b.Property<string>("CompanyCnpj1")
                        .HasColumnType("CHAR(18)");

                    b.Property<string>("GasolineType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("NVARCHAR(20)");

                    b.Property<bool>("IpvaIsPaid")
                        .HasColumnType("BIT");

                    b.Property<bool>("IsArmored")
                        .HasColumnType("BIT");

                    b.Property<bool>("IsLicensed")
                        .HasColumnType("BIT");

                    b.Property<double>("KilometersTraveled")
                        .HasColumnType("float");

                    b.Property<int>("MakeDate")
                        .HasColumnType("INT");

                    b.Property<int>("MakedDate")
                        .HasColumnType("INT");

                    b.Property<string>("Maker")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("NVARCHAR(60)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("NVARCHAR(500)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("NVARCHAR(60)");

                    b.Property<int>("NumberOfViews")
                        .HasColumnType("INT");

                    b.Property<decimal>("Price")
                        .HasMaxLength(10000000)
                        .HasColumnType("DECIMAL(38,17)");

                    b.Property<string>("TypeOfExchange")
                        .IsRequired()
                        .HasColumnType("CHAR(3)");

                    b.HasKey("Plate");

                    b.HasIndex("CityId")
                        .IsUnique();

                    b.HasIndex("CityId1");

                    b.HasIndex("CompanyCnpj");

                    b.HasIndex("CompanyCnpj1");

                    b.ToTable("CompanyCars");
                });

            modelBuilder.Entity("ICar.Data.Models.Entities.Cars.UserCar", b =>
                {
                    b.Property<string>("Plate")
                        .HasColumnType("Char(8)");

                    b.Property<bool>("AcceptsChange")
                        .HasColumnType("BIT");

                    b.Property<int>("CityId")
                        .HasColumnType("INT");

                    b.Property<int?>("CityId1")
                        .HasColumnType("INT");

                    b.Property<int>("Color")
                        .HasMaxLength(3)
                        .HasColumnType("INT");

                    b.Property<string>("GasolineType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("NVARCHAR(20)");

                    b.Property<bool>("IpvaIsPaid")
                        .HasColumnType("BIT");

                    b.Property<bool>("IsArmored")
                        .HasColumnType("BIT");

                    b.Property<bool>("IsLicensed")
                        .HasColumnType("BIT");

                    b.Property<double>("KilometersTraveled")
                        .HasColumnType("float");

                    b.Property<int>("MakeDate")
                        .HasColumnType("INT");

                    b.Property<int>("MakedDate")
                        .HasColumnType("INT");

                    b.Property<string>("Maker")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("NVARCHAR(60)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("NVARCHAR(500)");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("NVARCHAR(60)");

                    b.Property<int>("NumberOfViews")
                        .HasColumnType("INT");

                    b.Property<decimal>("Price")
                        .HasMaxLength(10000000)
                        .HasColumnType("DECIMAL(38,17)");

                    b.Property<string>("TypeOfExchange")
                        .IsRequired()
                        .HasColumnType("CHAR(3)");

                    b.Property<string>("UserCpf")
                        .HasColumnType("CHAR(14)");

                    b.Property<string>("UserCpf1")
                        .HasColumnType("CHAR(14)");

                    b.HasKey("Plate");

                    b.HasIndex("CityId")
                        .IsUnique();

                    b.HasIndex("CityId1");

                    b.HasIndex("UserCpf");

                    b.HasIndex("UserCpf1");

                    b.ToTable("UserCars");
                });

            modelBuilder.Entity("ICar.Data.Models.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyCnpj")
                        .HasColumnType("CHAR(18)");

                    b.Property<string>("CompanyCnpj1")
                        .HasColumnType("CHAR(18)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("NVARCHAR(60)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyCnpj");

                    b.HasIndex("CompanyCnpj1");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("ICar.Data.Models.Entities.Logins.CompanyLogin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyCnpj")
                        .HasColumnType("CHAR(18)");

                    b.Property<string>("CompanyCnpj1")
                        .HasColumnType("CHAR(18)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("DATETIME");

                    b.HasKey("Id");

                    b.HasIndex("CompanyCnpj");

                    b.HasIndex("CompanyCnpj1");

                    b.ToTable("CompanyLogins");
                });

            modelBuilder.Entity("ICar.Data.Models.Entities.Logins.UserLogin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Time")
                        .HasColumnType("DATETIME");

                    b.Property<string>("UserCpf")
                        .HasColumnType("CHAR(14)");

                    b.Property<string>("UserCpf1")
                        .HasColumnType("CHAR(14)");

                    b.HasKey("Id");

                    b.HasIndex("UserCpf");

                    b.HasIndex("UserCpf1");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("ICar.Data.Models.Entities.News.CompanyNews", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyCnpj")
                        .HasColumnType("CHAR(18)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("DATETIME");

                    b.Property<string>("PublishedByCnpj")
                        .HasColumnType("CHAR(18)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("NVARCHAR(500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("NVARCHAR(20)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyCnpj");

                    b.HasIndex("PublishedByCnpj");

                    b.ToTable("CompanyNews");
                });

            modelBuilder.Entity("ICar.Data.Models.Entities.News.UserNews", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INT")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("DATETIME");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("DATETIME");

                    b.Property<string>("PublishedByCpf")
                        .HasColumnType("CHAR(14)");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("NVARCHAR(500)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("NVARCHAR(20)");

                    b.Property<string>("UserCpf")
                        .HasColumnType("CHAR(14)");

                    b.HasKey("Id");

                    b.HasIndex("PublishedByCpf");

                    b.HasIndex("UserCpf");

                    b.ToTable("UserNews");
                });

            modelBuilder.Entity("ICar.Infrastructure.Models.Entities.CompanyCity", b =>
                {
                    b.Property<int>("CityId")
                        .HasColumnType("INT");

                    b.Property<string>("CompanyCnpj")
                        .HasColumnType("CHAR(18)");

                    b.HasKey("CityId", "CompanyCnpj");

                    b.HasIndex("CityId")
                        .IsUnique();

                    b.HasIndex("CompanyCnpj")
                        .IsUnique();

                    b.ToTable("CompanyCities");
                });

            modelBuilder.Entity("ICar.Data.Models.Entities.Accounts.User", b =>
                {
                    b.HasOne("ICar.Data.Models.Entities.City", null)
                        .WithOne()
                        .HasForeignKey("ICar.Data.Models.Entities.Accounts.User", "CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ICar.Data.Models.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId1");

                    b.Navigation("City");
                });

            modelBuilder.Entity("ICar.Data.Models.Entities.CarImage", b =>
                {
                    b.HasOne("ICar.Data.Models.Entities.Cars.CompanyCar", null)
                        .WithMany()
                        .HasForeignKey("CarPlate");

                    b.HasOne("ICar.Data.Models.Entities.Cars.UserCar", null)
                        .WithMany()
                        .HasForeignKey("CarPlate");

                    b.HasOne("ICar.Data.Models.Entities.Cars.CompanyCar", null)
                        .WithMany("CarImages")
                        .HasForeignKey("CompanyCarPlate");

                    b.HasOne("ICar.Data.Models.Entities.Cars.UserCar", null)
                        .WithMany("CarImages")
                        .HasForeignKey("UserCarPlate");
                });

            modelBuilder.Entity("ICar.Data.Models.Entities.Cars.CompanyCar", b =>
                {
                    b.HasOne("ICar.Data.Models.Entities.City", null)
                        .WithOne()
                        .HasForeignKey("ICar.Data.Models.Entities.Cars.CompanyCar", "CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ICar.Data.Models.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId1");

                    b.HasOne("ICar.Data.Models.Entities.Accounts.Company", null)
                        .WithMany("CompanyCars")
                        .HasForeignKey("CompanyCnpj");

                    b.HasOne("ICar.Data.Models.Entities.Accounts.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyCnpj1");

                    b.Navigation("City");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("ICar.Data.Models.Entities.Cars.UserCar", b =>
                {
                    b.HasOne("ICar.Data.Models.Entities.City", null)
                        .WithOne()
                        .HasForeignKey("ICar.Data.Models.Entities.Cars.UserCar", "CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ICar.Data.Models.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId1");

                    b.HasOne("ICar.Data.Models.Entities.Accounts.User", null)
                        .WithMany("UserCars")
                        .HasForeignKey("UserCpf");

                    b.HasOne("ICar.Data.Models.Entities.Accounts.User", "User")
                        .WithMany()
                        .HasForeignKey("UserCpf1");

                    b.Navigation("City");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ICar.Data.Models.Entities.City", b =>
                {
                    b.HasOne("ICar.Data.Models.Entities.Accounts.Company", null)
                        .WithMany()
                        .HasForeignKey("CompanyCnpj");

                    b.HasOne("ICar.Data.Models.Entities.Accounts.Company", null)
                        .WithMany("Cities")
                        .HasForeignKey("CompanyCnpj1");
                });

            modelBuilder.Entity("ICar.Data.Models.Entities.Logins.CompanyLogin", b =>
                {
                    b.HasOne("ICar.Data.Models.Entities.Accounts.Company", null)
                        .WithMany("CompanyLogins")
                        .HasForeignKey("CompanyCnpj");

                    b.HasOne("ICar.Data.Models.Entities.Accounts.Company", "Company")
                        .WithMany()
                        .HasForeignKey("CompanyCnpj1");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("ICar.Data.Models.Entities.Logins.UserLogin", b =>
                {
                    b.HasOne("ICar.Data.Models.Entities.Accounts.User", null)
                        .WithMany("UserLogins")
                        .HasForeignKey("UserCpf");

                    b.HasOne("ICar.Data.Models.Entities.Accounts.User", "User")
                        .WithMany()
                        .HasForeignKey("UserCpf1");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ICar.Data.Models.Entities.News.CompanyNews", b =>
                {
                    b.HasOne("ICar.Data.Models.Entities.Accounts.Company", null)
                        .WithMany("CompanyNews")
                        .HasForeignKey("CompanyCnpj");

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

                    b.HasOne("ICar.Data.Models.Entities.Accounts.User", null)
                        .WithMany("UserNews")
                        .HasForeignKey("UserCpf");

                    b.Navigation("PublishedBy");
                });

            modelBuilder.Entity("ICar.Infrastructure.Models.Entities.CompanyCity", b =>
                {
                    b.HasOne("ICar.Data.Models.Entities.City", "City")
                        .WithOne()
                        .HasForeignKey("ICar.Infrastructure.Models.Entities.CompanyCity", "CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ICar.Data.Models.Entities.Accounts.Company", "Company")
                        .WithOne()
                        .HasForeignKey("ICar.Infrastructure.Models.Entities.CompanyCity", "CompanyCnpj")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");

                    b.Navigation("Company");
                });

            modelBuilder.Entity("ICar.Data.Models.Entities.Accounts.Company", b =>
                {
                    b.Navigation("Cities");

                    b.Navigation("CompanyCars");

                    b.Navigation("CompanyLogins");

                    b.Navigation("CompanyNews");
                });

            modelBuilder.Entity("ICar.Data.Models.Entities.Accounts.User", b =>
                {
                    b.Navigation("UserCars");

                    b.Navigation("UserLogins");

                    b.Navigation("UserNews");
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