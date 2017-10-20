using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Pages.Models
{
    public class Session
    {
        public int ID { get; set; }

        [Required]
        public int ConferenceID { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        public TimeSpan Duration => EndTime?.Subtract(StartTime ?? EndTime ?? DateTime.MinValue) ?? TimeSpan.Zero;

        public int? TrackId { get; set; }

        [DataType(DataType.MultilineText)]
        public string Abstract { get; set; }

        [DisplayName("Start time")]
        public DateTimeOffset? StartTime { get; set; }

        [DisplayName("End time")]
        public DateTimeOffset? EndTime { get; set; }
    }
}