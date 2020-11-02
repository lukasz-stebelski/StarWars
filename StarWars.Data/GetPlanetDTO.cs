using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Data
{
    public class GetPlanetDTO
    {
        public GetPlanetDTO()
        {
            Characters = new List<string>();
        }
        public string Name { get; set; }
        public List<string> Characters { get; set; }
    }
}
