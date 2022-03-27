using System;
using System.Collections.Generic;



namespace EventyApp.Models
{
    public partial class Apartment
    {
        public int Id { get; set; }
        public bool HasSpeakerAndMic { get; set; }
        public bool HasAirConditioner { get; set; }
        public bool HasTv { get; set; }
        public bool HasWaterHeater { get; set; }
        public bool HasCoffeeMachine { get; set; }
    }
}
