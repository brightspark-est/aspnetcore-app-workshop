using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConferenceDTO;
using System.ComponentModel.DataAnnotations;

namespace FrontEnd.ViewModels
{
    public class SpeakerViewModel
    {
        public IEnumerable<SpeakerResponseDto> Speaker { get; set; }
    }
}
