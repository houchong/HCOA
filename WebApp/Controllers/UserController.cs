using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApp.Controllers
{
    public class User
    {
        public string UName { get; set; }
        public string Remark { get; set; }
    }
    public class UserController : ApiController
    {
        public IBLL.IUserInfoService userInfoService { get; set; }
        // GET api/user
        //使用Method=Get的方式请求url=api/user,则这个方法会被调用执行 查询所有信息

        //public IEnumerable<Model.UserInfo> Get()
        public List<Model.UserInfo> Get()
        {
            //List<User> userEnum = new List<Controllers.User>();
            //User user1 = new User() { UName = "hc1", Remark = "大帅哥1" };
            //userEnum.Add(user1);
            //User user2 = new User() { UName = "hc2", Remark = "大帅哥2" };
            //userEnum.Add(user2);
            //User user3 = new User() { UName = "hc3", Remark = "大帅哥3" };

            //userEnum.Add(user3);
            List<Model.UserInfo> listUserInfo = userInfoService.LoadEntitie(c => true).ToList();
            return listUserInfo;
        }
        // GET api/user/5
        //Method=Get查询单条信息
        public string Get(int id)
        { 
            return "value";
        }

        // POST api/user
        //增加操作，FromBody就是数据是从请求体拿出来的
        public void Post([FromBody]string value)
        {
        }

        // PUT api/user/5
        //修改 
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/user/5
        //删除操作
        public void Delete(int id)
        {
        }
        public string take()
        {
            return "helloworld";
        }
    }
}
