using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Model
{
   public class MyExceptionHandler: HandleErrorAttribute
    {
        /// <summary>
        /// 控制器方法出现异常，会调用该方法捕捉
        /// </summary>
        /// <param name="filterContext"></param>
        /// 
        public static Queue<Exception> queueException = new Queue<Exception>();
        public override void OnException(ExceptionContext filterContext)
        {
            queueException.Enqueue(filterContext.Exception);//将异常入队
            filterContext.HttpContext.Response.Redirect("/error.html");
            base.OnException(filterContext);
        }
    }
}
