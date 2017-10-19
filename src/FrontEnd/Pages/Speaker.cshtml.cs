using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConferenceDTO;
using FrontEnd.Services;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;

namespace FrontEnd.Pages
{
    public class SpeakerModel : PageModel
    {
        private readonly IApiClient _apiClient;

        public SpeakerModel(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public IEnumerable<SpeakerResponse> Speakers { get; set; }

        public async Task OnGet()
        {
            var speakers = await _apiClient.GetSpeakersAsync();

            Speakers = speakers.OrderBy(s => s.Name);
        }
    }
}