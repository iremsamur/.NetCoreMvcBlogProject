using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreDemo.Models
{
    public class UserSignInViewModel
    {
        [Required(ErrorMessage="Lütfen kullanıcı adınızı girin.")]
        public string username{ get; set; }
        [Required(ErrorMessage = "Lütfen şifrenizi girin.")]
        public string password { get; set; }
    }
}
