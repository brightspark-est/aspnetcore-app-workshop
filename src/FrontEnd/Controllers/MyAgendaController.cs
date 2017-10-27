using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class MyAgendaController : HomeController
    {
        public MyAgendaController(IApiClient client) : base(client)
        {

        }

        protected override Task<List<ConferenceDTO.SessionResponseDto>> GetSessionsAsync()
        {
            return _apiClient.GetSessionsByAttendeeAsync(User.Identity.Name);
        }
    }
}