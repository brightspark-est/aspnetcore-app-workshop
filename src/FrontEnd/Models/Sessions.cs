﻿using ConferenceDTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Models
{
    public class Sessions
        //muutuja oli ka Session, sellepärast selline nimi
    {
        public SessionResponse Session { get; set; }

        public int? DayOffset { get; set; }

        public bool IsInPersonalAgenda { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [StringLength(4000)]
        public virtual string Abstract { get; set; }

        public virtual DateTimeOffset? StartTime { get; set; }
       
        public Session AsDto()
        {
            return new Session
            {                               
                Title = Title,                                
                StartTime = StartTime,
                Abstract = Abstract
            };
        }

    }
}
