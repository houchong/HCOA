using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public  class BaseDal<T>where T:class,new()
    {
        //OAEntities Db = new OAEntities();
        DbContext Db = DBContextFactory.CreateDbContext();//完成EF上下文的创建
        /// <summary>
        /// 基本查询
        /// </summary>
        /// <param name="wherelamda"></param>
        /// <returns></returns>
        public IQueryable<T> LoadEntitie(System.Linq.Expressions.Expression<Func<T, bool>> wherelamda)
        {
            return Db.Set<T>().Where<T>(wherelamda);
        }
        /// <summary>
        /// 分页方法
        /// </summary>
        /// <typeparam name="s"></typeparam>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="pageSize">每页显示的记录数</param>
        /// <param name="totalCount">总条数</param>
        /// <param name="wherelamda">查询条件</param>
        /// <param name="orderbylamda">排序条件</param>
        /// <param name="isAsc">排序方式</param>
        /// <returns></returns>
        public IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize, out int totalCount, System.Linq.Expressions.Expression<Func<T, bool>> wherelamda, System.Linq.Expressions.Expression<Func<T, s>> orderbylamda, bool isAsc)
        {
            var temp = Db.Set<T>().Where<T>(wherelamda);
            totalCount = temp.Count();
            if (isAsc)//如果是升序
            {
                temp = temp.OrderBy<T, s>(orderbylamda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            }
            else
            {
                temp = temp.OrderByDescending<T, s>(orderbylamda).Skip<T>((pageIndex - 1) * pageSize).Take<T>(pageSize);
            }
            return temp;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool DeleteEntity(T entity)
        {
            Db.Entry<T>(entity).State = System.Data.Entity.EntityState.Deleted;
            //return Db.SaveChanges() > 0;
            return true;
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool UpdateEntity(T entity)
        {
            Db.Entry<T>(entity).State = System.Data.Entity.EntityState.Modified;
            //return Db.SaveChanges() > 0;
            return true;
        }
        /// <summary>
        /// 增加
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T AddEntity(T entity)
        {
            Db.Set<T>().Add(entity);
           // Db.SaveChanges();
            return entity;
        }
    }
}
