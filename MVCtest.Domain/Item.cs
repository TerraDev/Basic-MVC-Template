using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCtest.Domain
{
    public class Item : BaseEntity
    {
        [Key]
        public ulong Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int? field1 { get; set; }

        public string? UserId { get; set; }
        public AppUser? User { get; set; }

        public string? ImageName { get; set; }
    }
}
