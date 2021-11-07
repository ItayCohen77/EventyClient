using System;
using System.Collections.Generic;


namespace EventyApp.Models
{
    public partial class Chat
    {
        public Chat()
        {
            Messages = new List<Message>();
        }
        public int Id { get; set; }
        public int SellerId { get; set; }
        public int BuyerId { get; set; }
        public virtual User Buyer { get; set; }
        public virtual User Seller { get; set; }       
        public virtual List<Message> Messages { get; set; }
    }
}
