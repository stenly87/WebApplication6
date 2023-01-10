using System;
using System.Collections.Generic;

namespace WebApplication6
{
    public partial class User
    {
        public int Id { get; set; }
        public string? Fio { get; set; }
        public string? Login { get; set; }
        public string? Password { get; set; }

        public virtual Session? Session { get; set; }
    }
}
