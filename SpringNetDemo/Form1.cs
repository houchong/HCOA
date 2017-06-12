using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Spring.Context;
using Spring.Context.Support;
using ServiceStack.Redis;

namespace SpringNetDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnTake_Click(object sender, EventArgs e)
        {
            IApplicationContext ctx = ContextRegistry.GetContext();//创建容器
            IUserInfoService userInfoService = (IUserInfoService)ctx.GetObject("UserInfoService");
            MessageBox.Show(userInfoService.ShowMsg());
        }
        public static IRedisClientsManager clientManager = new PooledRedisClientManager(new string[] { "127.0.0.1:6379" });
        private void button1_Click(object sender, EventArgs e)
        {
            //var manager=new RedisManagerPool("");
            //var client = manager.GetClient();

        }
}
}
