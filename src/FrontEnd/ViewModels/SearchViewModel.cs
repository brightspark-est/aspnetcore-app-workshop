using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.ViewModels
{
    public class SearchViewModel
    {
        public string Term { get; set; }

        public List<object> SearchResults { get; set; }
    }
}
