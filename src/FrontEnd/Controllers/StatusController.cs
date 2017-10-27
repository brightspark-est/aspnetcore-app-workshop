using FrontEnd.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Controllers
{
    public class StatusController : Controller
    {
        public void Status(int statusCode)
        {
            var vm = new StatusViewModel();
                       
            vm.StatusCode = statusCode;

            switch (statusCode)
            {
                case StatusCodes.Status404NotFound:
                    vm.StatusCodeMessage = "Not Found";
                    break;
            }
        }
    }
}
