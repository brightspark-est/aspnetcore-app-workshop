using System;
using System.Collections;
using System.Collections.Generic;

namespace Data.Models
{
    public class Session
    {
        public Conference Conference { get; set; }

        public virtual ICollection<SessionSpeaker> SessionSpeakers { get; set; }

        public Track Track { get; set; }

        public virtual ICollection<SessionTag> SessionTags { get; set; }
    }
}