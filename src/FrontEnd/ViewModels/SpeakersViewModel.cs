using ConferenceDTO;
using System.Collections.Generic;

namespace FrontEnd.ViewModels
{
    public class SpeakersViewModel
    {
        public IEnumerable<SpeakerResponseDto> Speakers { get; set; }
    }
}
