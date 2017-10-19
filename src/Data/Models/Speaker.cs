using System;
using System.Collections.Generic;

namespace BackEnd.Data
{
    public class Speaker
    {
        public virtual ICollection<SessionSpeaker> SessionSpeakers { get; set; } = new List<SessionSpeaker>();
    }
}