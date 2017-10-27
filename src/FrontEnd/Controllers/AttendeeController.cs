﻿using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FrontEnd.Controllers
{
    public class AttendeeController : Controller
    {
        private readonly IApiClient _apiClient;

        public AttendeeController(IApiClient apiClient)
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