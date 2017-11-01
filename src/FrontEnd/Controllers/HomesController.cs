using ConferenceDTO;
using FrontEnd.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Controllers
{
    public class HomesController : Controller
    {
        protected readonly IApiClient _apiClient;

        public HomesController(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        protected virtual Task<List<SessionResponseDto>> GetSessionsAsync()
        {
            return _apiClient.GetSessionsAsync();
        }

        public async Task<IActionResult> Index(int day = 0)
        {
            var userSessions = new List<SessionResponseDto>();

            userSessions = await _apiClient.GetSessionsByAttendeeAsync(User.Identity.Name);

            var sessions = await GetSessionsAsync();

            var startDate = sessions.Min(s => s.StartTime?.Date);
            var endDate = sessions.Max(s => s.EndTime?.Date);

            var numberOfDays = ((endDate - startDate)?.Days) + 1;

            var filterDate = startDate?.AddDays(day);

            return View(new MyAgendaViewModel
            {
                CurrentDayOffset = day,

                UserSessions = userSessions.Select(u => u.ID).ToList(),

                DayOffsets = Enumerable.Range(0, numberOfDays ?? 0)
                    .Select(offset => (offset, (startDate?.AddDays(offset))?.DayOfWeek)),

                Sessions = sessions.Where(s => s.StartTime?.Date == filterDate)
                                   .OrderBy(s => s.TrackId)
                                   .GroupBy(s => s.StartTime)
                                   .OrderBy(g => g.Key)
            });
        }

        public async Task<IActionResult> OnPostAsync(int sessionId)
        {
            await _apiClient.AddSessionToAttendeeAsync(User.Identity.Name, sessionId);

            return View();
        }

        public async Task<IActionResult> OnPostRemoveAsync(int sessionId)
        {
            await _apiClient.RemoveSessionFromAttendeeAsync(User.Identity.Name, sessionId);

            return View();
        }
    }
}