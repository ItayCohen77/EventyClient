using System;
using System.Collections.Generic;


namespace EventyApp.Models
{
    public partial class PlaceMedium
    {
        public int Id { get; set; }
        public int PlaceId { get; set; }
        public string PlaceType { get; set; }
        public string FilePath { get; set; }
        public string MimeType { get; set; }
        public virtual Place Place { get; set; }
    }
}
