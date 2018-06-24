using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Services.Models
{
    public class SaleModel
    {
        public int Id { get; set; }

        public int CarId { get; set; }

        public int CustomerId { get; set; }

        public double Discount { get; set; }
    }
}
