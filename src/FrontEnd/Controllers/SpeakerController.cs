using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConferenceDTO;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FrontEnd.ViewModels;

namespace FrontEnd.Controllers
{
    public class SpeakerController : Controller
    {
        private readonly IApiClient _apiClient;

        public SpeakerController(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IActionResult> Index(int id)
        {
            var model = new SpeakerViewModel
            {
                Speaker = await _apiClient.GetSpeakerAsync(id)
            };

            if (model.Speaker == null)
            {
                return NotFound();
            }

            return View(model);
        }
    }
}
