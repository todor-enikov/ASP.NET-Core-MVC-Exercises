using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Data.Models
{
    public class Car
    {
        public Car()
        {
            this.Sales = new List<Sale>();
            this.Parts = new List<PartCar>();
        }

        public int Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public long TravelledDistance { get; set; }

        public List<Sale> Sales { get; set; }

        public List<PartCar> Parts { get; set; }
    }
}
