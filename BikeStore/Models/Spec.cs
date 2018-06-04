using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeStore.Models
{
    public class Spec
    {
        public int SpecID { get; set; }
        public int BikeID { get; set; }
        public int SpecTypeID { get; set; }
        public float Value { get; set; }

        public virtual SpecType SpecType { get; set; }
        public virtual Bike Bike { get; set; }
    }
}