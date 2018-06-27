using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Services.Models
{
    public class EditCustomerByIdModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        public bool IsYoungDriver { get; set; }
    }
}
