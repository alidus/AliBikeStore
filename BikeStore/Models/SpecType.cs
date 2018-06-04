using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BikeStore.Models
{
    public class SpecType
    {
        public int SpecTypeID { get; set; }

        public string TypeName { get; set; }

        public List<Spec> Specs { get; set; }
    }
}