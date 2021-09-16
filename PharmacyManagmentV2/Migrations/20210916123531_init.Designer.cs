﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PharmacyManagmentV2.Contexts;

namespace PharmacyManagmentV2.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20210916123531_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MedicinePharmacy", b =>
                {
                    b.Property<int>("MedicinesId")
                        .HasColumnType("int");

                    b.Property<int>("PharmaciesId")
                        .HasColumnType("int");

                    b.HasKey("MedicinesId", "PharmaciesId");

                    b.HasIndex("PharmaciesId");

                    b.ToTable("MedicinePharmacy");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("PharmacyManagmentV2.Data.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Address2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Zip")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("PharmacyManagmentV2.Data.ApplicationRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("PharmacyManagmentV2.Data.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PharmacyId")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("UserType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("PharmacyId");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("PharmacyManagmentV2.Data.BankAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AccountName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("AccountNumber")
                        .HasColumnType("bigint");

                    b.Property<int>("Balance")
                        .HasColumnType("int");

                    b.Property<string>("Branch")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CreditLine")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("BankAccounts");
                });

            modelBuilder.Entity("PharmacyManagmentV2.Data.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("PharmacyManagmentV2.Data.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<int?>("BankAccountId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateofBird")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("BankAccountId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("PharmacyManagmentV2.Data.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AppUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int>("TotalAmount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Sells");
                });

            modelBuilder.Entity("PharmacyManagmentV2.Data.Leaf", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("LeafType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TotalNumberPerBox")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Leaves");
                });

            modelBuilder.Entity("PharmacyManagmentV2.Data.Manufacturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<int?>("BankAccountId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Fax")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("BankAccountId");

                    b.ToTable("Manufacturers");
                });

            modelBuilder.Entity("PharmacyManagmentV2.Data.Medicine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Expriy")
                        .HasColumnType("datetime2");

                    b.Property<string>("GenericName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LeafId")
                        .HasColumnType("int");

                    b.Property<int>("ManufacturerId")
                        .HasColumnType("int");

                    b.Property<int>("ManufacturerPrice")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int?>("PurchaseId")
                        .HasColumnType("int");

                    b.Property<int?>("SellId")
                        .HasColumnType("int");

                    b.Property<int>("Shelf")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Strengh")
                        .HasColumnType("int");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("LeafId");

                    b.HasIndex("ManufacturerId");

                    b.HasIndex("PurchaseId");

                    b.HasIndex("SellId");

                    b.HasIndex("TypeId");

                    b.HasIndex("UnitId");

                    b.ToTable("Medicines");
                });

            modelBuilder.Entity("PharmacyManagmentV2.Data.MedicineType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MedicineTypes");
                });

            modelBuilder.Entity("PharmacyManagmentV2.Data.Notify", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ApplicationUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int?>("ManufacturerId")
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ManufacturerId");

                    b.ToTable("Notify");
                });

            modelBuilder.Entity("PharmacyManagmentV2.Data.Pharmacy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("BankAccountId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BankAccountId");

                    b.ToTable("Pharmacies");
                });

            modelBuilder.Entity("PharmacyManagmentV2.Data.Purchase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AppUserId1")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("TotalAmount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId1");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("PharmacyManagmentV2.Data.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("MedicinePharmacy", b =>
                {
                    b.HasOne("PharmacyManagmentV2.Data.Medicine", null)
                        .WithMany()
                        .HasForeignKey("MedicinesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PharmacyManagmentV2.Data.Pharmacy", null)
                        .WithMany()
                        .HasForeignKey("PharmaciesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("PharmacyManagmentV2.Data.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("PharmacyManagmentV2.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("PharmacyManagmentV2.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("PharmacyManagmentV2.Data.ApplicationRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PharmacyManagmentV2.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("PharmacyManagmentV2.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PharmacyManagmentV2.Data.ApplicationUser", b =>
                {
                    b.HasOne("PharmacyManagmentV2.Data.Address", "Address")
                        .WithMany("AspNetUsers")
                        .HasForeignKey("AddressId");

                    b.HasOne("PharmacyManagmentV2.Data.Pharmacy", "Pharmacy")
                        .WithMany("ApplicationUsers")
                        .HasForeignKey("PharmacyId");

                    b.Navigation("Address");

                    b.Navigation("Pharmacy");
                });

            modelBuilder.Entity("PharmacyManagmentV2.Data.Customer", b =>
                {
                    b.HasOne("PharmacyManagmentV2.Data.Address", "Address")
                        .WithMany("Customers")
                        .HasForeignKey("AddressId");

                    b.HasOne("PharmacyManagmentV2.Data.BankAccount", "BankAccount")
                        .WithMany()
                        .HasForeignKey("BankAccountId");

                    b.Navigation("Address");

                    b.Navigation("BankAccount");
                });

            modelBuilder.Entity("PharmacyManagmentV2.Data.Invoice", b =>
                {
                    b.HasOne("PharmacyManagmentV2.Data.ApplicationUser", "AppUser")
                        .WithMany("Sells")
                        .HasForeignKey("AppUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PharmacyManagmentV2.Data.Customer", "Customer")
                        .WithMany("Sells")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AppUser");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("PharmacyManagmentV2.Data.Manufacturer", b =>
                {
                    b.HasOne("PharmacyManagmentV2.Data.Address", "Address")
                        .WithMany("Manufacturers")
                        .HasForeignKey("AddressId");

                    b.HasOne("PharmacyManagmentV2.Data.BankAccount", "BankAccount")
                        .WithMany()
                        .HasForeignKey("BankAccountId");

                    b.Navigation("Address");

                    b.Navigation("BankAccount");
                });

            modelBuilder.Entity("PharmacyManagmentV2.Data.Medicine", b =>
                {
                    b.HasOne("PharmacyManagmentV2.Data.Category", "Category")
                        .WithMany("Medicines")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PharmacyManagmentV2.Data.Leaf", "Leaf")
                        .WithMany("Medicines")
                        .HasForeignKey("LeafId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PharmacyManagmentV2.Data.Manufacturer", "Manufacturer")
                        .WithMany("Medicines")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PharmacyManagmentV2.Data.Purchase", "Purchase")
                        .WithMany("Medicines")
                        .HasForeignKey("PurchaseId");

                    b.HasOne("PharmacyManagmentV2.Data.Invoice", "Sell")
                        .WithMany("Medicines")
                        .HasForeignKey("SellId");

                    b.HasOne("PharmacyManagmentV2.Data.MedicineType", "Type")
                        .WithMany("Medicines")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PharmacyManagmentV2.Data.Unit", "Unit")
                        .WithMany("Medicines")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Leaf");

                    b.Navigation("Manufacturer");

                    b.Navigation("Purchase");

                    b.Navigation("Sell");

                    b.Navigation("Type");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("PharmacyManagmentV2.Data.Notify", b =>
                {
                    b.HasOne("PharmacyManagmentV2.Data.ApplicationUser", null)
                        .WithMany("Notifies")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("PharmacyManagmentV2.Data.Customer", null)
                        .WithMany("Notifies")
                        .HasForeignKey("CustomerId");

                    b.HasOne("PharmacyManagmentV2.Data.Manufacturer", null)
                        .WithMany("Notifies")
                        .HasForeignKey("ManufacturerId");
                });

            modelBuilder.Entity("PharmacyManagmentV2.Data.Pharmacy", b =>
                {
                    b.HasOne("PharmacyManagmentV2.Data.BankAccount", "BankAccount")
                        .WithMany()
                        .HasForeignKey("BankAccountId");

                    b.Navigation("BankAccount");
                });

            modelBuilder.Entity("PharmacyManagmentV2.Data.Purchase", b =>
                {
                    b.HasOne("PharmacyManagmentV2.Data.ApplicationUser", "AppUser")
                        .WithMany("Purchases")
                        .HasForeignKey("AppUserId1");

                    b.Navigation("AppUser");
                });

            modelBuilder.Entity("PharmacyManagmentV2.Data.Address", b =>
                {
                    b.Navigation("AspNetUsers");

                    b.Navigation("Customers");

                    b.Navigation("Manufacturers");
                });

            modelBuilder.Entity("PharmacyManagmentV2.Data.ApplicationUser", b =>
                {
                    b.Navigation("Notifies");

                    b.Navigation("Purchases");

                    b.Navigation("Sells");
                });

            modelBuilder.Entity("PharmacyManagmentV2.Data.Category", b =>
                {
                    b.Navigation("Medicines");
                });

            modelBuilder.Entity("PharmacyManagmentV2.Data.Customer", b =>
                {
                    b.Navigation("Notifies");

                    b.Navigation("Sells");
                });

            modelBuilder.Entity("PharmacyManagmentV2.Data.Invoice", b =>
                {
                    b.Navigation("Medicines");
                });

            modelBuilder.Entity("PharmacyManagmentV2.Data.Leaf", b =>
                {
                    b.Navigation("Medicines");
                });

            modelBuilder.Entity("PharmacyManagmentV2.Data.Manufacturer", b =>
                {
                    b.Navigation("Medicines");

                    b.Navigation("Notifies");
                });

            modelBuilder.Entity("PharmacyManagmentV2.Data.MedicineType", b =>
                {
                    b.Navigation("Medicines");
                });

            modelBuilder.Entity("PharmacyManagmentV2.Data.Pharmacy", b =>
                {
                    b.Navigation("ApplicationUsers");
                });

            modelBuilder.Entity("PharmacyManagmentV2.Data.Purchase", b =>
                {
                    b.Navigation("Medicines");
                });

            modelBuilder.Entity("PharmacyManagmentV2.Data.Unit", b =>
                {
                    b.Navigation("Medicines");
                });
#pragma warning restore 612, 618
        }
    }
}