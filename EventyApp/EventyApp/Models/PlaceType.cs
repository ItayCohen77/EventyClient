using System;
using System.Collections.Generic;


namespace EventyApp.Models
{
    public partial class PlaceType
    {
        public PlaceType()
        {
            Places = new HashSet<Place>();
        }

        public int PlaceTypeId { get; set; }
        public string TypeName { get; set; }
        public virtual ICollection<Place> Places { get; set; }
    }
}
