using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Conference
    {
        public int ID { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; }

        public ICollection<Track> Tracks { get; set; }

        public ICollection<Speaker> Speakers { get; set; }

        public ICollection<Session> Sessions { get; set; }

        public ICollection<ConferenceAttendee> ConferenceAttendees { get; set; }
    }
}