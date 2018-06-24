using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Data.Models
{
    public class Customer
    {
        public Customer()
        {
            this.Sales = new List<Sale>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public bool IsYoungDriver { get; set; }

        public List<Sale> Sales { get; set; }
    }
}
