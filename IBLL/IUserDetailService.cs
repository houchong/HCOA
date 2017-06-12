using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBLL
{
   public interface IUserDetailService
    {
        bool AddRecord(string userName);
        List<UserDetail> GetUserDetailList();
    }
}
