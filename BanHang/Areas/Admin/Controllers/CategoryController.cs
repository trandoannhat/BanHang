using BanHang.Models;
using BanHang.Models.EF;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BanHang.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly BanHangDbContext _context;

        public CategoryController(BanHangDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Category
        public ActionResult Index()
        {
            var cate = _context.Categories;
            return View(cate);
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Add(Category model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        model.CreatedDate = DateTime.Now;
        //        model.ModifiedDate = DateTime.Now;
        //        model.Alias = BanHang.Models.Common.Filter.GetSlug(model.Title);
        //        _context.Categories.Add(model);
        //        _context.SaveChanges();
        //        return RedirectToAction("Index", "Category");
        //    }
        //    return View(model);
        //}

        [TempData]
        public string StatusMessage { get; set; }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Category model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                model.ModifiedDate = DateTime.Now;
                model.Alias = BanHang.Models.Common.Filter.GetSlug(model.Title);
                var alias = await _context.Categories.FirstOrDefaultAsync(o => o.Alias == model.Alias);
                if (alias != null)
                {
                    ModelState.AddModelError("", $"Danh mục {model.Title}  đã tồn tại");

                    return View(model);
                }

                _context.Add(model);
                await _context.SaveChangesAsync();
                StatusMessage = "Thêm mới danh mục menu thành công";

                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var item = _context.Categories.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                _context.Categories.Attach(model);//cho phép sửa

                model.ModifiedDate = DateTime.Now;
                model.Alias = BanHang.Models.Common.Filter.FilterChar(model.Title);
                _context.Entry(model).Property(o => o.Title).IsModified = true;
                _context.Entry(model).Property(o => o.Description).IsModified = true;
                _context.Entry(model).Property(o => o.Alias).IsModified = true;
                _context.Entry(model).Property(o => o.SeoDescription).IsModified = true;
                _context.Entry(model).Property(o => o.SeoKeyword).IsModified = true;
                _context.Entry(model).Property(o => o.SeoTitle).IsModified = true;
                _context.Entry(model).Property(o => o.Position).IsModified = true;
                _context.Entry(model).Property(o => o.ModifiedDate).IsModified = true;
                _context.Entry(model).Property(o => o.ModifierBy).IsModified = true;

                _context.SaveChanges();
                return RedirectToAction("Index", "Category");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = _context.Categories.Find(id);
            if (item != null)
            {
                _context.Categories.Remove(item);
                _context.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}