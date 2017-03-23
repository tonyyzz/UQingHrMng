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
    public partial class broker : System.Web.UI.Page
    {
        public static string youke = "";
        public static string wanzheng = "";
        public static string chengjiao = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            bind();
        }
        protected void bind()
        {
            DataTable dtyoule = DbHelperSQL.ExecuteDataTable("select SerUserID from ServerUser where SerUserID not in (select SerUserID from ServerUser_Education)", CommandType.Text);
            DataTable dtwanzheng = DbHelperSQL.ExecuteDataTable("select * from ServerUser where SerUserID in (select SerUserID from ServerUser_Work where SerUserID in (select SerUserID from ServerUser_Post))", CommandType.Text);
            DataTable dtchengjiao = DbHelperSQL.ExecuteDataTable("select * from ServerUser where SerUserID in(select SerUserID from Reward_Order)", CommandType.Text);

                youke = dtyoule.Rows.Count.ToString();
                wanzheng = dtwanzheng.Rows.Count.ToString();
                chengjiao = dtchengjiao.Rows.Count.ToString();

        }
    }
}