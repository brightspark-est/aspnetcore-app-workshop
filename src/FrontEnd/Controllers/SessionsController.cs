﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using FrontEnd.Models;
using ConferenceDTO;
using Data.Models;

namespace FrontEnd.Controllers
{
    public class SessionsController : Controller
    {
        private readonly IApiClient _apiClient;
        private readonly HtmlEncoder _htmlEncoder;
        

        public SessionsController(IApiClient apiClient, HtmlEncoder htmlEncoder)
        {
            _apiClient = apiClient;
            _htmlEncoder = htmlEncoder;
        }

        public async Task<IActionResult> Index(int id)
        {
            var session = await _apiClient.GetSessionAsync(id);
            if (session == null)
            {
                return RedirectToPage("/Index");
            }

            var sessions = await _apiClient.GetSessionsByAttendeeAsync(User.Identity.Name);
            var allSessions = await _apiClient.GetSessionsAsync();
            var startDate = allSessions.Min(s => s.StartTime?.Date);

            if (!string.IsNullOrEmpty(session.Abstract))
            {
                session.Abstract = "<p>" + String.Join("</p><p>",
                                       session.Abstract.Split("\r\n", StringSplitOptions.RemoveEmptyEntries)) + "</p>";
            }

            var model = new FrontEnd.Models.SessionsViewModel {
                Session = session,
                IsInPersonalAgenda = sessions.Any(s => s.ID == id),
                DayOffset = session.StartTime?.DateTime.Subtract(startDate ?? DateTime.MinValue).Days,
            };

            return View(model);          
        }

        public async Task<IActionResult> Add(int sessionId)
        {
            await _apiClient.AddSessionToAttendeeAsync(User.Identity.Name, sessionId);

            return View(); //RedirectToPage
        }

        public async Task<IActionResult> Remove(int sessionId)
        {
            await _apiClient.RemoveSessionFromAttendeeAsync(User.Identity.Name, sessionId);

            return View(); //RedirectToPage
        }

    }
}