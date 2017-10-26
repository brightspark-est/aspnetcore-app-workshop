using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FrontEnd.Controllers
{
    public class WelcomeController : Controller
    {


        private readonly IApiClient _apiClient;

        public WelcomeController(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task<IActionResult> OnPostAsync(Welcome model)
        {
            
            

            await _apiClient.AddAttendeeAsync(model.Attendee.AsDto());

            return RedirectToPage("/Index");
        }
    }
}
