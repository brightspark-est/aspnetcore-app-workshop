using ConferenceDTO;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Models
{
    public class SessionTag
    {
        public int SessionID { get; set; }

        public Session Session { get; set; }

        public int TagID { get; set; }

        public Tag Tag { get; set; }
    }
}