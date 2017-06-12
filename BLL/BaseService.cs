using DALFactory;
using IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BLL
{
   public abstract  class BaseService<T>where T:class,new()
    {     
        public IDBSession DbSession
        {
            get { return DBSessionFactory.CreateDbSession(); }
        }
        public IDAL.IBaseDal<T> currentDal { get; set; }
        public abstract void SetCurrentDal();
        public BaseService()
        {
            SetCurrentDal();//子类必须实现该抽象方法。
        }
        //根据条件查询
        public IQueryable<T> LoadEntitie(System.Linq.Expressions.Expression<Func<T, bool>> wherelamda)
        {
            return this.currentDal.LoadEntitie(wherelamda);
        }
        /// <summary>
        /// 根据条件分页查询
        /// </summary>
        /// <typeparam name="s"></typeparam>
        /// <param name="pageIndex">页码</param>
        /// <param name="pageSize">记录数</param>
        /// <param name="totalCount">总条数</param>
        /// <param name="wherelamda">查询条件</param>
        /// <param name="orderbylamda">排序条件</param>
        /// <param name="isAsc">排序方式</param>
        /// <returns></returns>
        public IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, out int totalCount, System.Linq.Expressions.Expression<Func<T, bool>> wherelamda, System.Linq.Expressions.Expression<Func<T, s>> orderbylamda, bool isAsc)
        {
            return this.currentDal.LoadPageEntities<s>(pageIndex, pageSize, out totalCount, wherelamda, orderbylamda, isAsc);
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool DeleteEntity(T entity)
        {
            this.currentDal.DeleteEntity(entity);
            return this.DbSession.SaveChanges();
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool UpdateEntity(T entity)
        {
            this.currentDal.UpdateEntity(entity);
            return this.DbSession.SaveChanges();
        }
        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T AddEntity(T entity)
        {
            this.currentDal.AddEntity(entity);
            this.DbSession.SaveChanges();
            return entity;
        }
    }
}
