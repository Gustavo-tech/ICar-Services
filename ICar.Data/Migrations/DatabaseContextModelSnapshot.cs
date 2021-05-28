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

                    b.Property<int>("CityId")
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
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ImageStream")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CarPlate");

                    b.ToTable("CarImages");
                });

            modelBuilder.Entity("ICar.Data.Models.Entities.Cars.CompanyCar", b =>
                {
                    b.Property<string>("Plate")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("AcceptsChange")
                        .HasColumnType("bit");

                    b.Property<int>("CityId")
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

                    b.Property<int>("CityId")
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

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("ICar.Data.Models.Entities.CompanyCity", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("CompanyCnpj")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyCnpj");

                    b.ToTable("CompanyCities");
                });

            modelBuilder.Entity("ICar.Data.Models.Entities.Logins.CompanyLogin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CompanyCnpj")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CompanyCnpj");

                    b.ToTable("CompanyLogins");
                });

            modelBuilder.Entity("ICar.Data.Models.Entities.Logins.UserLogin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserCpf")
                        .IsRequired()
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

                    b.Property<string>("CompanyCnpj")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.HasKey("Id");

                    b.HasIndex("CompanyCnpj");

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

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("UserCpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserCpf");

                    b.ToTable("UserNews");
                });

            modelBuilder.Entity("ICar.Data.Models.Entities.Accounts.User", b =>
                {
                    b.HasOne("ICar.Data.Models.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("ICar.Data.Models.Entities.CarImage", b =>
                {
                    b.HasOne("ICar.Data.Models.Entities.Cars.CompanyCar", null)
                        .WithMany("CarImages")
                        .HasForeignKey("CarPlate");

                    b.HasOne("ICar.Data.Models.Entities.Cars.UserCar", null)
                        .WithMany("CarImages")
                        .HasForeignKey("CarPlate");
                });

            modelBuilder.Entity("ICar.Data.Models.Entities.Cars.CompanyCar", b =>
                {
                    b.HasOne("ICar.Data.Models.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ICar.Data.Models.Entities.Accounts.User", "User")
                        .WithMany("UserCars")
                        .HasForeignKey("UserCpf");

                    b.Navigation("City");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ICar.Data.Models.Entities.CompanyCity", b =>
                {
                    b.HasOne("ICar.Data.Models.Entities.Accounts.Company", null)
                        .WithMany("Cities")
                        .HasForeignKey("CompanyCnpj");

                    b.HasOne("ICar.Data.Models.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("ICar.Data.Models.Entities.Logins.CompanyLogin", b =>
                {
                    b.HasOne("ICar.Data.Models.Entities.Accounts.Company", "Company")
                        .WithMany("CompanyLogins")
                        .HasForeignKey("CompanyCnpj")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("ICar.Data.Models.Entities.Logins.UserLogin", b =>
                {
                    b.HasOne("ICar.Data.Models.Entities.Accounts.User", "User")
                        .WithMany("UserLogins")
                        .HasForeignKey("UserCpf")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ICar.Data.Models.Entities.News.CompanyNews", b =>
                {
                    b.HasOne("ICar.Data.Models.Entities.Accounts.Company", "PublishedBy")
                        .WithMany("CompanyNews")
                        .HasForeignKey("CompanyCnpj")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PublishedBy");
                });

            modelBuilder.Entity("ICar.Data.Models.Entities.News.UserNews", b =>
                {
                    b.HasOne("ICar.Data.Models.Entities.Accounts.User", "PublishedBy")
                        .WithMany("UserNews")
                        .HasForeignKey("UserCpf")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PublishedBy");
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
