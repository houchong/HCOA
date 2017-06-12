using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Filters
{
    public class MyAuthorization:AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            //如果保留如下代码，则会运行.net framework 定义好的身份验证， 如果希望自定义身份验证，则删除以下代码
            // base.OnAuthorization(filterContext);
            filterContext.HttpContext.Response.Write("123");
        }
    }
}