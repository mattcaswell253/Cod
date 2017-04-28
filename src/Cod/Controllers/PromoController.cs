using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cod.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Cod.Controllers
{
    [Authorize]
    public class PromoController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public PromoController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        public IActionResult Index()
        {
           
            return View(_db.Promos.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Promo promo)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            promo.User = currentUser;
            _db.Promos.Add(promo);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

      
        public IActionResult Edit(int id)
        {
            var thisPromo = _db.Promos.FirstOrDefault(promos => promos.PromoId == id);
            return View(thisPromo);
        }

        [HttpPost]
        public IActionResult Edit(Promo promo)
        {
            _db.Entry(promo).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var thisItem = _db.Promos.FirstOrDefault(promos=> promos.PromoId == id);
            return View(thisItem);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisItem = _db.Promos.FirstOrDefault(promos=> promos.PromoId == id);
            _db.Promos.Remove(thisItem);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
