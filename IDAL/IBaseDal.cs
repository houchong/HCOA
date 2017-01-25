using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace IDAL
{
   public interface IBaseDal<T>where  T:class, new()
    {
        IQueryable<T> LoadEntitie(System.Linq.Expressions.Expression<Func<T, bool>> wherelamda);
        IQueryable<T> LoadPageEntities<s>(int pageIndex, int pageSize,out int totalCount,System.Linq.Expressions.Expression<Func<T, bool>> wherelamda
            , System.Linq.Expressions.Expression<Func<T, s>> orderbylamda, bool isAsc);
        bool DeleteEntity(T entity);
        bool UpdateEntity(T entity);
        T AddEntity(T entity);
    }
}
