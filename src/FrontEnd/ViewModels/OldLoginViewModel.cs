using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.ViewModels
{
    public class OldLoginViewModel
    {
        public IEnumerable<AuthenticationScheme> AuthSchemes { get; set; }
    }
}
