using System;
using System.Collections.Generic;

namespace EventyApp.Models
{
    public partial class OrderExtra
    {
        public OrderExtra()
        {
            Orders = new List<Order>();
        }

        public int Id { get; set; }
        public string ExtraType { get; set; }
        public int Price { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
