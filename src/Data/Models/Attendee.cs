using System;
using System.Collections.Generic;

namespace Data.Models
{
    public class Attendee
    {
        public virtual ICollection<ConferenceAttendee> ConferenceAttendees { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }
    }
}