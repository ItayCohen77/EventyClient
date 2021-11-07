using System;
using System.Collections.Generic;


namespace EventyApp.Models
{
    public partial class Review
    {
        public Review()
        {
            ReviewsMedia = new List<ReviewsMedium>();
        }

        public int Id { get; set; }
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public virtual Order Order { get; set; }
        public virtual List<ReviewsMedium> ReviewsMedia { get; set; }
    }
}
