using DAL;
using IDAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DALFactory
{
    //DBSession完成数据层和业务层的解耦
   public class DBSession: IDAL.IDBSession
    {
        //DbContext Db = new OAEntities();
        public DbContext dbContext
        {
            get { return DBContextFactory.CreateDbContext(); }//完成EF上下文创建
        }
        private IUserInfoDal _UserInfoDal;
        public IUserInfoDal UserInfoDal
        {
          get {
                if (_UserInfoDal == null)
                {
                    // _UserInfoDal = new UserInfoDal();//这里不直接用new，因为DBSession和数据层耦合
                    _UserInfoDal = DALAbstractFactory.CreateUserInfoDal();//通过抽象工厂将数据会话层与数据层解耦。
                }
                    return _UserInfoDal;
            }
            set
            {
                _UserInfoDal = value;
            }
        }
        /// <summary>
        /// 保存数据（连接一次数据库，完成所有操作，提高了操作数据的性能。）
        /// </summary>
        /// <returns></returns>
        public bool SaveChanges()
        {
            return dbContext.SaveChanges()>0;
        }
        /// <summary>
        /// 执行sql语句，Insert,update,delete
        /// </summary>
        /// <param name="strSql"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        public bool ExcuteSqlRow(string strSql,params SqlParameter[] pars)
        {
            return dbContext.Database.ExecuteSqlCommand(strSql, pars)>0;
        }
        /// <summary>
        /// 执行sql语句，select，返回list集合 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="strSql"></param>
        /// <param name="pars"></param>
        /// <returns></returns>
        public List<T> ExcuteQuery<T>(string strSql, params SqlParameter[] pars)
        {
            return dbContext.Database.SqlQuery<T>(strSql, pars).ToList();
        }
    }
}
