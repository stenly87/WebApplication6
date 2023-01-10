using System;
using System.Collections.Generic;

namespace WebApplication6
{
    public partial class Session
    {
        public int IdUser { get; set; }
        public string SessionKey { get; set; } = null!;
        public DateTime Start { get; set; }
        public DateTime Expiration { get; set; }

        public virtual User IdUserNavigation { get; set; } = null!;
    }
}
