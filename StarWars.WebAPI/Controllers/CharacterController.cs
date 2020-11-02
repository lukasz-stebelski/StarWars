using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StarWars.Data;
using StarWars.Service;


namespace StarWars.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        public CharacterRepository CharacterRepository { get; set; }


        private readonly ILogger<CharacterController> _logger;

        public CharacterController(ILogger<CharacterController> logger, CharacterRepository characterRepository)
        {
            _logger = logger;
            CharacterRepository = characterRepository;
        }

        [HttpGet]
        public JsonResult GetAll()
        {
            var result = CharacterRepository.GetAll();
            return new JsonResult(result);
        }

        [HttpPost]
        public JsonResult Add(SaveCharacterDTO character)
        {
            var res = CharacterRepository.Add(character);
            return new JsonResult(res);
        }

        [HttpPut]
        public JsonResult Update(SaveCharacterDTO character)
        {
            CharacterRepository.Update(character);
            return new JsonResult(true);
        }


        [HttpDelete]
        public JsonResult Delete(int id)
        {
            CharacterRepository.Delete(id);
            return new JsonResult(true);
        }

    }
}
