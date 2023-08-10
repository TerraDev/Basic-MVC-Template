using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCtest.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [DisplayName("ایمیل")]
        public string Email { get; set; }

        [Required]
        [StringLength(12, ErrorMessage = "Must be between 5 and 12 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [DisplayName("رمز عبور")]
        public string Password { get; set; }

        [Required]
        [StringLength(12, ErrorMessage = "Must be between 5 and 12 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare(nameof(Password))]
        [DisplayName("تکرار رمز عبور")]
        public string ConfirmPassword { get; set; }
    }
}
