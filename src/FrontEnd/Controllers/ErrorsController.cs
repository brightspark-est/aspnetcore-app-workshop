﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FrontEnd.ViewModels;
using System.Diagnostics;

namespace FrontEnd.Controllers
{
    public class ErrorsController : Controller
    {
        private ErrorViewModel _error;

        public ErrorsController(ErrorViewModel error)
        {
            _error = error;
        }

        public void OnGet()
        {
            _error.RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}