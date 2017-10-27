using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.ViewModels
{
    public class LoginViewModel
    {
        public IEnumerable<AuthenticationScheme> AuthSchemes { get; set; }
    }
}
