using System;
using System.Collections.Generic;
using System.Text;

namespace ConferenceDTO
{
    public class SpeakerResponseDto : SpeakerDto
    {
        // TODO: Set order of JSON proeprties so this shows up last not first
        public ICollection<SessionDto> Sessions { get; set; } = new List<SessionDto>();     
    }
}