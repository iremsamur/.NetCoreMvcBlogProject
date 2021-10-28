using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            //Blog için validator kuralları yazıyorum.
            RuleFor(x => x.BlogTitle).NotEmpty().WithMessage("Blog başlığı boş bırakılamaz!!!!");
            RuleFor(x => x.BlogContent).NotEmpty().WithMessage("Blog içeriği boş bırakılamaz!!!!");
            RuleFor(x => x.BlogImage).NotEmpty().WithMessage("Blog görseli boş bırakılamaz!!!!");
            RuleFor(x => x.BlogTitle).MaximumLength(150).WithMessage("Blog başlığı maksimum 150 karakter olabilir!!");
            RuleFor(x => x.BlogContent).MinimumLength(4).WithMessage("Blog içeriği minimum 4 karakter olabilir!!");


        }
    }
}
