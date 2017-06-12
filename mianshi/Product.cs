using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace mianshi
{
    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public void Validate1()
        {
            if (string.IsNullOrEmpty(this.Name))
            {
                throw new Exception("please enter a name for the product");
            }
            if (string.IsNullOrEmpty(this.Description))
            {
                throw new Exception("product description is required");
            }
        }
        delegate string MyDelegate(string s);
        public string Validate2()
        {
            return this.Require(delegate(Product p) { return p.Name; }, "please enter a name for the product");
            //this.Require(x => x.Description, "product description is required");
        }
        private string Require(Func<Product, string> e, string validateStr)
        {
            MyDelegate myDeld1 =new MyDelegate(ReStr);
            MyDelegate myDele = delegate (string s) { return s; };
            if (string.IsNullOrEmpty(e(this)))
            {
                return validateStr;
            }
            return e(this);
        }
        private string ReStr(string s)
        {
            return s;
        }
    }
}
