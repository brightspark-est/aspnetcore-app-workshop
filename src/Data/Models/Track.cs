using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Models
{
    public class Track
    {
        [Required]
        public Conference Conference { get; set; }

        public virtual ICollection<Session> Sessions { get; set; }
    }
}