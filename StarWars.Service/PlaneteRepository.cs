using Microsoft.EntityFrameworkCore;
using StarWars.Data;
using StarWars.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StarWars.Service
{
    public class PlaneteRepository : RepositoryBase
    {
        public PlaneteRepository(StarWarsContext context) : base(context)
        {

        }

        public IQueryable<GetPlanetDTO> GetAllExtended()
        {
            return Context.Planet
                .Include(c => c.Characters)
                .Select(c => new GetPlanetDTO()
                {
                    Name = c.Name,
                    Characters = c.Characters.Select(ce => ce.Name).ToList(),
                })
                .AsQueryable();
        }

    }
}
