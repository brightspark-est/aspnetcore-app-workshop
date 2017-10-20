using System.Collections.Generic;

namespace Data.Models
{ 

    public class Tag
    {
        public virtual ICollection<SessionTag> SessionTags { get; set; }
    }
}