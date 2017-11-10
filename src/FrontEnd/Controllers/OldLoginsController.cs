using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using FrontEnd.ViewModels;

namespace FrontEnd.Controllers
{
    public class OldLoginsController : Controller
    {
        private readonly IAuthenticationSchemeProvider _schemeProvider;

        public OldLoginsController(IAuthenticationSchemeProvider schemeProvider)
        {
            _schemeProvider = schemeProvider;
        }

        //public async Task Details()
        //{
        //    AuthSchemes = await _schemeProvider.GetRequestHandlerSchemesAsync();
        //}


        public IActionResult Create(string scheme)
        {
            return Challenge(new AuthenticationProperties { RedirectUri = Url.Page("/Index") }, scheme);
        }

        public async Task<IActionResult> Index()
        {
            var vm = new OldLoginViewModel
            {
                AuthSchemes = await _schemeProvider.GetRequestHandlerSchemesAsync()
            };

            return View(vm);
        }
    }
}