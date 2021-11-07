using System;
using System.Collections.Generic;


namespace EventyApp.Models
{
    public partial class Place
    {
        public Place()
        {
            Orders = new List<Order>();
            PlaceMedia = new List<PlaceMedium>();
        }

        public int Id { get; set; }
        public int PlaceType { get; set; }
        public int TotalOccupancy { get; set; }
        public string Summary { get; set; }
        public string PlaceAddress { get; set; }
        public int Price { get; set; }
        public DateTime PublishedAt { get; set; }
        public int OwnerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public virtual User Owner { get; set; }
        public virtual List<Order> Orders { get; set; }
        public virtual List<PlaceMedium> PlaceMedia { get; set; }
    }
}
