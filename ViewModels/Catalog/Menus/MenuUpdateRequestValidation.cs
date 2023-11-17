using FluentValidation;

namespace ViewModels.Catalog.Menus
{
    public class MenuUpdateRequestValidation : AbstractValidator<MenuCreateRequest>
    {
        public MenuUpdateRequestValidation()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Tên menu không được để trống")
                .MaximumLength(200).WithMessage("Tên menu không được vượt quá 300 kí tự");
        }
    }
}