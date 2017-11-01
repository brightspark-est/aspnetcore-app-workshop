using FrontEnd.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FrontEnd.Controllers
{
    public class AttendeesController : Controller
    {
        private readonly IApiClient _apiClient;

        public AttendeesController(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IActionResult> OnPostAsync(AttendeeViewModel model)
        {
            await _apiClient.AddAttendeeAsync(model.AsDto());

            return RedirectToPage("/Index");
        }
    }
}
