using CarDealer.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Web.Models.Car
{
    public class AllCarsWithPartsViewModel
    {
        public IEnumerable<CarsWithPartsModel> Cars { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }

        public int NextPage => this.CurrentPage == this.TotalPages ? this.TotalPages : this.CurrentPage + 1;

        public int PreviousPage => this.CurrentPage == 1 ? 1 : this.CurrentPage - 1;
    }
}
