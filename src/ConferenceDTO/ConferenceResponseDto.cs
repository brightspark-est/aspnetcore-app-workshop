using System;
using System.Collections.Generic;
using System.Text;

namespace ConferenceDTO
{
    public class ConferenceResponseDto : ConferenceDto
    {
        public ICollection<SessionDto> Sessions { get; set; } = new List<SessionDto>();

        public ICollection<TrackDto> Tracks { get; set; } = new List<TrackDto>();

        public ICollection<SpeakerDto> Speakers { get; set; } = new List<SpeakerDto>();
    }
}