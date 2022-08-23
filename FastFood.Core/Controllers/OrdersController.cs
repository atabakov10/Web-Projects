﻿using System;
using System.Linq;
using AutoMapper;
using FastFood.Data;
using FastFood.Web.ViewModels.Orders;
using Microsoft.AspNetCore.Mvc;

namespace FastFood.Web.Controllers
{
    public class OrdersController : Controller
    {
        private readonly FastFoodContext context;
        private readonly IMapper mapper;

        public OrdersController(FastFoodContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public IActionResult Create()
        {
            var viewOrder = new CreateOrderViewModel
            {
                Items = context.Items.Select(x => x.Id).ToList(),
                Employees = context.Employees.Select(x => x.Id).ToList(),
            };

            return View(viewOrder);
        }

        [HttpPost]
        public IActionResult Create(CreateOrderInputModel model)
        {
            return RedirectToAction("All", "Orders");
        }

        public IActionResult All()
        {
            throw new NotImplementedException();
        }
    }
}