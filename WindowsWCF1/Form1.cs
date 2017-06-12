using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsWCF1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChannelFactory<IService1> channelFactory = new ChannelFactory<IService1>("Service1");//创建一个通信工厂，需要指定通信的接点
            IService1 channel = channelFactory.CreateChannel();//通过通信工厂创建通信信道
            int sum = channel.DoWork(3, 20);
            MessageBox.Show(sum.ToString());
        }
    }
}
