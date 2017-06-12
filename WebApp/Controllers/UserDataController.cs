using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Model;
using IBLL;
using BLL;
namespace WebApp.Controllers
{
    public class UserDataController : ApiController
    {
        // GET api/userdata
        public IEnumerable<UserInfo> Get()
        {
            IUserInfoService userInfoService = new UserInfoService();
            return userInfoService.LoadEntitie(p=>true);
        }

        // GET api/userdata/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/userdata
        public void Post([FromBody]string value)
        {
        }

        // PUT api/userdata/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/userdata/5
        public void Delete(int id)
        {
        }
    }
}
