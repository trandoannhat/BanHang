using BanHang.Data.EF;
using BanHang.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Utilities.Common;
using Utilities.Exceptions;
using ViewModels.Catalog.Menus;
using ViewModels.Common;

namespace Application.Catalog.Menus
{
    public class MenuService : IMenuService
    {
        private readonly BanHangDbContext _context;

        public MenuService(BanHangDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(MenuCreateRequest request)
        {
            var menu = new Menu()
            {
                Title = request.Title,
                Alias = Filter.GetSlug(request.Title),
                Description = request.Description,
                Position = 1,
                SeoTitle = request.SeoTitle,
                SeoDescription = request.SeoDescription,
                SeoKeyword = request.SeoKeyword,
                IsActive = true,
            };

            _context.Menus.Add(menu);
            await _context.SaveChangesAsync();
            return menu.Id;
        }

        public async Task<int> Delete(int id)
        {
            var menu = await _context.Menus.FindAsync(id);
            if (menu == null) throw new BanHangException($"Không tìm thấy menu có ID: {id} ");

            _context.Menus.Remove(menu);

            return await _context.SaveChangesAsync();
        }

        public async Task<List<MenuViewModel>> GetAll()
        {
            var query = from c in _context.Menus
                        select new { c };

            return await query.Select(x => new MenuViewModel()
            {
                Id = x.c.Id,
                Title = x.c.Title,
                Description = x.c.Description,
                Position = x.c.Position,
                SeoTitle = x.c.SeoTitle,
                SeoDescription = x.c.SeoDescription,
                SeoKeyword = x.c.SeoKeyword,
                IsActive = x.c.IsActive
            }).ToListAsync();
        }

        public async Task<PagedResult<MenuViewModel>> GetAllPaging(GetManageMenuPagingRequest request)
        {
            //1 Lọc dữ liệu và chọn thuộc tính cần thiết ngay từ đầu
            var query = _context.Menus.AsQueryable();

            // So sánh và tìm kiếm
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.Title.Contains(request.Keyword) || x.SeoKeyword.Contains(request.Keyword)
                    || x.SeoTitle.Contains(request.Keyword));
            }
            // Paging - phân trang
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new MenuViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                    Description = x.Description,
                    Position = x.Position,
                    SeoTitle = x.SeoTitle,
                    SeoDescription = x.SeoDescription,
                    SeoKeyword = x.SeoKeyword,
                    IsActive = x.IsActive
                })
                .ToListAsync();

            //4 Tạo đối tượng PagedResult ngay từ đầu
            var pagedResult = new PagedResult<MenuViewModel>
            {
                TotalRecords = totalRow,
                PageSize = request.PageSize,
                PageIndex = request.PageIndex,
                Items = data
            };

            return pagedResult;
        }

        public async Task<MenuViewModel> GetById(int id)
        {
            // Sử dụng trực tiếp FirstOrDefaultAsync trên bảng Menus
            var menu = await _context.Menus
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();

            // Kiểm tra xem menu có tồn tại không
            if (menu != null)
            {
                // Mapping từ Menu sang MenuViewModel
                return new MenuViewModel
                {
                    Id = menu.Id,
                    Title = menu.Title,
                    Description = menu.Description,
                    Position = menu.Position,
                    SeoTitle = menu.SeoTitle,
                    SeoDescription = menu.SeoDescription,
                    SeoKeyword = menu.SeoKeyword,
                    IsActive = menu.IsActive
                };
            }

            // Trả về null
            return null;
            //var query = from c in _context.Menus
            //            where c.Id == id
            //            select new { c };

            //return await query.Select(x => new MenuViewModel()
            //{
            //    Id = x.c.Id,
            //    Title = x.c.Title,
            //    Description = x.c.Description,
            //    Position = x.c.Position,
            //    SeoTitle = x.c.SeoTitle,
            //    SeoDescription = x.c.SeoDescription,
            //    SeoKeyword = x.c.SeoKeyword,
            //    IsActive = x.c.IsActive
            //}).FirstOrDefaultAsync();
        }

        public async Task<int> Update(MenuUpdateRequest request)
        {
            var menu = await _context.Menus.FindAsync(request.Id);

            if (menu == null)
            {
                throw new BanHangException($"Không tìm thấy menu có ID: {request.Id}");
            }

            // Update thuộc tính trực tiếp từ request
            menu.Title = request.Title;
            menu.Alias = Filter.GetSlug(request.Title);
            menu.Description = request.Description;
            menu.Position = request.Position;
            menu.SeoTitle = request.SeoTitle;
            menu.SeoDescription = request.SeoDescription;
            menu.SeoKeyword = request.SeoKeyword;
            menu.IsActive = request.IsActive;

            // Trả về số lượng bản ghi đã được thay đổi trong cơ sở dữ liệu
            return await _context.SaveChangesAsync();
        }
    }
}