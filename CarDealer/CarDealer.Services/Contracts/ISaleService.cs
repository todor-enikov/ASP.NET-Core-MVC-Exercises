using CarDealer.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarDealer.Services.Contracts
{
    public interface ISaleService
    {
        IEnumerable<SaleModel> All(int page, int pageSize);

        SaleWithCarAndCustomerModel ById(int id);

        IEnumerable<SaleModel> Discounted();

        IEnumerable<SaleModel> DiscountedWithGivenPercent(double percent);

        int TotalSales();
    }
}
