using System;
using System.Collections.Generic;


namespace EventyApp.Models
{
    public partial class ReviewsMedium
    {
        public int Id { get; set; }
        public int ReviewId { get; set; }
        public string FilePath { get; set; }
        public string MimeType { get; set; }
        public virtual Review Review { get; set; }
    }
}
