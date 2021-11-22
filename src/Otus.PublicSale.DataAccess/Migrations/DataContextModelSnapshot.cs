﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Otus.PublicSale.DataAccess.Data;

namespace Otus.PublicSale.DataAccess.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Otus.PublicSale.Core.Domain.Administration.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "User"
                        });
                });

            modelBuilder.Entity("Otus.PublicSale.Core.Domain.Administration.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Language")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BirthDay = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "admin@megaproject.com",
                            FirstName = "BO",
                            LastName = "Admin",
                            Password = "1qaz@WSX",
                            RoleId = 1
                        });
                });

            modelBuilder.Entity("Otus.PublicSale.Core.Domain.AuctionManagement.Auction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<decimal>("CurrentPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Descition")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime");

                    b.Property<decimal>("LowestPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("PriceStart")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("PriceStep")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("SellPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Auctions");
                });

            modelBuilder.Entity("Otus.PublicSale.Core.Domain.AuctionManagement.AuctionBet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,0)");

                    b.Property<int>("AuctionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuctionId");

                    b.HasIndex("UserId");

                    b.ToTable("AuctionBets");
                });

            modelBuilder.Entity("Otus.PublicSale.Core.Domain.AuctionManagement.AuctionFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuctionId")
                        .HasColumnType("int");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("AuctionId");

                    b.ToTable("AuctionFiles");
                });

            modelBuilder.Entity("Otus.PublicSale.Core.Domain.AuctionManagement.AuctionUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuctionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuctionId");

                    b.HasIndex("UserId");

                    b.ToTable("AuctionUsers");
                });

            modelBuilder.Entity("Otus.PublicSale.Core.Domain.AuctionManagement.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Otus.PublicSale.Core.Domain.AuctionManagement.Favorites", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AuctionId")
                        .HasColumnType("int");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AuctionId");

                    b.HasIndex("UserId");

                    b.ToTable("Favorites");
                });

            modelBuilder.Entity("Otus.PublicSale.Core.Domain.AuctionManagement.Subscriber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Subscribers");
                });

            modelBuilder.Entity("Otus.PublicSale.Core.Domain.Administration.User", b =>
                {
                    b.HasOne("Otus.PublicSale.Core.Domain.Administration.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_Users_Roles")
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Otus.PublicSale.Core.Domain.AuctionManagement.Auction", b =>
                {
                    b.HasOne("Otus.PublicSale.Core.Domain.AuctionManagement.Category", "Category")
                        .WithMany("Auctions")
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Otus.PublicSale.Core.Domain.AuctionManagement.AuctionBet", b =>
                {
                    b.HasOne("Otus.PublicSale.Core.Domain.AuctionManagement.Auction", "Auction")
                        .WithMany("AuctionBets")
                        .HasForeignKey("AuctionId")
                        .HasConstraintName("FK_Bets_Auctions")
                        .IsRequired();

                    b.HasOne("Otus.PublicSale.Core.Domain.Administration.User", "User")
                        .WithMany("AuctionBets")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Bets_Users")
                        .IsRequired();

                    b.Navigation("Auction");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Otus.PublicSale.Core.Domain.AuctionManagement.AuctionFile", b =>
                {
                    b.HasOne("Otus.PublicSale.Core.Domain.AuctionManagement.Auction", "Auction")
                        .WithMany("AuctionFiles")
                        .HasForeignKey("AuctionId")
                        .HasConstraintName("FK_AuctionsFiles_Auctions")
                        .IsRequired();

                    b.Navigation("Auction");
                });

            modelBuilder.Entity("Otus.PublicSale.Core.Domain.AuctionManagement.AuctionUser", b =>
                {
                    b.HasOne("Otus.PublicSale.Core.Domain.AuctionManagement.Auction", "Auction")
                        .WithMany("AuctionUsers")
                        .HasForeignKey("AuctionId")
                        .HasConstraintName("FK_AuctionsUsers_Auctions")
                        .IsRequired();

                    b.HasOne("Otus.PublicSale.Core.Domain.Administration.User", "User")
                        .WithMany("AuctionUsers")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_AuctionsUsers_Users")
                        .IsRequired();

                    b.Navigation("Auction");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Otus.PublicSale.Core.Domain.AuctionManagement.Favorites", b =>
                {
                    b.HasOne("Otus.PublicSale.Core.Domain.AuctionManagement.Auction", "Auction")
                        .WithMany()
                        .HasForeignKey("AuctionId");

                    b.HasOne("Otus.PublicSale.Core.Domain.Administration.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Auction");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Otus.PublicSale.Core.Domain.Administration.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Otus.PublicSale.Core.Domain.Administration.User", b =>
                {
                    b.Navigation("AuctionBets");

                    b.Navigation("AuctionUsers");
                });

            modelBuilder.Entity("Otus.PublicSale.Core.Domain.AuctionManagement.Auction", b =>
                {
                    b.Navigation("AuctionBets");

                    b.Navigation("AuctionFiles");

                    b.Navigation("AuctionUsers");
                });

            modelBuilder.Entity("Otus.PublicSale.Core.Domain.AuctionManagement.Category", b =>
                {
                    b.Navigation("Auctions");
                });
#pragma warning restore 612, 618
        }
    }
}
