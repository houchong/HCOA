using log4net;
using Model;
using Spring.Web.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace WebApp
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : SpringMvcApplication//System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            int ss = 1;
            ss++;
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            string fileLogPath = Server.MapPath("/log/"); 
            log4net.Config.XmlConfigurator.Configure();//读取log4net配置信息
            ThreadPool.QueueUserWorkItem(p => {
                while(true)//不断扫描日志队列
                {
                    if(MyExceptionHandler.queueException.Count()>0)//如果队列中有异常信息
                    {
                        Exception exception = MyExceptionHandler.queueException.Dequeue();//出队
                        if(exception!=null)
                        {
                            //string fileName = DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
                            //File.AppendAllText(fileLogPath + fileName, exception.ToString(), Encoding.Default);//忘文件中写异常信息
                            ILog log = LogManager.GetLogger("errorMsg");
                            log.Error(exception);//将异常信息写到磁盘上
                        }
                        else
                        {
                            Thread.Sleep(5000);
                        }
                    }
                    else
                    {
                        Thread.Sleep(5000);
                    }
                }
            }, fileLogPath);
        }
    }
}