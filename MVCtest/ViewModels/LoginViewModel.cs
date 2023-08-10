using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCtest.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [DisplayName("نام کاربری")]
        public string userName { get; set; }

        [Required]
        [StringLength(12, ErrorMessage = "تعداد کاراکترها باید بین 5 و 12 باشد", MinimumLength = 5)]
        [DisplayName("رمز عبور")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
