﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealer.Data.Models;
using CarDealer.Services.Contracts;
using CarDealer.Web.Models.Part;
using Microsoft.AspNetCore.Mvc;

namespace CarDealer.Web.Controllers
{
    [Route("parts")]
    public class PartController : Controller
    {
        private readonly IPartService partService;

        public PartController(IPartService partService)
        {
            this.partService = partService;
        }

        [Route("add")]
        public IActionResult Add()
        {
            return View();
        }

        [Route("add")]
        [HttpPost]
        public IActionResult Add(PartViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var partToAdd = new Part()
            {
                Name = viewModel.Name,
                Price = viewModel.Price,
                Supplier = new Supplier()
                {
                    Name = viewModel.Supplier.Name,
                    IsImporter = viewModel.Supplier.IsImporter
                }
            };

            if (viewModel.Quantity == 0)
            {
                partToAdd.Quantity = 1;
            }
            else
            {
                partToAdd.Quantity = viewModel.Quantity;
            }

            this.partService.Add(partToAdd);

            return RedirectToAction(nameof(All));
        }

        [Route("all")]
        public IActionResult All()
            => View(this.partService.All());

    }
}