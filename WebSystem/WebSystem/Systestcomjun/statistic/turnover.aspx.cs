using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZhongLi.DBUtility;
using System.Data;

namespace WebSystem.Systestcomjun.statistic
{
    public partial class turnover : System.Web.UI.Page
    {
        public static string jinri = "";
        public static string dangyue = "";
        public static string jidu = "";
        public static string niandu = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            bind();
        }
        protected void bind()
        {
            DataTable dtjinri = DbHelperSQL.ExecuteDataTable("select * from Reward_Order where OrderState=3 and datediff(day,AutoTime,getdate())=0 ", CommandType.Text);
            DataTable dtdangyue = DbHelperSQL.ExecuteDataTable("select * from Reward_Order where OrderState=3 and datediff(month,AutoTime,getdate())=0", CommandType.Text);
            DataTable dtjidu = DbHelperSQL.ExecuteDataTable("select * from Reward_Order where OrderState=3 and DATEPART(qq, AutoTime) = DATEPART(qq, GETDATE()) and DATEPART(yy, AutoTime) = DATEPART(yy, GETDATE())", CommandType.Text);
            DataTable dtniandu = DbHelperSQL.ExecuteDataTable("select * from Reward_Order where datediff(YEAR,AutoTime,getdate())=0 and OrderState=3", CommandType.Text);

                jinri = dtjinri.Rows.Count.ToString();
                dangyue = dtdangyue.Rows.Count.ToString();
                jidu = dtjidu.Rows.Count.ToString();
                niandu = dtniandu.Rows.Count.ToString();

        }
    }
}