using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BanHang.Data.Entities
{
    public class Category : BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public string Description { get; set; }

        public string Icon { get; set; }
        public string SeoTitle { get; set; }
        public string SeoDescription { get; set; }
        public string SeoKeyword { get; set; }

        public List<Product> Products { get; set; }
    }
}