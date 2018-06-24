using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Data.Models
{
    public class Sale
    {
        public int Id { get; set; }

        public double Discount { get; set; }

        public int Car_Id { get; set; }

        public Car Car { get; set; }

        public int Customer_Id { get; set; }

        public Customer Customer { get; set; }
    }
}
