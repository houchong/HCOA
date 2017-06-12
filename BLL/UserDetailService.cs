using DALFactory;
using IBLL;
using IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class UserDetailService : IUserDetailService
    {
        public IDBSession DbSession
        {
            get { return DBSessionFactory.CreateDbSession(); }
        }
        public bool AddRecord(string userName)
        {
            string strSql = "insert into UserDetail values(newid(),@userName)";
            return DbSession.ExcuteSqlRow(strSql, new System.Data.SqlClient.SqlParameter("@userName", userName));
        }


        List<IBLL.UserDetail> IUserDetailService.GetUserDetailList()
        {
            string strSql = "select * from UserDetail";
            return DbSession.ExcuteQuery<IBLL.UserDetail>(strSql);
        }
    }
}
