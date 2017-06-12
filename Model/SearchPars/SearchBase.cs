using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.SearchPars
{
    public class SearchBase
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
    }
}