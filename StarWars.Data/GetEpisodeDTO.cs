using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Data
{
    public class GetEpisodeDTO
    {
        public GetEpisodeDTO()
        {
            Characters = new List<string>();
        }
        public string Title { get; set; }
        public List<string> Characters { get; set; }
    }
}
