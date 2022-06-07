using System;
using System.Collections.Generic;



namespace EventyApp.Models
{
    public partial class Place
    {
        public Place()
        {
            Orders = new HashSet<Order>();
            PlaceMedia = new HashSet<PlaceMedium>();
        }

        public int Id { get; set; }
        public int OwnerId { get; set; }
        public int PlaceType { get; set; }
        public int TotalOccupancy { get; set; }
        public string Summary { get; set; }
        public string PlaceAddress { get; set; }
        public string Apartment { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string Country { get; set; }
        public int Price { get; set; }
        public string PlaceImage1 { get; set; }
        public string PlaceImage2 { get; set; }
        public string PlaceImage3 { get; set; }
        public string PlaceImage4 { get; set; }
        public string PlaceImage5 { get; set; }
        public string PlaceImage6 { get; set; }
        public DateTime PublishedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public virtual User Owner { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<PlaceMedium> PlaceMedia { get; set; }
        public virtual PlaceType PlaceTypeNavigation { get; set; }
    }
}
