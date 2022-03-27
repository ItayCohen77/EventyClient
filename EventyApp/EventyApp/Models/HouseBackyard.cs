using System;
using System.Collections.Generic;


namespace EventyApp.Models
{

    public partial class HouseBackyard
    {
        public int Id { get; set; }
        public bool HasPool { get; set; }
        public bool HasBbq { get; set; }
        public bool HasHotub { get; set; }
        public bool HasTables { get; set; }
        public bool HasChairs { get; set; }
    }
}
