using DAL;
using IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALFactory
{
    //DBSession完成数据层和业务层的解耦
   public class DBSession
    {
        private IUserInfoDal _UserInfoDal;
        public IUserInfoDal UserInfoDal
        {
            get {
                if (_UserInfoDal == null)
                {
                    _UserInfoDal = new UserInfoDal();
                }
                    return _UserInfoDal;
            }
            set
            {
                _UserInfoDal = value;
            }
        }
    }
}
