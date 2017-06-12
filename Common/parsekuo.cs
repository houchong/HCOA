using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
  public static  class parsekuo
    {
        public static int ToInt(this string s)
        {
            int id;
            int.TryParse(s, out id);//这里当转换失败时返回的id为0
            return id;
        }
    }
}
