﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Rms.Database.Database;

#nullable disable

namespace Rms.Database.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240922095534_add_Customer")]
    partial class add_Customer
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
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

                    b.ToTable("AspNetUserLogins", (string)null);
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

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Rms.Models.DbModels.Views.VW_Inventory", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Product")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<float>("StockQty")
                        .HasColumnType("real");

                    b.ToTable((string)null);

                    b.ToView("VW_Inventory", (string)null);
                });

            modelBuilder.Entity("Rms.Models.DbModels.Views.VW_Product", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<bool>("IsEnable")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PurchasePrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PurchaseUnitId")
                        .HasColumnType("int");

                    b.Property<string>("PurchaseUnitName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SaleUnitId")
                        .HasColumnType("int");

                    b.Property<string>("SaleUnitName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("VAT")
                        .HasColumnType("decimal(18,2)");

                    b.ToTable((string)null);

                    b.ToView("VW_Product", (string)null);
                });

            modelBuilder.Entity("Rms.Models.Entities.Identity.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsSoftDelete")
                        .HasColumnType("bit");

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

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Rms.Models.Entities.Identity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("CreatedById")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<long?>("DeletedById")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsSoftDelete")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
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

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<long?>("UpdatedById")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("UserCodePartSequence")
                        .HasColumnType("bigint");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Rms.Models.Entities.Identity.UserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<bool>("IsSoftDelete")
                        .HasColumnType("bit");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Rms.Models.Entities.Menues.Menu", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Bullet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("MenuId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Order")
                        .HasColumnType("int");

                    b.Property<bool>("Root")
                        .HasColumnType("bit");

                    b.Property<string>("Translate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.ToTable("RMS_MENU");
                });

            modelBuilder.Entity("Rms.Models.Entities.Menues.RoleMenu", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<long?>("CreatedById")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<long?>("DeletedById")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsSoftDelete")
                        .HasColumnType("bit");

                    b.Property<long>("MenuId")
                        .HasColumnType("bigint");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("UpdatedById")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.ToTable("RMS_ROLEMENU");
                });

            modelBuilder.Entity("Rms.Models.Entities.Permissions.Permission", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("CreatedById")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<long?>("DeletedById")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("HasLimit")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSoftDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PermissionFeatureId")
                        .HasColumnType("bigint");

                    b.Property<long?>("UpdatedById")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PermissionFeatureId");

                    b.ToTable("RMS_PERMISSION");
                });

            modelBuilder.Entity("Rms.Models.Entities.Permissions.PermissionFeature", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("CreatedById")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<long?>("DeletedById")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsSoftDelete")
                        .HasColumnType("bit");

                    b.Property<long?>("MenuId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("PermissionModuleId")
                        .HasColumnType("bigint");

                    b.Property<long?>("UpdatedById")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MenuId");

                    b.HasIndex("PermissionModuleId");

                    b.ToTable("RMS_PERMISSION_FEATURE");
                });

            modelBuilder.Entity("Rms.Models.Entities.Permissions.PermissionModule", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("CreatedById")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<long?>("DeletedById")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsSoftDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("UpdatedById")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("RMS_PERMISSION_MODULE");
                });

            modelBuilder.Entity("Rms.Models.Entities.Permissions.RoleFeaturePermission", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<bool>("IsSoftDelete")
                        .HasColumnType("bit");

                    b.Property<long?>("Limit")
                        .HasColumnType("bigint");

                    b.Property<long>("PermissionId")
                        .HasColumnType("bigint");

                    b.Property<string>("UserRoles")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PermissionId");

                    b.ToTable("RMS_ROLE_FEATURE_PERMISSION");
                });

            modelBuilder.Entity("Rms.Models.Entities.Setup.Complex", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("CarParkingAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ComplexNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("CreatedById")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<long?>("DeletedById")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsSoftDelete")
                        .HasColumnType("bit");

                    b.Property<decimal>("MotorcycleParkingAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("RentAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ServiceAmout")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long?>("UpdatedById")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RMS_COMPLEX");
                });

            modelBuilder.Entity("Rms.Models.Entities.Setup.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("AdvanceRentAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("AreaSFT")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("CarQuantity")
                        .HasColumnType("int");

                    b.Property<int>("ComplexId")
                        .HasColumnType("int");

                    b.Property<string>("ContactName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("CreatedById")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<int>("CustomerType")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<long?>("DeletedById")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Discontinued")
                        .HasColumnType("bit");

                    b.Property<decimal?>("DueAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("EletricBillType")
                        .HasColumnType("int");

                    b.Property<decimal?>("EletricMetterLastReading")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("EletricMetterLastReadingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EletricMetterNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FatherName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("FixEletricBillAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("GasDoubStoveAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("GasMeterLastReading")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("GasOpeningReading")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("GasSingStoveAmout")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("GasStoveType")
                        .HasColumnType("int");

                    b.Property<int?>("GassBillType")
                        .HasColumnType("int");

                    b.Property<decimal?>("GassBillUnitPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("GassMeterLastReadingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsElectricBillRequird")
                        .HasColumnType("bit");

                    b.Property<bool>("IsGasBillRequire")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRentFix")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSoftDelete")
                        .HasColumnType("bit");

                    b.Property<bool>("IsWaterBillRequire")
                        .HasColumnType("bit");

                    b.Property<int?>("LevelNo")
                        .HasColumnType("int");

                    b.Property<string>("MobileNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MotorcycleQuantity")
                        .HasColumnType("int");

                    b.Property<string>("NID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NIDImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("OpeningReading")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("OtherBill")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("OtherDocumentUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("RateSrf")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("RentActiveDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("RentAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("ServiceCharge")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long?>("UpdatedById")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("WaterBill")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ComplexId");

                    b.ToTable("RMS_CUSTOMER");
                });

            modelBuilder.Entity("Rms.Models.Entities.Setup.GlobalSetup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("CommercialEBill")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("CommercialMiniUnit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long?>("CreatedById")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("DelayCharge")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long?>("DeletedById")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedOn")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("DemandCharge")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("DutyOnKHW")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ElectricMotorCharge")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("IsSoftDelete")
                        .HasColumnType("bit");

                    b.Property<decimal>("ResidentialEBill")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ResidentialMiniUnit")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("ServiceCharge")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long?>("UpdatedById")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("VAT")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("RMS_GLOBAL_SETUP");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Rms.Models.Entities.Identity.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("Rms.Models.Entities.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("Rms.Models.Entities.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("Rms.Models.Entities.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Rms.Models.Entities.Identity.UserRole", b =>
                {
                    b.HasOne("Rms.Models.Entities.Identity.Role", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Rms.Models.Entities.Identity.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Rms.Models.Entities.Menues.Menu", b =>
                {
                    b.HasOne("Rms.Models.Entities.Menues.Menu", null)
                        .WithMany("Submenu")
                        .HasForeignKey("MenuId");
                });

            modelBuilder.Entity("Rms.Models.Entities.Menues.RoleMenu", b =>
                {
                    b.HasOne("Rms.Models.Entities.Menues.Menu", "Menu")
                        .WithMany()
                        .HasForeignKey("MenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");
                });

            modelBuilder.Entity("Rms.Models.Entities.Permissions.Permission", b =>
                {
                    b.HasOne("Rms.Models.Entities.Permissions.PermissionFeature", "PermissionFeature")
                        .WithMany("Permissions")
                        .HasForeignKey("PermissionFeatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PermissionFeature");
                });

            modelBuilder.Entity("Rms.Models.Entities.Permissions.PermissionFeature", b =>
                {
                    b.HasOne("Rms.Models.Entities.Menues.Menu", "Menu")
                        .WithMany()
                        .HasForeignKey("MenuId");

                    b.HasOne("Rms.Models.Entities.Permissions.PermissionModule", "PermissionModule")
                        .WithMany("PermissionFeatures")
                        .HasForeignKey("PermissionModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Menu");

                    b.Navigation("PermissionModule");
                });

            modelBuilder.Entity("Rms.Models.Entities.Permissions.RoleFeaturePermission", b =>
                {
                    b.HasOne("Rms.Models.Entities.Permissions.Permission", "Permission")
                        .WithMany()
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");
                });

            modelBuilder.Entity("Rms.Models.Entities.Setup.Complex", b =>
                {
                    b.HasOne("Rms.Models.Entities.Identity.User", "Users")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("Rms.Models.Entities.Setup.Customer", b =>
                {
                    b.HasOne("Rms.Models.Entities.Setup.Complex", "Complex")
                        .WithMany()
                        .HasForeignKey("ComplexId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Complex");
                });

            modelBuilder.Entity("Rms.Models.Entities.Menues.Menu", b =>
                {
                    b.Navigation("Submenu");
                });

            modelBuilder.Entity("Rms.Models.Entities.Permissions.PermissionFeature", b =>
                {
                    b.Navigation("Permissions");
                });

            modelBuilder.Entity("Rms.Models.Entities.Permissions.PermissionModule", b =>
                {
                    b.Navigation("PermissionFeatures");
                });
#pragma warning restore 612, 618
        }
    }
}
