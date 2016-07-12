using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace day3MVCApp.Controllers
{
    public class OrderItemController : Controller
    {
        private day3MVCApp.Data.ApplicationDbContext _context;
        public OrderItemController(day3MVCApp.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var orderItems = _context.OrderItems.ToList();
            return View(orderItems);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(day3MVCApp.Data.OrderItem newOrderItem)
        {
            if (ModelState.IsValid)
            {
                _context.OrderItems.Add(newOrderItem);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(newOrderItem);
            }
        }

        public IActionResult Update(int id)
        {
            var orderItemToUpdate = _context.OrderItems.SingleOrDefault(x => x.Id == id);

            if (orderItemToUpdate == null)
            {
                return RedirectToAction("Index");
            }

            return View(orderItemToUpdate);
        }

        [HttpPost]
        public IActionResult Update(day3MVCApp.Data.OrderItem updatedOrderItem)
        {
            if (ModelState.IsValid)
            {
                _context.OrderItems.Update(updatedOrderItem);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            else
            {
                return View(updatedOrderItem);
            }
        }

        public IActionResult Delete(int id)
        {
            var orderItemToDelete = _context.OrderItems.SingleOrDefault(x => x.Id == id);

            if (orderItemToDelete != null)
            {
                _context.OrderItems.Remove(orderItemToDelete);
                _context.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}
