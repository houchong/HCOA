using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Activities;

namespace WorkflowConsoleApplication1
{

    public sealed class leaveCodeActivity : CodeActivity
    {
        // 定义一个字符串类型的活动输入参数
        public InArgument<int> days { get; set; }
        public OutArgument<int> res { get; set; }
        // 如果活动返回值，则从 CodeActivity<TResult>
        // 并从 Execute 方法返回该值。
        protected override void Execute(CodeActivityContext context)
        {
            // 获取 Text 输入参数的运行时值
            int day = context.GetValue(days);
            if(day<3)
            {
                context.SetValue(res, 0);
            }
            else if(day<6)
            {
                context.SetValue(res, 1);
            }
            else
            {
                context.SetValue(res, 2);
            }

        }
    }
}
