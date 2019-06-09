﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebApp.Models;
using AppContext = WebApp.Models.AppContext;

namespace WebApp.Migrations
{
    [DbContext(typeof(AppContext))]
    [Migration("20190609001039_ItemDescription")]
    partial class ItemDescription
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "3.0.0-preview5.19227.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("WebApp.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Gender")
                        .IsRequired();

                    b.Property<DateTime>("LastTimeOnline");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("Characters");
                });

            modelBuilder.Entity("WebApp.Models.CharacterResultEntry", b =>
                {
                    b.Property<int>("PlayerId");

                    b.Property<int>("GameSessionId");

                    b.Property<int?>("CapturedFlags");

                    b.Property<int?>("StunnedPlayers");

                    b.HasKey("PlayerId", "GameSessionId");

                    b.HasIndex("GameSessionId");

                    b.ToTable("CharactersResults");
                });

            modelBuilder.Entity("WebApp.Models.GameSession", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BeginDateTime");

                    b.Property<DateTime>("EndDateTime");

                    b.Property<int>("MissionId");

                    b.HasKey("Id");

                    b.HasIndex("MissionId");

                    b.ToTable("GameSessions");
                });

            modelBuilder.Entity("WebApp.Models.InventoryEntry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ItemId");

                    b.Property<int>("PlayerId");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("PlayerId");

                    b.ToTable("Inventories");
                });

            modelBuilder.Entity("WebApp.Models.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Rarity")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("WebApp.Models.Map", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("Maps");
                });

            modelBuilder.Entity("WebApp.Models.Mission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("MapId");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("RequiredPlayersNumber");

                    b.Property<int?>("TargetCapturedFlags");

                    b.Property<int?>("TargetScore");

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.HasIndex("MapId");

                    b.ToTable("Missions");
                });

            modelBuilder.Entity("WebApp.Models.CharacterResultEntry", b =>
                {
                    b.HasOne("WebApp.Models.GameSession", "GameSession")
                        .WithMany("ParticipatorsResults")
                        .HasForeignKey("GameSessionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApp.Models.Character", "Character")
                        .WithMany("Results")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApp.Models.GameSession", b =>
                {
                    b.HasOne("WebApp.Models.Mission", "Mission")
                        .WithMany()
                        .HasForeignKey("MissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApp.Models.InventoryEntry", b =>
                {
                    b.HasOne("WebApp.Models.Item", "Item")
                        .WithMany("InventoryEntries")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApp.Models.Character", "Owner")
                        .WithMany("Inventory")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WebApp.Models.Mission", b =>
                {
                    b.HasOne("WebApp.Models.Map", "MissionMap")
                        .WithMany("Missions")
                        .HasForeignKey("MapId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
