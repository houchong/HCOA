using BLL;
using IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Model.SearchPars;

namespace WebApp.Controllers
{
    public class UserInfoController : Controller
    {
        //
        // GET: /UserInfo/
        public IUserInfoService userInfoService { get; set; }
        public ActionResult Index()
        {
            return View();
        }
        #region 获取用户信息
        public ActionResult GetUserInfo()
        {
            int pageIndex = int.Parse(Request["page"]);
            int pageSize = int.Parse(Request["rows"]);
            int totalCount = 0;
            string name = Request["name"];
            string remark = Request["remark"];
            UserInfoSearch userInfoSearch = new UserInfoSearch()
            {
                UserName = name,
                UserRemark = remark,
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalCount = totalCount
            };
            //short deleteType = (short)DeleteEnumType.Normal;
            //totalCount = userInfoService.LoadEntitie(c => true).Count();
            //var userInfoList = userInfoService.LoadPageEntities<string>(pageIndex, pageSize, out totalCount, c => c.DelFlag == deleteType, c => c.Sort, true);
            var userInfoList = userInfoService.LoadSearchEntities(userInfoSearch);
            var temp = from u in userInfoList select new { ID = u.ID, UName = u.UName, UPwd = u.UPwd, Remark = u.Remark, SubTime = u.SubTime, DelFlag = u.DelFlag, Sort = u.Sort };
            return Json(new { rows = temp, total = userInfoSearch.TotalCount }, JsonRequestBehavior.AllowGet);
        }
        #endregion
        #region 批量删除用户信息
        public ActionResult DeleteUserInfo()
        {
            string strId = Request["strId"];
            string[] strIds = strId.Split(',');
            List<int> list = new List<int>();
            foreach (var Id in strIds)
            {
                list.Add(int.Parse(Id));
            }
            if (userInfoService.DeleteEntities(list))
            {
                return Content("ok");
            }
            else
            {
                return Content("no");
            }

        }
        #endregion

        #region 添加用户信息
        public ActionResult AddUserInfo(UserInfo userinfo)
        {
            userinfo.SubTime = DateTime.Now;
            userinfo.ModifiedOn = DateTime.Now;
            userinfo.Sort = "0";
            userinfo.DelFlag = 0;
            userInfoService.AddEntity(userinfo);
            return Content("ok");
            //return View("Index");
        }
        #endregion
        #region 修改数据
        public ActionResult EditUserInfo(UserInfo userinfo)
        {
            userinfo.ModifiedOn = DateTime.Now;
            if (userInfoService.UpdateEntity(userinfo))
            {
                return Content("ok");
            }
            else
            {
                return Content("no");
            }
        }
        #endregion
        public ActionResult CalAdd()
        {
            return View();
        }
        public ActionResult AddNum(int cal1, int cal2)
        {
            int sum = cal1 + cal2;
            return Content(sum.ToString());
        }
        public ActionResult Test()
        {
            int a = 2;
            int b = 0;
            string c = (a / b).ToString();
            return Content(c);
        }
    }
}
