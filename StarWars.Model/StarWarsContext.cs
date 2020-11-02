using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StarWars.Model.Entities;
using System.Collections.Generic;
using System.IO;

namespace StarWars.Model
{
    public class StarWarsContext : DbContext
    {
        public StarWarsContext()
        {

        }
        public StarWarsContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Character> Character { get; set; }
        public DbSet<Episode> Episodes { get; set; }
        public DbSet<CharacterEpisode> CharacterEpisode { get; set; }
        public DbSet<CharacterFriend> CharacterFriend { get; set; }
        public DbSet<Planet> Planet { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=StarWarsDB;Integrated Security=True");

            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

                var connectionString = configuration.GetConnectionString("StarWarsDatabase");
                optionsBuilder.UseSqlServer(connectionString);
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            modelBuilder.Entity<CharacterEpisode>()
                .HasKey(ce => ce.Id);

            modelBuilder.Entity<CharacterEpisode>()
                .HasOne(ce => ce.Character)
                .WithMany(ce => ce.CharacterEpisodes)
                .HasForeignKey(bc => bc.CharacterId);

            /*
            modelBuilder.Entity<CharacterEpisode>()
                .HasOne(bc => bc.Episode)
                .WithMany(c => c.CharacterEpisodes)
                .HasForeignKey(bc => bc.EpisodeId);
            */

            modelBuilder.Entity<CharacterFriend>()
                .HasKey(ce => ce.Id);


            modelBuilder.Entity<CharacterFriend>()
                .HasOne(ce => ce.Character)
                .WithMany(ce => ce.CharacterFriends)
                .HasForeignKey(bc => bc.CharacterId)
                .OnDelete(DeleteBehavior.NoAction);

            /*
            modelBuilder.Entity<CharacterFriend>()
                .HasOne(bc => bc.Character)
                .WithMany(c => c.CharacterFriends)
                .HasForeignKey(bc => bc.CharacterId)
                .OnDelete(DeleteBehavior.NoAction);
             */
            modelBuilder.Entity<Character>().Property(c => c.PlanetId).IsRequired(false);
            modelBuilder.Entity<Planet>().HasMany(c => c.Characters).WithOne(e => e.Planet);
            modelBuilder.Entity<Character>().HasOne(c => c.Planet).WithMany(e => e.Characters);


            modelBuilder.Entity<Character>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Episode>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<CharacterEpisode>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<CharacterFriend>().Property(e => e.Id).ValueGeneratedOnAdd();


            DataSeed(modelBuilder);


        }

        private void DataSeed(ModelBuilder modelBuilder)
        {
            Planet[] planets = new Planet[]
            {
                new Planet(1, "Alderaan")
            };

            Character[] people = new Character[]
            {
                new Character(1,"Luke Skywalker"),
                new Character(2,"Darth Vader"),
                new Character(3,"Han Solo"),
                new Character(4,"Leia Organa") { PlanetId = 1 },
                new Character(5,"Wilhuff Tarkin"),
                new Character(6,"C-3PO"),
                new Character(7,"R2-D2")
            };

            Episode[] episodes = new Episode[]
            {
                new Episode(1,"NEWHOPE"),
                new Episode(2,"EMPIRE"),
                new Episode(3,"JEDI")
            };

            CharacterEpisode[] mappings = new CharacterEpisode[]
            {
                new CharacterEpisode(1) { CharacterId = 1, EpisodeId = 1},
                new CharacterEpisode(2) { CharacterId = 1, EpisodeId = 2 },
                new CharacterEpisode(3) { CharacterId = 1, EpisodeId = 3 },
                new CharacterEpisode(4) { CharacterId = 2, EpisodeId = 1 },
                new CharacterEpisode(5) { CharacterId = 2, EpisodeId = 2 },
                new CharacterEpisode(6) { CharacterId = 2, EpisodeId = 3 },
                new CharacterEpisode(7) { CharacterId = 3, EpisodeId = 1 },
                new CharacterEpisode(8) { CharacterId = 3, EpisodeId = 2 },
                new CharacterEpisode(9) { CharacterId = 3, EpisodeId = 3 },
                new CharacterEpisode(10) { CharacterId = 4, EpisodeId = 1 },
                new CharacterEpisode(11) { CharacterId = 5, EpisodeId = 1 },
                new CharacterEpisode(12) { CharacterId = 5, EpisodeId = 2 },
                new CharacterEpisode(13) { CharacterId = 5, EpisodeId = 3 },
                new CharacterEpisode(14) { CharacterId = 6, EpisodeId = 1 },
                new CharacterEpisode(15) { CharacterId = 6, EpisodeId = 2 },
                new CharacterEpisode(16) { CharacterId = 6, EpisodeId = 3 },
                new CharacterEpisode(17) { CharacterId = 7, EpisodeId = 1 },
                new CharacterEpisode(18) { CharacterId = 7, EpisodeId = 2 },
                new CharacterEpisode(19) { CharacterId = 7, EpisodeId = 3 }
            };

            CharacterFriend[] friends = new CharacterFriend[]
            {
                new CharacterFriend(1) { CharacterId = 1, FriendId = 3 },
                new CharacterFriend(2) { CharacterId = 1, FriendId = 4 },
                new CharacterFriend(3) { CharacterId = 1, FriendId = 6 },
                new CharacterFriend(4) { CharacterId = 1, FriendId = 7 },
                new CharacterFriend(5) { CharacterId = 2, FriendId = 5 },
                new CharacterFriend(6) { CharacterId = 3, FriendId = 1 },
                new CharacterFriend(7) { CharacterId = 3, FriendId = 4 },
                new CharacterFriend(8) { CharacterId = 3, FriendId = 7 },
                new CharacterFriend(9) { CharacterId = 4, FriendId = 1 },
                new CharacterFriend(10) { CharacterId = 4, FriendId = 3 },
                new CharacterFriend(11) { CharacterId = 4, FriendId = 6 },
                new CharacterFriend(12) { CharacterId = 4, FriendId = 7 },
                new CharacterFriend(13) { CharacterId = 5, FriendId = 2 },
                new CharacterFriend(14) { CharacterId = 6, FriendId = 1 },
                new CharacterFriend(15) { CharacterId = 6, FriendId = 3 },
                new CharacterFriend(16) { CharacterId = 6, FriendId = 4 },
                new CharacterFriend(17) { CharacterId = 6, FriendId = 7 },
                new CharacterFriend(18) { CharacterId = 7, FriendId = 1 },
                new CharacterFriend(19) { CharacterId = 7, FriendId = 3 },
                new CharacterFriend(20) { CharacterId = 7, FriendId = 4 }
            };


            modelBuilder.Entity<Planet>().HasData(planets);
            modelBuilder.Entity<Character>().HasData(people);
            modelBuilder.Entity<Episode>().HasData(episodes);
            modelBuilder.Entity<CharacterEpisode>().HasData(mappings);
            modelBuilder.Entity<CharacterFriend>().HasData(friends);
        }


    }
}
