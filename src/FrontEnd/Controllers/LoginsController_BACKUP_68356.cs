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
<<<<<<< HEAD:src/FrontEnd/Controllers/LoginsController.cs

        public LoginsController(IAuthenticationSchemeProvider schemeProvider)
=======
        
        public LoginController(IAuthenticationSchemeProvider schemeProvider)
>>>>>>> 64390a426f9ba62c747964a1f6aa581f542daee9:src/FrontEnd/Controllers/LoginController.cs
        {
            _schemeProvider = schemeProvider;
        }

        public IEnumerable<AuthenticationScheme> AuthSchemes { get; set; }

        public async Task OnGet()
        {
            AuthSchemes = await _schemeProvider.GetRequestHandlerSchemesAsync();
        }

        public IActionResult OnPost(string scheme)
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