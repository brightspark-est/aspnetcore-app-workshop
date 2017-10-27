using ConferenceDTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<IGrouping<DateTimeOffset?, SessionResponseDto>> Sessions { get; set; }

        public IEnumerable<(int Offset, DayOfWeek? DayofWeek)> DayOffsets { get; set; }

        public int CurrentDayOffset { get; set; }

        public bool IsAdmin { get; set; }

        public List<int> UserSessions { get; set; }

        [TempData]
        public string Message { get; set; }

        public bool ShowMessage => !string.IsNullOrEmpty(Message);
    }
}
