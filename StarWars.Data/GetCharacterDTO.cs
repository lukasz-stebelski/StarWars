using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Data
{
    public class GetCharacterDTO
    {
        public GetCharacterDTO()
        {
            Episodes = new List<string>();
            Friends = new List<string>();
        }
        public string Name { get; set; }
        public string PlanetName { get; set; }

        public List<string> Episodes { get; set; }
        public List<string> Friends { get; set; }

    }
}
