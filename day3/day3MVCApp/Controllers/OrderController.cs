using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace day3MVCApp.Controllers
{
    public class OrderController : Controller
    {
        // GET: /<controller>/
        private day3MVCApp.Data.ApplicationDbContext _context;
        
        public OrderController(day3MVCApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var orders = _context.Orders.ToList();
            return View(orders);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(day3MVCApp.Data.Order newOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Orders.Add(newOrder);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(newOrder);
            }
        }

        public IActionResult Update(int id)
        {
            var orderToUpdate = _context.Orders.SingleOrDefault(x => x.Id == id);

            if (orderToUpdate == null)
            {
                return RedirectToAction("Index");
            }

            return View(orderToUpdate);
        }

        [HttpPost]
        public IActionResult Update(day3MVCApp.Data.Order updatedOrder)
        {
            if (ModelState.IsValid)
            {
                _context.Orders.Update(updatedOrder);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(updatedOrder);
            }
        }

        public IActionResult Delete(int id)
        {
            var orderToDelete = _context.Orders.SingleOrDefault(x => x.Id == id);

            if (orderToDelete != null)
            {
                _context.Orders.Remove(orderToDelete);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
