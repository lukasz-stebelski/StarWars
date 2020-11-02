using Microsoft.EntityFrameworkCore;
using StarWars.Data;
using StarWars.Model;
using StarWars.Model.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace StarWars.Service
{
    public class CharacterRepository : RepositoryBase
    {
        public CharacterRepository(StarWarsContext context) : base(context)
        {

        }


        public void Update(SaveCharacterDTO obj)
        {
            Character characterToSave = Context.Character.FirstOrDefault(c => c.Id == obj.Id);
            if (characterToSave!= null)
            {
                characterToSave.Name = obj.Name;
                Context.SaveChanges();
            }
        }

        public SaveCharacterDTO Add(SaveCharacterDTO obj)
        {
            Character characterToSave = new Character();
            characterToSave.Name = obj.Name;
            Context.Character.Add(characterToSave);
            Context.SaveChanges();
            obj.Id = characterToSave.Id;
            return obj;
        }

        public void Delete(int id)
        {
            Character characterToDelete = Context.Character.FirstOrDefault(c => c.Id == id);
            if (characterToDelete != null)
            {
                Context.Remove(characterToDelete);
            }
            Context.SaveChanges();
        }

        public Character GetById(int id)
        {
            return Context.Character.FirstOrDefault(c=>c.Id == id);
        }

        public IQueryable<Character> GetAll()
        {
            return Context.Character.AsQueryable();
        }

        public IQueryable<GetCharacterDTO> GetAllExtended()
        {
            return Context.Character
                .Include(c => c.Planet)
                .Include(c => c.CharacterFriends)
                .Include(c => c.CharacterEpisodes)
                .Select(c => new GetCharacterDTO()
                {
                    Name = c.Name,
                    PlanetName = c.Planet == null ? null : c.Planet.Name,
                    Episodes = c.CharacterEpisodes.Select(ce => ce.Episode.Title).ToList(),
                    Friends = c.CharacterFriends.Select(ce => ce.Character.Name).ToList()
                })
                .AsQueryable();
        }

    }
}
