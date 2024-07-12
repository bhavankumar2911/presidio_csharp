﻿// <auto-generated />
using System;
using BankingApp.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BankingApp.Migrations
{
    [DbContext(typeof(AtmContext))]
    [Migration("20240711135841_models")]
    partial class models
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.32")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BankingApp.Models.Account", b =>
                {
                    b.Property<long>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("AccountId"), 1L, 1);

                    b.Property<double>("CurrentAmount")
                        .HasColumnType("float");

                    b.Property<DateTime>("DateOfCreation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("AccountId");

                    b.HasIndex("UserId");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            AccountId = 1L,
                            CurrentAmount = 5000.0,
                            DateOfCreation = new DateTime(2024, 7, 11, 13, 58, 41, 670, DateTimeKind.Utc).AddTicks(5456),
                            Type = "Savings",
                            UserId = 1
                        },
                        new
                        {
                            AccountId = 2L,
                            CurrentAmount = 25000.0,
                            DateOfCreation = new DateTime(2024, 7, 11, 13, 58, 41, 670, DateTimeKind.Utc).AddTicks(5459),
                            Type = "Current",
                            UserId = 1
                        },
                        new
                        {
                            AccountId = 3L,
                            CurrentAmount = 3000.0,
                            DateOfCreation = new DateTime(2024, 7, 11, 13, 58, 41, 670, DateTimeKind.Utc).AddTicks(5459),
                            Type = "Savings",
                            UserId = 2
                        },
                        new
                        {
                            AccountId = 4L,
                            CurrentAmount = 8000.0,
                            DateOfCreation = new DateTime(2024, 7, 11, 13, 58, 41, 670, DateTimeKind.Utc).AddTicks(5460),
                            Type = "Current",
                            UserId = 3
                        });
                });

            modelBuilder.Entity("BankingApp.Models.Atm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("BankName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Atms");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BankName = "A Bank",
                            Location = "123 Park Ave"
                        },
                        new
                        {
                            Id = 2,
                            BankName = "B Bank",
                            Location = "456 Elm St"
                        });
                });

            modelBuilder.Entity("BankingApp.Models.Card", b =>
                {
                    b.Property<long>("CardNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("CardNumber"), 1L, 1);

                    b.Property<long>("AccountId")
                        .HasColumnType("bigint");

                    b.Property<string>("BankName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Expiry")
                        .HasColumnType("datetime2");

                    b.Property<string>("PIN")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CardNumber");

                    b.HasIndex("AccountId");

                    b.ToTable("Cards");

                    b.HasData(
                        new
                        {
                            CardNumber = 1234567890123456L,
                            AccountId = 1L,
                            BankName = "A Bank",
                            Expiry = new DateTime(2027, 7, 11, 13, 58, 41, 670, DateTimeKind.Utc).AddTicks(5470),
                            PIN = "1234"
                        },
                        new
                        {
                            CardNumber = 2345678901234567L,
                            AccountId = 2L,
                            BankName = "B Bank",
                            Expiry = new DateTime(2026, 7, 11, 13, 58, 41, 670, DateTimeKind.Utc).AddTicks(5475),
                            PIN = "5678"
                        },
                        new
                        {
                            CardNumber = 3456789012345678L,
                            AccountId = 3L,
                            BankName = "A Bank",
                            Expiry = new DateTime(2027, 7, 11, 13, 58, 41, 670, DateTimeKind.Utc).AddTicks(5476),
                            PIN = "9876"
                        });
                });

            modelBuilder.Entity("BankingApp.Models.Transaction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<long>("AccountId")
                        .HasColumnType("bigint");

                    b.Property<int?>("AtmId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<long>("CardNumber")
                        .HasColumnType("bigint");

                    b.Property<double>("TransactionAmount")
                        .HasColumnType("float");

                    b.Property<DateTime>("TransactionDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("TransactionType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AccountId");

                    b.HasIndex("AtmId");

                    b.HasIndex("CardNumber");

                    b.ToTable("Transactions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccountId = 1L,
                            AtmId = 1,
                            CardNumber = 1234567890123456L,
                            TransactionAmount = 50.0,
                            TransactionDate = new DateTime(2024, 7, 11, 13, 58, 41, 670, DateTimeKind.Utc).AddTicks(5490),
                            TransactionType = "Withdrawal"
                        },
                        new
                        {
                            Id = 2,
                            AccountId = 1L,
                            AtmId = 2,
                            CardNumber = 1234567890123456L,
                            TransactionAmount = 100.0,
                            TransactionDate = new DateTime(2024, 7, 11, 13, 58, 41, 670, DateTimeKind.Utc).AddTicks(5491),
                            TransactionType = "Deposit"
                        },
                        new
                        {
                            Id = 3,
                            AccountId = 2L,
                            AtmId = 1,
                            CardNumber = 2345678901234567L,
                            TransactionAmount = 20.0,
                            TransactionDate = new DateTime(2024, 7, 11, 13, 58, 41, 670, DateTimeKind.Utc).AddTicks(5492),
                            TransactionType = "Withdrawal"
                        },
                        new
                        {
                            Id = 4,
                            AccountId = 2L,
                            AtmId = 2,
                            CardNumber = 2345678901234567L,
                            TransactionAmount = 10.0,
                            TransactionDate = new DateTime(2024, 7, 11, 13, 58, 41, 670, DateTimeKind.Utc).AddTicks(5493),
                            TransactionType = "Withdrawal"
                        },
                        new
                        {
                            Id = 5,
                            AccountId = 3L,
                            AtmId = 1,
                            CardNumber = 3456789012345678L,
                            TransactionAmount = 200.0,
                            TransactionDate = new DateTime(2024, 7, 11, 13, 58, 41, 670, DateTimeKind.Utc).AddTicks(5493),
                            TransactionType = "Deposit"
                        },
                        new
                        {
                            Id = 6,
                            AccountId = 3L,
                            AtmId = 2,
                            CardNumber = 3456789012345678L,
                            TransactionAmount = 50.0,
                            TransactionDate = new DateTime(2024, 7, 11, 13, 58, 41, 670, DateTimeKind.Utc).AddTicks(5494),
                            TransactionType = "Withdrawal"
                        });
                });

            modelBuilder.Entity("BankingApp.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "123 Main St",
                            Name = "John Doe",
                            Phone = "123-456-7890"
                        },
                        new
                        {
                            Id = 2,
                            Address = "456 Elm St",
                            Name = "Jane Smith",
                            Phone = "987-654-3210"
                        },
                        new
                        {
                            Id = 3,
                            Address = "789 Oak St",
                            Name = "Alice Johnson",
                            Phone = "555-555-5555"
                        });
                });

            modelBuilder.Entity("BankingApp.Models.Account", b =>
                {
                    b.HasOne("BankingApp.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("BankingApp.Models.Card", b =>
                {
                    b.HasOne("BankingApp.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("BankingApp.Models.Transaction", b =>
                {
                    b.HasOne("BankingApp.Models.Account", "Account")
                        .WithMany("Transactions")
                        .HasForeignKey("AccountId")
                        .IsRequired();

                    b.HasOne("BankingApp.Models.Atm", "Atm")
                        .WithMany("Transactions")
                        .HasForeignKey("AtmId")
                        .IsRequired();

                    b.HasOne("BankingApp.Models.Card", "Card")
                        .WithMany("TransactionList")
                        .HasForeignKey("CardNumber")
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Atm");

                    b.Navigation("Card");
                });

            modelBuilder.Entity("BankingApp.Models.Account", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("BankingApp.Models.Atm", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("BankingApp.Models.Card", b =>
                {
                    b.Navigation("TransactionList");
                });
#pragma warning restore 612, 618
        }
    }
}