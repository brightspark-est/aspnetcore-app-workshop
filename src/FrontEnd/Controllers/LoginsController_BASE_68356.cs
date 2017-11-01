using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;

namespace FrontEnd.Controllers
{
    public class LoginController : Controller
    {
        private readonly IAuthenticationSchemeProvider _schemeProvider;

        public LoginController(IAuthenticationSchemeProvider schemeProvider)
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
    }
}