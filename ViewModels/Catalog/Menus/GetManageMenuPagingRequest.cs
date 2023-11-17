using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels.Common;

namespace ViewModels.Catalog.Menus
{
    public class GetManageMenuPagingRequest : PagingRequestBase
    {
        public string? Keyword { get; set; } = string.Empty;
    }
}