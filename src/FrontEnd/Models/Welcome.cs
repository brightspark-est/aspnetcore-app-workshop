using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace FrontEnd.Models
{
    public class Welcome
    {
        [BindProperty]
        public Attendee Attendee { get; set; }
    }
}
