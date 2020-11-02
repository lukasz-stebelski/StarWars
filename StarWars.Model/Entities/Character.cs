using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Text;

namespace StarWars.Model.Entities
{
    public partial class Character
    {
        public Character()
        { 
        
        }
        public Character(int id, string name) 
        {
            this.Name = name;
            this.Id = id;
        }
        
        public int Id { get; set; }
        public string Name { get; set; }
        public int? PlanetId { get; set; }
        public Planet Planet { get; set; }
        public List<CharacterEpisode> CharacterEpisodes { get; set; }
        public List<CharacterFriend> CharacterFriends { get; set; }
         
    }
}
