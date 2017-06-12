using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using System.Data.Entity;

namespace mianshi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextQuestion tq = new TextQuestion();
            tq.title = "fdf";
            string s = "123";
            int si = s.ToInt();
            MessageBox.Show(si.GetType().ToString());
        }
        //public List<Product> GetActiveProducts(IQueryable<Product> query)
        //{
        //    return query.WhereNotDeleted().ToList();
        //}
        OAEntities oaEntities = new OAEntities();
        private void button2_Click(object sender, EventArgs e)
        {
            Product p = new Product();
            p.Validate2();
            IQueryable<UserDetail> iqUser = oaEntities.UserDetail.Where(u => true);
            IQueryable<Income> iqIncome = oaEntities.Income.Where(u => true);
            List<UserIncomeDto> listDto = GetUserIncomeDtos(iqUser, iqIncome);
        }
        public List<UserIncomeDto> GetUserIncomeDtos(IQueryable<UserDetail> users, IQueryable<Income> incomes)
        {
            //            var query = from user in users
            //                        join income in incomes on user.Id equals income.UserId
            //                        group income by
            //new { income.Month, income.Year, income.UserId, user.Name } into userincome
            //                        select new UserIncomeDto
            //                        {
            //                            Month = userincome.Key.Month,
            //                            Year = userincome.Key.Year,
            //                            Name = userincome.Key.Name,
            //                            Income = userincome.Sum(u => u.Amout)
            //                        };
            var query = from user in users
                        from income in incomes
                        where user.Id == income.UserId
                        group income by new { income.Month, income.Year, income.UserId, user.Name } into userincome
                        select new UserIncomeDto
                        {
                            Income = userincome.Sum(n => n.Amout),
                            Month = userincome.Key.Month,
                            Year = userincome.Key.Year,
                            Name = userincome.Key.Name
                        };

            return query.ToList();
        }
        delegate void TestDelegate(string s);
        void test(string s)
        {
            Console.Write(s);
        }
        private void button3_Click(object sender, EventArgs e)
        {
            TestDelegate testDelA = new TestDelegate(test);
            TestDelegate testDelB = delegate (string s) { Console.Write(s); };
            TestDelegate testDelC = x => { Console.Write(x); };
            testDelA("a");
            testDelB("b");
            testDelC("c");
        }
        Func<string,string> strFun = delegate (string s) { return "hello..." + s; };
        private void button4_Click(object sender, EventArgs e)
        {
           
            //Product p = new Product();
            //p.Name = "123";
            //MessageBox.Show(p.Validate2());
            //TimeHandler
        }
    }
}
