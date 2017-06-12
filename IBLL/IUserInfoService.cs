using Model;
using Model.SearchPars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
   public interface IUserInfoService:IBaseService<UserInfo>
   {
        bool DeleteEntities(List<int> list);
        /// <summary>
        /// 找回用户的密码
        /// </summary>
        /// <param name="userInfo"></param>
        void FindUserPwd(UserInfo userInfo);
        void SendMessage();
        IQueryable<UserInfo> LoadSearchEntities(UserInfoSearch userInfoSearch);
   }
}
