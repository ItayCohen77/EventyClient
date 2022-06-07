using System;
using System.Collections.Generic;

namespace EventyApp.Models
{
    public class User
    {
        public User()
        {
            Orders = new List<Order>();
            Places = new List<Place>();
            LikedPlaces = new List<LikedPlace>();
        }
    
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsAdmin { get; set; }
        public string ProfileImage { get; set; }
        public virtual List<Order> Orders { get; set; }        
        public virtual List<Place> Places { get; set; }       
        public virtual List<LikedPlace> LikedPlaces { get; set; }
    }
}
