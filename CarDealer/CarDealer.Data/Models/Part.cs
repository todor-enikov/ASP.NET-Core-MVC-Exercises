using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Data.Models
{
    public class Part
    {
        public Part()
        {
            this.Cars = new List<PartCar>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int Supplier_Id { get; set; }

        public Supplier Supplier { get; set; }

        public List<PartCar> Cars { get; set; }
    }
}
