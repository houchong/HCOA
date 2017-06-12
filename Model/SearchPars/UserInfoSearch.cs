using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Model.SearchPars
{
    public class UserInfoSearch:SearchBase
    {
        public string UserName { get; set; }
        public string UserRemark { get; set; }
    }
}