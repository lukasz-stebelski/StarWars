using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StarWars.Model.Entities
{
    public partial class Episode
    {
   

        public Episode(int id, string title) 
        {
            this.Title = title;
            this.Id = id;
        }
        public int Id { get; set; }
        public string Title { get; set; }


        public List<CharacterEpisode> CharacterEpisodes { get; set; }

    }
}
