using BanHang.Models;
using BanHang.Models.EF;
using Microsoft.AspNetCore.Mvc;

namespace BanHang.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class NewsController : Controller
    {
        private readonly BanHangDbContext _context;

        public NewsController(BanHangDbContext context)
        {
            _context = context;
        }

        // GET: Admin/News
        public ActionResult Index()
        {
            var items = _context.News.OrderByDescending(o => o.Id).ToList();
            return View(items);
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(News model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                model.ModifiedDate = DateTime.Now;
                model.CategoryID = 12;
                model.Alias = BanHang.Models.Common.Filter.GetSlug(model.Title);
                _context.News.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index", "News");
            }
            return View(model);
        }

        public ActionResult Edit(int? id)
        {
            var item = _context.News.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(News model)
        {
            //if (ModelState.IsValid)
            //{
            //    model.ModifiedDate = DateTime.Now;
            //    model.Alias = BanHang.Models.Common.Filter.GetSlug(model.Title);
            //    _context.News.Attach(model);
            //    _context.Entry(model).State = System.Data.Entity.EntityState.Modified;
            //    _context.SaveChanges();
            //    return RedirectToAction("Index", "News");
            //}
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = _context.News.Find(id);
            if (item != null)
            {
                _context.News.Remove(item);
                _context.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public ActionResult IsActive(int id)
        {
            var item = _context.News.Find(id);
            if (item != null)
            {
                item.IsActive = !item.IsActive;
                //_context.Entry(item).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
                return Json(new { success = true, Active = item.IsActive });
            }
            return Json(new { success = false });
        }

        //các bước gắn ckeidtor
        //1. tải bộ plugin và cho vào project
        //2. kéo các file js vào layout
        //3. thay đổi input thành area và đặt id cho input đó
    }
}