using System;
using System.Collections.Generic;
using System.Text;

namespace StarWars.Model.Entities
{
    public class CharacterFriend
    {
        public int Id { get; set; }
        public int CharacterId {get; set; }
        public int FriendId { get; set; }

        public Character Friend { get; set; }
        public Character Character { get; set; }

        public CharacterFriend(int id)
        {
            this.Id = id;
        }

    }
}
