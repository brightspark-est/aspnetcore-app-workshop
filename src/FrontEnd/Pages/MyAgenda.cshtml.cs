using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace FrontEnd.Pages
{
    public class MyAgendaModel : IndexModel
    {
        public MyAgendaModel(IApiClient client) : base(client)
        {

        }

        protected override Task<List<ConferenceDTO.SessionResponse>> GetSessionsAsync()
        {
            return _apiClient.GetSessionsByAttendeeAsync(User.Identity.Name);
        }
    }
}