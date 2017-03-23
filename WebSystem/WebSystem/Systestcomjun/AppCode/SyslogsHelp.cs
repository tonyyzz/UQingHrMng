using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using ZhongLi.Common;
using System.Text;
using System.Data;
namespace WebSystem.Systestcomjun.AppCode
{
    public class SyslogsHelp
    {
        public static int AddLogs(string Remark)
        {

            ZhongLi.Bll.sys_Logs manager = new ZhongLi.Bll.sys_Logs();
            int result = 0;
            ZhongLi.Model.sys_Logs syslogs = new ZhongLi.Model.sys_Logs();
            syslogs.UserID = Convert.ToInt32(Utils.GetCookie("AdminID"));
            syslogs.Remark = Remark;
            syslogs.IpAddress = DTRequest.GetIP();
            syslogs.AddTime = DateTime.Now.ToString();
            if (manager.Add(syslogs) > 0)
            {
                result = 1;
            }
            return result;
        }




        

    }
}