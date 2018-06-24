using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Services.Models
{
    public class CustomerByIdModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int BoughtCarsCount { get; set; }

        public decimal TotalSpentMoney { get; set; }
    }
}
