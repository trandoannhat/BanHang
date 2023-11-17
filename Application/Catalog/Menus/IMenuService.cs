using ViewModels.Catalog.Menus;
using ViewModels.Common;

namespace Application.Catalog.Menus
{
    public interface IMenuService
    {
        Task<int> Create(MenuCreateRequest request);

        Task<int> Update(MenuUpdateRequest request);

        Task<int> Delete(int Id);

        Task<PagedResult<MenuViewModel>> GetAllPaging(GetManageMenuPagingRequest request);

        Task<MenuViewModel> GetById(int id);

        Task<List<MenuViewModel>> GetAll();
    }
}