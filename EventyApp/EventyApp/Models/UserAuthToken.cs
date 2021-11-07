using System;
using System.Collections.Generic;


namespace EventyApp.Models
{
    public partial class UserAuthToken
    {
        public int UserId { get; set; }
        public string AuthToken { get; set; }
        public virtual User User { get; set; }
    }
}
