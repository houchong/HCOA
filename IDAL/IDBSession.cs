using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IDBSession
    {
        IUserInfoDal UserInfoDal { get; set; }
        bool SaveChanges();
        bool ExcuteSqlRow(string strSql,params System.Data.SqlClient.SqlParameter[] pars);
        List<T> ExcuteQuery<T>(string strSql, params System.Data.SqlClient.SqlParameter[] pars);
    }
}
