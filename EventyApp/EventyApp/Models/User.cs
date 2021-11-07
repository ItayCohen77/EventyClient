using System;
using System.Collections.Generic;

namespace EventyApp.Models
{
    public partial class User
    {
        public User()
        {
            ChatBuyers = new List<Chat>();
            ChatSellers = new List<Chat>();
            Orders = new List<Order>();
            Places = new List<Place>();
            Receipts = new List<Receipt>();
            UserAuthTokens = new List<UserAuthToken>();
        }
    
        public int Id { get; set; }
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsAdmin { get; set; }
        public string ProfileImage { get; set; }

        public virtual List<Chat> ChatBuyers { get; set; }
        public virtual List<Chat> ChatSellers { get; set; }       
        public virtual List<Order> Orders { get; set; }        
        public virtual List<Place> Places { get; set; }       
        public virtual List<Receipt> Receipts { get; set; }        
        public virtual List<UserAuthToken> UserAuthTokens { get; set; }
    }
}
