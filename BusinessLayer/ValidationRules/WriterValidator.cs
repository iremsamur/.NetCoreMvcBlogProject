using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        //buraya writer için iş kuralları yazacağız.
        public WriterValidator()

        {
            //Validation'lar
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı soyadı alanı doldurulmalıdır!!");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail adresi alanı doldurulmalıdır!!");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre alanı doldurulmalıdır!!");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen en az 2 karakterlik veri girişi yapın!!");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakterlik veri girişi yapın!!");



        }
    }
}
