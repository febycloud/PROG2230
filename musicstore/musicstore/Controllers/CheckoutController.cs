﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using musicstore.Models;

namespace musicstore.Controllers
{
    public class CheckoutController : Controller
    {

        private readonly MvcMusicStoreContext _context;


        public CheckoutController(MvcMusicStoreContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AddressandPayment()
        {
            Order order = new Order();
                order.OrderDate = DateTime.Now;
            ViewBag.CountryCode = new SelectList(_context.Country.OrderBy(a => a.Name), "CountryCode", "Name");
            ViewBag.CountryCode = new SelectList(_context.Province.OrderBy(a => a.Name), "ProvinceCode", "Name");

            return View(order);
        }
    }
}