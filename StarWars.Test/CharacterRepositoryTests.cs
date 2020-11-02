using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWars.Model;
using StarWars.Service;
using System.Linq;

namespace StarWars.Test
{
    [TestClass]
    public class CharacterRepositoryTests
    {
        private StarWarsContext context;
        private string testCharacterName = "James Bond";
        private string testCharacterNameAfterChange = "James Bond (Sean Connery)";

        [TestInitialize]
        public void PrepareTesting()
        {
            context = new StarWarsContext();
        }

        [TestCleanup]
        public void CleanUp()
        {
            if (context != null)
            {
                RemoveCharacterByName(context, testCharacterName);
                RemoveCharacterByName(context, testCharacterNameAfterChange);
                context.SaveChanges();
                context.Dispose();
            }
        }

        private void RemoveCharacterByName(StarWarsContext context, string name)
        {
            var character = context.Character.FirstOrDefault(c => c.Name == name);
            if (character != null)
            {
                context.Remove(character);
            }
        }
        [TestMethod]
        public void CanAddCharacter()
        {
            CharacterRepository repo = new CharacterRepository(context);
            repo.Add(new Data.SaveCharacterDTO() { Name = testCharacterName });

            var testCheckedValue = context.Character.FirstOrDefault(c => c.Name == testCharacterName);

            Assert.IsNotNull(testCheckedValue);
        }

        [TestMethod]
        public void CanUpdateCharacter()
        {
            CharacterRepository repo = new CharacterRepository(context);
            var c = repo.Add(new Data.SaveCharacterDTO() { Name = testCharacterName });
            var testCheckedValueBefore = context.Character.FirstOrDefault(c => c.Name == testCharacterName);
            repo.Update(new Data.SaveCharacterDTO() { Id = c.Id, Name = testCharacterNameAfterChange});
            var testCheckedValueAfter = context.Character.FirstOrDefault(ch => ch.Id == c.Id);
            Assert.IsTrue(testCheckedValueAfter.Name == testCharacterNameAfterChange);
        }

    }
}
