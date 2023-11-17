using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanHang.Data.Entities
{
    public class Subscribe
    {
        public int Id { get; set; }

        public string Email { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}