using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Services.Models
{
    public class CarsWithPartsModel : CarModel
    {
        public IEnumerable<PartModel> Parts { get; set; }
    }
}
