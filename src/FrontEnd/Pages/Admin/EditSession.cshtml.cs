using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ConferenceDTO;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace FrontEnd.Pages.Admin
{
    public class EditSessionModel : PageModel
    {
        private readonly IApiClient _apiClient;

        public EditSessionModel(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        [TempData]
        public string Message { get; set; }

        public bool ShowMessage => !string.IsNullOrEmpty(Message);

        [BindProperty]
        public SessionDto Session { get; set; }

        public async Task OnGetAsync(int id)
        {
            var session = await _apiClient.GetSessionAsync(id);
            Session = new SessionDto
            {
                ID = session.ID,
                ConferenceID = session.ConferenceID,
                TrackId = session.TrackId,
                Title = session.Title,
                Abstract = session.Abstract,
                StartTime = session.StartTime,
                EndTime = session.EndTime
            };
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Message = "Session updated successfully!";

            await _apiClient.PutSessionAsync(Session);

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var session = await _apiClient.GetSessionAsync(id);

            if (session != null)
            {
                await _apiClient.DeleteSessionAsync(id);
            }

            Message = "Session deleted successfully!";

            return RedirectToPage("/Index");
        }
    }
}