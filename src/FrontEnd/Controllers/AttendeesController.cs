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

        public async Task<IActionResult> Index()
        {
            return View("Index");
        }

        [HttpGet("username")]
        public async Task<IActionResult> Get(string username)
        {
            await _apiClient.GetAttendeeAsync(username);

            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Post(AttendeeViewModel model)
        {
            await _apiClient.AddAttendeeAsync(model.AsDto());

            return View("Index");
        }
    }
}
