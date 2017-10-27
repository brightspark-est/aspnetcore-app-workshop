using System;
using System.Collections.Generic;
using System.Text;

namespace ConferenceDTO
{
    public class TagResponseDto : TagDto
    {
        public ICollection<SessionDto> Sessions { get; set; } = new List<SessionDto>();
    }
}