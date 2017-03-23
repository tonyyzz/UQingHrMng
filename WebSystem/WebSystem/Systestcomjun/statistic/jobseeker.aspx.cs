using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebSystem.Systestcomjun.statistic
{
    public partial class jobseeker : System.Web.UI.Page
    {
        ZhongLi.BLL.Person ps = new ZhongLi.BLL.Person();
        ZhongLi.BLL.Reward_Order ro = new ZhongLi.BLL.Reward_Order();
        public static string youke = "";
        public static string jianli = "";
        public static string orderscount = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            bind();
        }
        protected void bind()
        {
            DataTable dtyouke = ps.GetList(1000000000, "PerID not in (  select PerID  from Person_Education)and PerID not in (select PerID  from Person_ExpectWork)and PerID not in (select PerID  from Person_Skill)and PerID not in (select PerID  from Person_Project)  and RealName is not null or RealName=''", "RegTime").Tables[0];
            DataTable dtjianli = ps.GetList(1000000000, "PerID  in (  select PerID  from Person_Education)or PerID  in (select PerID  from Person_ExpectWork)or PerID  in (select PerID  from Person_Skill)or PerID  in (select PerID  from Person_Project)  and RealName is not null or RealName=''", "RegTime").Tables[0];
            DataTable orders = ro.GetList(1000000000, "OrderState>0", "CreateTime").Tables[0];

                youke = dtyouke.Rows.Count.ToString();
                jianli = dtjianli.Rows.Count.ToString();
                orderscount = orders.Rows.Count.ToString();

        }
    }
}