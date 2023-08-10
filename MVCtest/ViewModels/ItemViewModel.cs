using MVCtest.Domain;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCtest.ViewModels
{
    public class ItemViewModel
    {
        public ulong Id { get; set; }

        [DisplayName("نام")]
        [Required]
        public string Name { get; set; }

        [DisplayName("فیلد اختیاری")]
        public int? field1 { get; set; }

        [DisplayName("کاربر")]
        public string? UserName { get; set; }

        public string? ImagePath { get; set; } = null;

        [DisplayName("تصویر")]
        public IFormFile? Image { get; set; }

        [DisplayName("شناسه کاربر")]
        public string? UserId { get; set; }

        [DisplayName("توضیحات")]
        public string Description { get; set; } = "";
    }
}
