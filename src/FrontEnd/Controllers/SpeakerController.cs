using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using FrontEnd.Models;
using Data.Models;
using ConferenceDTO;

namespace FrontEnd.Controllers
{
    public class SpeakerController : Controller
    {
        private readonly IApiClient _apiClient;
        private IOrderedEnumerable<SpeakerResponse> SessionSpeaker;

        public SpeakerController(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }
        
        public async Task OnGet()
        {
            var speakers = await _apiClient.GetSpeakersAsync();

            SessionSpeaker = speakers.OrderBy(s => s.Name);
        }
    }
}
