using Microsoft.AspNetCore.Mvc;
using OnlineStore.Data;
using OnlineStore.Services;
using OnlineStore.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineStore.Controllers
{
    public class AppController : Controller
    {
        private readonly IMailService _mailService;
        private readonly StoreContext _context;

        public StoreContext Context { get; }

        public AppController(IMailService mailService, StoreContext context)
        {
            _mailService = mailService;
            _context = context;
        }

        public IActionResult Index()
        {
            var results = _context.Products.ToList();
            return View();
        }

        [HttpGet("contact")]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost("contact")]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Send the email
                _mailService.SendMessage("andrew@gmail.com", model.Subject, $"From: {model.Name} - {model.Email}, Message: {model.Message}");
                ViewBag.UserMessage = "Mail Sent";
                ModelState.Clear();
            }
            //no else because the View shows the errors with asp-validation

            return View();
        }

        public IActionResult About()
        {
            ViewBag.Title = "About Us";
            return View();
        }

        public IActionResult Shop()
        {
            //var results = _context.Products.ToList()
            //    .OrderBy(p => p.Manufacturer);

            var results = from p in _context.Products
                          orderby p.Manufacturer
                          select p;

            return View(results.ToList());
        }
    }
}
