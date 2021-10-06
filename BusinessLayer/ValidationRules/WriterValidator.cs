using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        //buraya writer için iş kuralları yazacağız.
        public WriterValidator()

        {
            Regex regex = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[$@!%*?+#&'()[=\"€])[A-Za-z\\d$@!%*?+#&'()[=\"€']{8,}");
            //şifre en az 1 büyük harf,1 küçük harf , 1 rakam , 1 özel karakter ve 8 karakter oluşan bir şifre olmalıdır.
            //Validation'lar
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adı soyadı alanı doldurulmalıdır!!");
            RuleFor(x => x.WriterMail).NotEmpty().WithMessage("Mail adresi alanı doldurulmalıdır!!");
            RuleFor(x => x.WriterPassword).NotEmpty().WithMessage("Şifre alanı doldurulmalıdır!!");
            RuleFor(x => x.WriterPasswordAgain).NotEmpty().WithMessage("Tekrar şifre alanı doldurulmalıdır!!");
            RuleFor(x => x.WriterMail).EmailAddress().WithMessage("Mail adresi alanı doldurulmalıdır!!");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("Lütfen en az 2 karakterlik veri girişi yapın!!");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakterlik veri girişi yapın!!");
            RuleFor(x => x.WriterPassword).Matches(regex).WithMessage("Şifre en az bir küçük harf, bir büyük harf, 1 özel karakter ve 1 rakam içermelidir. Ve en az 8 karakter olmalıdır!!");




        }
    }
}
