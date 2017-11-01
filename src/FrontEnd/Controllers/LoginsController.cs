using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using FrontEnd.ViewModels;

namespace FrontEnd.Controllers
{
    public class LoginsController : Controller
    {
        private readonly IAuthenticationSchemeProvider _schemeProvider;

        public LoginsController(IAuthenticationSchemeProvider schemeProvider)
        {
            _schemeProvider = schemeProvider;
        }

        public IEnumerable<AuthenticationScheme> AuthSchemes { get; set; }

        public async Task Details()
        {
            AuthSchemes = await _schemeProvider.GetRequestHandlerSchemesAsync();
        }

        public IActionResult Create(string scheme)
        {
            return Challenge(new AuthenticationProperties { RedirectUri = Url.Page("/Index") }, scheme);
        }

        public async Task<IActionResult> Index()
        {
            var vm = new LoginViewModel
            {
                AuthSchemes = await _schemeProvider.GetRequestHandlerSchemesAsync()
            };

            return View(vm);
        }
    }
}