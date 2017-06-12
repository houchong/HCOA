using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using IDAL;
using System.Reflection;

namespace DALFactory
{
    /// <summary>
    /// 抽象工厂，解决对象的创建问题（抽象工厂通过反射的方式创建类的实例）
    /// </summary>
   public class DALAbstractFactory
    {

        private static readonly string DalNameSpace = ConfigurationManager.AppSettings["DalNameSpace"];//获取命名空间.
        private static readonly string DalAssembly = ConfigurationManager.AppSettings["DalAssembly"];//程序集名称
        public static IUserInfoDal CreateUserInfoDal()
        {

            string fullClassName = DalNameSpace + ".UserInfoDal";//构建类的全名称
            return CreateInstance(fullClassName, DalAssembly) as IUserInfoDal;
        }
        private static object CreateInstance(string fullClassName,string assemblyPath)
        {
            var assembly = Assembly.Load(assemblyPath);//加载程序集
            return assembly.CreateInstance(fullClassName);
        }
    }
}
