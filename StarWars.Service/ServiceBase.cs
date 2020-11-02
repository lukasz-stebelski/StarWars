using StarWars.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace StarWars.Service
{
    public abstract class RepositoryBase
    {
        public RepositoryBase(StarWarsContext context)
        {
            this.Context = context;
        }

        public StarWarsContext Context { get; set; }
      
    }
}
