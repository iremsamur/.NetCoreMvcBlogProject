using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori adı boş bırakılamaz!!!!");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Kategori tanımı boş bırakılamaz!!!!");
            RuleFor(x => x.CategoryName).MaximumLength(50).WithMessage("Kategori adı maksimum 50 karakter olmalıdır!");
            RuleFor(x => x.CategoryName).MinimumLength(2).WithMessage("Kategori adı minimum 2 karakter olmalıdır!");


        }
    }
}
