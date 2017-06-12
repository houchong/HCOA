using IBLL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.SearchPars;
using Model.Enum;
using System.Net.Mail;
using System.Net;

namespace BLL
{
    public class UserInfoService : BaseService<UserInfo>,IUserInfoService
    {
        #region 批量删除用户数据
        public bool DeleteEntities(List<int> list)
        {
            var userInfoList = this.DbSession.UserInfoDal.LoadEntitie(c => list.Contains(c.ID));
            if(userInfoList!=null)
            {
             foreach(var userInfo in userInfoList)
             {
                    this.DbSession.UserInfoDal.DeleteEntity(userInfo);
             }
              
            }
            return this.DbSession.SaveChanges();
        }
        #endregion
        #region 多条件搜索数据
        public IQueryable<UserInfo> LoadSearchEntities(UserInfoSearch userInfoSearch)
        {
            short deleteType = (short)DeleteEnumType.Normal;
            var temp = this.DbSession.UserInfoDal.LoadEntitie(c => c.DelFlag== deleteType);
            if(!string.IsNullOrEmpty(userInfoSearch.UserName))
            {
                temp = temp.Where<UserInfo>(u => u.UName.Contains(userInfoSearch.UserName));
            }
            if(!string.IsNullOrEmpty(userInfoSearch.UserRemark))
            {
                temp = temp.Where(u => u.Remark.Contains(userInfoSearch.UserRemark));
            }
            userInfoSearch.TotalCount = temp.Count();
            var tt= temp.OrderBy<UserInfo,string>(u=>u.Sort).Skip((userInfoSearch.PageIndex - 1) * userInfoSearch.PageSize).Take(userInfoSearch.PageSize); 
            return tt;
        }
        #endregion
        #region 找回密码
        public void FindUserPwd(UserInfo userInfo)
        {
            string newPwd = Guid.NewGuid().ToString().Substring(0, 8);
            //将产生的新密码加密以后替换用户的原来的旧密码.但是发送到用户邮箱中的密码必须是明文.
            userInfo.UPwd = newPwd;
            this.DbSession.UserInfoDal.UpdateEntity(userInfo);
            this.DbSession.SaveChanges();
            MailMessage mailMsg = new MailMessage();//两个类，别混了，要引入System.Net这个Assembly
            mailMsg.From = new MailAddress("wang_itcast@126.com", "王承伟");//源邮件地址 。发件人地址.
            mailMsg.To.Add(new MailAddress("wangchengwei324@126.com", "王承伟"));//目的邮件地址。可以有多个收件人
            mailMsg.Subject = "新的账户如下:";//发送邮件的标题 
            StringBuilder sb = new StringBuilder();
            sb.Append("你的新的账户如下:");
            sb.Append("用户名:" + userInfo.UName);
            sb.Append("密码:" + newPwd);
            mailMsg.Body = sb.ToString();//发送邮件的内容 
            SmtpClient client = new SmtpClient("smtp.126.com");//smtp.163.com，smtp.qq.com.发件人的SMTP服务器的地址.
            client.Credentials = new NetworkCredential("wang_itcast", "wangchengwei");//发件人邮箱的用户和密码.
            client.Send(mailMsg);//排队发送邮件.
        }
        #endregion
        #region 发送邮件
        public void SendMessage()
        {
            MailMessage mailMsg = new MailMessage();//两个类，别混了，要引入System.Net这个Assembly
            mailMsg.From = new MailAddress("houchongamo@163.com", "侯冲");//源邮件地址 。发件人地址.
            mailMsg.To.Add(new MailAddress("271604539@qq.com", "侯冲"));//目的邮件地址。可以有多个收件人
            mailMsg.Subject = "新的账户如下:";//发送邮件的标题 
            StringBuilder sb = new StringBuilder();
            sb.Append("你的新的账户如下:");
            sb.Append("用户名:hc" );
            sb.Append("密码:123");
            mailMsg.Body = sb.ToString();//发送邮件的内容 
            SmtpClient client = new SmtpClient("smtp.163.com");//smtp.163.com，smtp.qq.com.发件人的SMTP服务器的地址.
            client.Credentials = new NetworkCredential("houchongamo@163.com", "hou19881025chong");//发件人邮箱的用户和密码.
            client.Send(mailMsg);//排队发送邮件.
        }
        #endregion
        public override void SetCurrentDal()
        {
            currentDal = this.DbSession.UserInfoDal;
        }

    }
}
