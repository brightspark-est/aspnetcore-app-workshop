using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using FrontEnd.ViewModels;
using Data.Models;
using ConferenceDTO;

namespace FrontEnd.Controllers
{
    public class SpeakersController : Controller
    {
        private readonly IApiClient _apiClient;

        public SpeakersController(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        
        public async Task<IActionResult> Index()
        {
            IEnumerable<SpeakerResponseDto> speakers = await _apiClient.GetSpeakersAsync();
            speakers = speakers.OrderBy(s => s.Name);

            var model = new SpeakersViewModel
            {
                Speaker = speakers
            };

            return View(model);
        }
    }
}
