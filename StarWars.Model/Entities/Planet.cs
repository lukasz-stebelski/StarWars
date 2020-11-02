using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Model.Entities
{
    public class Planet
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Planet(int id, string name)
        {
            this.Name = name;
            this.Id = id;
            Characters = new HashSet<Character>();
        }

        public virtual ICollection<Character> Characters { get; set; }
    }
}
