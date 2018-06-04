using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeStore.Models
{
    public class BikeBrand
    {
        public int BikeBrandID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual List<Bike> Bikes { get; set; }
    }
}