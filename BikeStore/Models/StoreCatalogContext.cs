using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BikeStore.Models
{
    public class StoreCatalogContext : DbContext
    {
        public DbSet<Bike> bikes { get; set; }
        public DbSet<BikeBrand> brands { get; set; }
        public DbSet<Spec> specs { get; set; }
        public DbSet<SpecType> specTypes { get; set; }

        public StoreCatalogContext() : base("BikeStoreDb")
        {

        }
    }
}