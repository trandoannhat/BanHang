using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanHang.Data.Entities
{
    public class BaseEntity
    {
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? ModifierBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}