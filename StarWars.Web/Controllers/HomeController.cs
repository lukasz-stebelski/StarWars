using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StarWars.Service;
using StarWars.Web.Models;

namespace StarWars.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly CharacterRepository _characterRepository;
        private readonly EpisodeRepository _episodeRepository;
        private readonly PlaneteRepository _planeteRepository;
        public HomeController(ILogger<HomeController> logger, CharacterRepository characterRepository, EpisodeRepository episodeRepository, PlaneteRepository planeteRepository)
        {
            _logger = logger;
            _characterRepository = characterRepository;
            _episodeRepository = episodeRepository;
            _planeteRepository = planeteRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Characters()
        {
            return View(_characterRepository.GetAllExtended());
        }

        public IActionResult Planets()
        {
            return View(_planeteRepository.GetAllExtended());
        }

        public IActionResult Episodes()
        {
            return View(_episodeRepository.GetAllExtended());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
