using System;
using System.Collections.Generic;

namespace Data.Models
{
    public class Speaker
    {
        public virtual ICollection<SessionSpeaker> SessionSpeakers { get; set; } = new List<SessionSpeaker>();
    }
}