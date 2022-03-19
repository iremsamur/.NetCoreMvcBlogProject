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
    public class UserValidator : AbstractValidator<AppUser>
    {
        public UserValidator()

        {
            Regex regex = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[$@!%*?+#&'()[=\"€])[A-Za-z\\d$@!%*?+#&'()[=\"€']{8,}");
            //şifre en az 1 büyük harf,1 küçük harf , 1 rakam , 1 özel karakter ve 8 karakter oluşan bir şifre olmalıdır.
            //Validation'lar
            RuleFor(x => x.NameSurname).NotEmpty().WithMessage("Yazar adı soyadı alanı doldurulmalıdır!!");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Mail adresi alanı doldurulmalıdır!!");
            RuleFor(x => x.PasswordHash).NotEmpty().WithMessage("Şifre alanı doldurulmalıdır!!");
            RuleFor(x => x.PasswordAgain).NotEmpty().WithMessage("Tekrar şifre alanı doldurulmalıdır!!");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Mail adresi alanı doldurulmalıdır!!");
            RuleFor(x => x.NameSurname).MinimumLength(2).WithMessage("Lütfen en az 2 karakterlik veri girişi yapın!!");
            RuleFor(x => x.NameSurname).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakterlik veri girişi yapın!!");
            RuleFor(x => x.PasswordHash).Matches(regex).WithMessage("Şifre en az bir küçük harf, bir büyük harf, 1 özel karakter ve 1 rakam içermelidir. Ve en az 8 karakter olmalıdır!!");




        }
    }
}
