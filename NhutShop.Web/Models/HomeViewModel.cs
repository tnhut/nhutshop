using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NhutShop.Web.Models
{
    public class HomeViewModel
    {
        public IEnumerable<SlideViewModel> Slides { set; get; }
        public IEnumerable<ProductViewModel> LastesProducts { set; get; }
        public IEnumerable<ProductViewModel> TopSalesProducts { set; get; }

    }
}