using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace WorkflowConsoleApplication1
{

    public sealed class QJCodeActivity : CodeActivity
    {
        // 定义一个字符串类型的活动输入参数
        public OutArgument<int> day { get; set; }

        // 如果活动返回值，则从 CodeActivity<TResult>
        // 并从 Execute 方法返回该值。
        protected override void Execute(CodeActivityContext context)
        {
            // 获取 Text 输入参数的运行时值
            int days;
            string d = Console.ReadLine();
            int.TryParse(d, out days);
            context.SetValue(day, days);
        }
    }
}
