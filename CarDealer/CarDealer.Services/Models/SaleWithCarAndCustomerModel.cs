using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Services.Models
{
    public class SaleWithCarAndCustomerModel
    {
        public CarModel Car { get; set; }

        public string CustomerName { get; set; }

        public decimal PriceOfSale { get; set; }

        public double Discount { get; set; }
    }
}
