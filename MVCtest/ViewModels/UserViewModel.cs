using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCtest.ViewModels
{
    public class UserViewModel
    {
        public UserViewModel(string id)
        {
            this.userId = id;
        }

        public UserViewModel()
        {
        }

        public string? userId { get; set; }

        [Required]
        [DisplayName("نام کاربری")]
        public string userName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [DisplayName("ایمیل")]
        public string Email { get; set; }

        [DisplayName("آدرس")]
        public string Address { get; set; }

        [DisplayName("طول جغرافیایی")]
        public float Longitude { get; set; }

        [DisplayName("عرض جغرافیایی")]
        public float Latitude { get; set; }

        public List<string>? Roles { get; set; }
    }
}
