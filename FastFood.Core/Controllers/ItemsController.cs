﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using FastFood.Data;
using FastFood.Models;
using FastFood.Services.Interfaces;
using FastFood.Services.Models.Categories;
using FastFood.Services.Models.Items;
using FastFood.Web.ViewModels.Items;
using Microsoft.AspNetCore.Mvc;

namespace FastFood.Web.Controllers
{
    public class ItemsController : Controller
    {
        private readonly ICategoryService categoryService; 
        private readonly IMapper mapper;
        private readonly IItemService itemService;
        public ItemsController(IMapper mapper, ICategoryService categoryService, IItemService itemService)
        {
            this.mapper = mapper;
            this.categoryService = categoryService;
            this.itemService = itemService;
        }

        public async Task<IActionResult> Create()
        {
            ICollection<ListCategoryDTO> categories = await this.categoryService
                .GetAll();
            IList<CreateItemViewModel> itemVms = new List<CreateItemViewModel>();
            foreach (ListCategoryDTO cDto in categories)
            {
                itemVms.Add(this.mapper.Map<CreateItemViewModel>(cDto));
            }


            return this.View(itemVms);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateItemInputModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.RedirectToAction("Create", "Items");
            }

            bool categoryValid = await this.categoryService.ExistById(model.CategoryId);
            if (!categoryValid)
            {
                return this.RedirectToAction("Create", "Items");
            }

            CreateItemDto itemDto = this.mapper.Map<CreateItemDto>(model);
            await this.itemService.Add(itemDto);

            return this.RedirectToAction("All", "Items");
        }

        public async Task<IActionResult> All()
        {
            ICollection<ListItemDto> itemDtos = await this.itemService.GetAll();
            IList<ItemsAllViewModels> itemVms = new List<ItemsAllViewModels>();
            foreach (ListItemDto iDto in itemDtos)
            {
                itemVms.Add(this.mapper.Map<ItemsAllViewModels>(iDto));
            }

            return this.View(itemVms);
        }
    }
}
