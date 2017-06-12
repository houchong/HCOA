using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
namespace WebApp.Controllers
{
    public class UserApiController : Controller
    {
        //
        // GET: /UserApi/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ApiClient()
        {
            DateTime timeNow = DateTime.Now;
            //客户端对象的创建和初始化
            HttpClient client = new HttpClient();//这种调用WebApi支持跨域
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //执行get操作
            HttpResponseMessage response=client.GetAsync("http://localhost:60494/api/User").Result;
            if(response.IsSuccessStatusCode)
            {
                string responseJson = response.Content.ReadAsStringAsync().Result;
                List < Model.UserInfo > listUser= JsonConvert.DeserializeObject<List<Model.UserInfo>>(responseJson);
                ViewData.Model = listUser;
            }
            //var list = response.Content.ReadAsAsync<Model.UserInfo>().Result;
            //ViewData.Model = list;
            //ViewBag.data = response.Content.ReadAsStringAsync().Result;
            return View();
        }
    }
}
