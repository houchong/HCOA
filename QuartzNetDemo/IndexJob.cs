using BLL;
using IBLL;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuartzNetDemo
{
    public class IndexJob : IJob
    {
        IUserDetailService userDetailService = new UserDetailService();
        int i = 1;
        public void Execute(JobExecutionContext context)
        {

           List<IBLL.UserDetail> list= userDetailService.GetUserDetailList();
        }
    }
}
