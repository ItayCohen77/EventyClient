using System;
using System.Collections.Generic;


namespace EventyApp.Models
{
    public partial class Order
    {      
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PlaceId { get; set; }
        public int Price { get; set; }
        public int Total { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime EventDate { get; set; }
        public int AmountOfPeople { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int TotalHours { get; set; }
        public virtual Place Place { get; set; }
        public virtual User User { get; set; }
    }
}
