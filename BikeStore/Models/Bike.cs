using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BikeStore.Models
{
    public class Bike
    {
        public int BikeID { get; set; }

        [DisplayName("Brand")]
        [Required]
        public int BikeBrandID { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Model name have to be 3-30 letters long")]
        public string Model { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public virtual BikeBrand BikeBrand { get; set; }

        public virtual List<Spec> Specs { get; set; }
    }
}