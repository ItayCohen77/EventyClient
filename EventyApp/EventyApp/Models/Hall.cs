using System;
using System.Collections.Generic;


namespace EventyApp.Models
{
    public partial class Hall
    {
        public int Id { get; set; }
        public int PlaceId { get; set; }
        public bool HasTables { get; set; }
        public bool HasChairs { get; set; }
        public bool HasSpeakerAndMic { get; set; }
        public bool HasProjector { get; set; }
        public bool HasBar { get; set; }
    }
}
