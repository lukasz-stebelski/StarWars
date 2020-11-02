using Microsoft.EntityFrameworkCore;
using StarWars.Data;
using StarWars.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StarWars.Service
{
    public class EpisodeRepository : RepositoryBase
    {
        public EpisodeRepository(StarWarsContext context) : base(context)
        {

        }

        public IQueryable<GetEpisodeDTO> GetAllExtended()
        {
            return Context.Episodes
                .Include(c => c.CharacterEpisodes)
                .ThenInclude(ce=>ce.Character)
                .Select(c => new GetEpisodeDTO()
                {
                    Title = c.Title,
                    Characters = c.CharacterEpisodes.Select(ce => ce.Character.Name).ToList(),
                })
                .AsQueryable();
        }

    }
}
