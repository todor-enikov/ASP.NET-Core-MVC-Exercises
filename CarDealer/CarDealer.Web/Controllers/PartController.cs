using System;
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
        private const int PageSize = 25;

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

        [Route("edit/{id}")]
        public IActionResult Edit(int id)
        {
            var partById = this.partService.ById(id);

            EditPartViewModel partViewModel = new EditPartViewModel()
            {
                Name = partById.Name,
                Price = partById.Price,
                Quantity = partById.Quantity
            };

            return View(partViewModel);
        }

        [Route("edit/{id}")]
        [HttpPost]
        public IActionResult Edit(EditPartViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var partToUpdate = new Part()
            {
                Id = viewModel.Id,
                Price = viewModel.Price,
                Quantity = viewModel.Quantity
            };

            this.partService.Edit(partToUpdate);

            return RedirectToAction(nameof(All));
        }

        [Route("confirm-delete/{id}")]
        public IActionResult ConfirmDelete(int id)
            => View(id);


        [Route("delete/{id}")]
        public IActionResult DeletePart(int id)
        {
            if (!ModelState.IsValid)
            {
                return View(id);
            }

            this.partService.Delete(id);

            return RedirectToAction(nameof(All));
        }

        [Route("all")]
        public IActionResult All(int page = 1)
        {
            var allParts = this.partService.All(page, PageSize);

            var allPartViewModel = new AllPartViewModel()
            {
                Parts = allParts,
                CurrentPage = page,
                TotalPages = (int)Math.Ceiling(this.partService.TotalParts() / (double)PageSize)
            };

            return View(allPartViewModel);
        }

    }
}