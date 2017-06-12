using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace WorkflowConsoleApplication1
{

    public sealed class CodeActivity1 : CodeActivity
    {
        // 定义一个字符串类型的活动输入参数
        //public InArgument<string> Text { get; set; }
        public OutArgument<int> Money { get; set; }

        // 如果活动返回值，则从 CodeActivity<TResult>
        // 并从 Execute 方法返回该值。
        protected override void Execute(CodeActivityContext context)
        {
            // 获取 Text 输入参数的运行时值
            //string text = context.GetValue(this.Text);
            int money;
            string sm = Console.ReadLine();
            int.TryParse(sm,out money);
            context.SetValue(Money, money);
        }
    }
}
