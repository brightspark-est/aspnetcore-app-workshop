using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConferenceDTO;
using System.ComponentModel.DataAnnotations;

namespace FrontEnd.Models
{
    public class SpeakersViewModel
    {
        public IEnumerable<SpeakerResponseDto> Speaker { get; set; }


        //[Required]
        //[StringLength(200)]
        //public string Name { get; set; }

        //[StringLength(4000)]
        //public string Bio { get; set; }

        //[StringLength(1000)]
        //public virtual string WebSite { get; set; }

        //public ConferenceDTO.Speaker AsDto()
        //{
        //    return new ConferenceDTO.Speaker
        //    {               
        //        Name = Name,
        //        Bio = Bio,
        //        WebSite = WebSite
        //    };
        //}



    }
}
