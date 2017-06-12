using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace RedisDemo
{
    public partial class Form1 : Form
    {
        SynchronizationContext m_SyncContext = null;
        public Form1()
        {
            InitializeComponent();
            m_SyncContext = SynchronizationContext.Current;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void ThreadProcSafePost()
        {
            //...执行线程任务

            //在线程中更新UI（通过UI线程同步上下文m_SyncContext）
            m_SyncContext.Post(SetTextSafePost, "This text was set safely by SynchronizationContext-Post.");

            //...执行线程其他任务
        }
        //第三步：定义更新UI控件的方法
        /// <summary>
        /// 更新文本框内容的方法
        /// </summary>
        /// <param name="text"></param>
        private void SetTextSafePost(object text)
        {
            this.textBox1.Text = text.ToString();
        }
    }
}
