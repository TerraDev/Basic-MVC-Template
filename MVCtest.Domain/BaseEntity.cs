using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCtest.Domain
{
    public class BaseEntity
    {
        public string description { get; set; } = "";

        public DateTime createDate { get; set; } = DateTime.Now;

        public DateTime updateDate { get; set; }

        public bool isActive { get; set; } = true;

        public bool isDeleted { get; set; } = false;
    }
}
