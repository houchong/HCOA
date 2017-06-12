using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNetDemo
{
    class UserInfoService : IUserInfoService
    {
        public string Name { get; set; }
        public User User { get; set; }
        public string ShowMsg()
        {
            return "Hello World!"+Name+"年龄:"+User.Age;
        }
    }
}
