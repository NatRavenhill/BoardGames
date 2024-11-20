﻿// <auto-generated />
using System;
using BoardGamesContextLib;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BoardGamesContextLib.Migrations
{
    [DbContext(typeof(BoardGameContext))]
    [Migration("20241120144849_InitialGamesCreate")]
    partial class InitialGamesCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BoardGamesContextLib.Entities.GameDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BBGId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageLink")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("MaxPlayers")
                        .HasColumnType("tinyint");

                    b.Property<byte>("MinPlayers")
                        .HasColumnType("tinyint");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("PlayingTime")
                        .HasColumnType("smallint");

                    b.Property<short>("YearPublished")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("GameDetail");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BBGId = 320,
                            Description = "Carefully place your lettered tiles to make high-scoring words.",
                            ImageLink = "https://boardgamegeek.com/image/404651/scrabble",
                            MaxPlayers = (byte)4,
                            MinPlayers = (byte)2,
                            Name = "Scrabble",
                            PlayingTime = (short)90,
                            YearPublished = (short)1948
                        },
                        new
                        {
                            Id = 2,
                            BBGId = 65244,
                            Description = "The island is sinking! Will the brave adventurers save the treasures in time?",
                            ImageLink = "https://boardgamegeek.com/image/646458/forbidden-island",
                            MaxPlayers = (byte)4,
                            MinPlayers = (byte)2,
                            Name = "Forbidden Island",
                            PlayingTime = (short)30,
                            YearPublished = (short)2010
                        });
                });

            modelBuilder.Entity("BoardGamesContextLib.Entities.Loan", b =>
                {
                    b.Property<int>("LoanID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BorrowedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("GameID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ReturnedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LoanID");

                    b.ToTable("Loan");
                });
#pragma warning restore 612, 618
        }
    }
}
