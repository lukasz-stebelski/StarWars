﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StarWars.Model;

namespace StarWars.Model.Migrations
{
    [DbContext(typeof(StarWarsContext))]
    [Migration("20201102165903_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StarWars.Model.Entities.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PlanetId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PlanetId");

                    b.ToTable("Character");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Luke Skywalker"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Darth Vader"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Han Solo"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Leia Organa",
                            PlanetId = 1
                        },
                        new
                        {
                            Id = 5,
                            Name = "Wilhuff Tarkin"
                        },
                        new
                        {
                            Id = 6,
                            Name = "C-3PO"
                        },
                        new
                        {
                            Id = 7,
                            Name = "R2-D2"
                        });
                });

            modelBuilder.Entity("StarWars.Model.Entities.CharacterEpisode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("EpisodeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("EpisodeId");

                    b.ToTable("CharacterEpisode");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CharacterId = 1,
                            EpisodeId = 1
                        },
                        new
                        {
                            Id = 2,
                            CharacterId = 1,
                            EpisodeId = 2
                        },
                        new
                        {
                            Id = 3,
                            CharacterId = 1,
                            EpisodeId = 3
                        },
                        new
                        {
                            Id = 4,
                            CharacterId = 2,
                            EpisodeId = 1
                        },
                        new
                        {
                            Id = 5,
                            CharacterId = 2,
                            EpisodeId = 2
                        },
                        new
                        {
                            Id = 6,
                            CharacterId = 2,
                            EpisodeId = 3
                        },
                        new
                        {
                            Id = 7,
                            CharacterId = 3,
                            EpisodeId = 1
                        },
                        new
                        {
                            Id = 8,
                            CharacterId = 3,
                            EpisodeId = 2
                        },
                        new
                        {
                            Id = 9,
                            CharacterId = 3,
                            EpisodeId = 3
                        },
                        new
                        {
                            Id = 10,
                            CharacterId = 4,
                            EpisodeId = 1
                        },
                        new
                        {
                            Id = 11,
                            CharacterId = 5,
                            EpisodeId = 1
                        },
                        new
                        {
                            Id = 12,
                            CharacterId = 5,
                            EpisodeId = 2
                        },
                        new
                        {
                            Id = 13,
                            CharacterId = 5,
                            EpisodeId = 3
                        },
                        new
                        {
                            Id = 14,
                            CharacterId = 6,
                            EpisodeId = 1
                        },
                        new
                        {
                            Id = 15,
                            CharacterId = 6,
                            EpisodeId = 2
                        },
                        new
                        {
                            Id = 16,
                            CharacterId = 6,
                            EpisodeId = 3
                        },
                        new
                        {
                            Id = 17,
                            CharacterId = 7,
                            EpisodeId = 1
                        },
                        new
                        {
                            Id = 18,
                            CharacterId = 7,
                            EpisodeId = 2
                        },
                        new
                        {
                            Id = 19,
                            CharacterId = 7,
                            EpisodeId = 3
                        });
                });

            modelBuilder.Entity("StarWars.Model.Entities.CharacterFriend", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<int>("FriendId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.HasIndex("FriendId");

                    b.ToTable("CharacterFriend");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CharacterId = 1,
                            FriendId = 3
                        },
                        new
                        {
                            Id = 2,
                            CharacterId = 1,
                            FriendId = 4
                        },
                        new
                        {
                            Id = 3,
                            CharacterId = 1,
                            FriendId = 6
                        },
                        new
                        {
                            Id = 4,
                            CharacterId = 1,
                            FriendId = 7
                        },
                        new
                        {
                            Id = 5,
                            CharacterId = 2,
                            FriendId = 5
                        },
                        new
                        {
                            Id = 6,
                            CharacterId = 3,
                            FriendId = 1
                        },
                        new
                        {
                            Id = 7,
                            CharacterId = 3,
                            FriendId = 4
                        },
                        new
                        {
                            Id = 8,
                            CharacterId = 3,
                            FriendId = 7
                        },
                        new
                        {
                            Id = 9,
                            CharacterId = 4,
                            FriendId = 1
                        },
                        new
                        {
                            Id = 10,
                            CharacterId = 4,
                            FriendId = 3
                        },
                        new
                        {
                            Id = 11,
                            CharacterId = 4,
                            FriendId = 6
                        },
                        new
                        {
                            Id = 12,
                            CharacterId = 4,
                            FriendId = 7
                        },
                        new
                        {
                            Id = 13,
                            CharacterId = 5,
                            FriendId = 2
                        },
                        new
                        {
                            Id = 14,
                            CharacterId = 6,
                            FriendId = 1
                        },
                        new
                        {
                            Id = 15,
                            CharacterId = 6,
                            FriendId = 3
                        },
                        new
                        {
                            Id = 16,
                            CharacterId = 6,
                            FriendId = 4
                        },
                        new
                        {
                            Id = 17,
                            CharacterId = 6,
                            FriendId = 7
                        },
                        new
                        {
                            Id = 18,
                            CharacterId = 7,
                            FriendId = 1
                        },
                        new
                        {
                            Id = 19,
                            CharacterId = 7,
                            FriendId = 3
                        },
                        new
                        {
                            Id = 20,
                            CharacterId = 7,
                            FriendId = 4
                        });
                });

            modelBuilder.Entity("StarWars.Model.Entities.Episode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Episodes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "NEWHOPE"
                        },
                        new
                        {
                            Id = 2,
                            Title = "EMPIRE"
                        },
                        new
                        {
                            Id = 3,
                            Title = "JEDI"
                        });
                });

            modelBuilder.Entity("StarWars.Model.Entities.Planet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Planet");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Alderaan"
                        });
                });

            modelBuilder.Entity("StarWars.Model.Entities.Character", b =>
                {
                    b.HasOne("StarWars.Model.Entities.Planet", "Planet")
                        .WithMany("Characters")
                        .HasForeignKey("PlanetId");
                });

            modelBuilder.Entity("StarWars.Model.Entities.CharacterEpisode", b =>
                {
                    b.HasOne("StarWars.Model.Entities.Character", "Character")
                        .WithMany("CharacterEpisodes")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StarWars.Model.Entities.Episode", "Episode")
                        .WithMany("CharacterEpisodes")
                        .HasForeignKey("EpisodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StarWars.Model.Entities.CharacterFriend", b =>
                {
                    b.HasOne("StarWars.Model.Entities.Character", "Character")
                        .WithMany("CharacterFriends")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("StarWars.Model.Entities.Character", "Friend")
                        .WithMany()
                        .HasForeignKey("FriendId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
