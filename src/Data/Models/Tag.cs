using System.Collections.Generic;

namespace BackEnd.Data
{
    public class Tag
    {
        public virtual ICollection<SessionTag> SessionTags { get; set; }
    }
}