using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StarWars.Model.Entities
{
    public class CharacterEpisode
    {
        public int Id { get; set; }

        public int EpisodeId { get; set; }

        public int CharacterId { get; set; }
        public Episode Episode { get; set; }
        public Character Character { get; set; }

        public CharacterEpisode(int id)
        {
            this.Id = id;
        }

    }
}
