using System;
using System.Collections.Generic;
using System.Text;

namespace EventyApp.Models
{
    public class LikedPlace
    {
        public int UserId { get; set; }
        public int PlaceId { get; set; }
        public virtual User User { get; set; }
    }
}
