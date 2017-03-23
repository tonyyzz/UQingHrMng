using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ZhongLi.DBUtility;

namespace WebSystem.Systestcomjun.statistic
{
    public partial class Completiondegree : System.Web.UI.Page
    {
        ZhongLi.BLL.Person ps = new ZhongLi.BLL.Person();
        public static string ershi = "";
        public static string wushi = "";
        public static string bashi = "";
        public static string yibai = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            bind();
        }
        protected void bind()
        {
            DataTable dtershi = DbHelperSQL.ExecuteDataTable("select * from Person where PerID  not in (select PerID from Person_Education) and PerID  not in (select PerID from Person_ExpectWork)and PerID  not in (select PerID from Person_Skill)  and PerID  not in (select PerID from Person_Project)  ", CommandType.Text);
            DataTable dtwushi = DbHelperSQL.ExecuteDataTable("select * from Person where PerID   in (select PerID from Person_Education) ", CommandType.Text);
            DataTable dtbashi = DbHelperSQL.ExecuteDataTable("select * from Person where PerID  in (select PerID from Person_Work where PerID  in (select PerID from Person_Education) )", CommandType.Text);
            DataTable dtyibai = DbHelperSQL.ExecuteDataTable("select PerID from Person where PerID  in (select PerID from Person_Skill where PerID in (select PerID from Person_Education) and PerID in (select PerID from Person_Work) ) ", CommandType.Text);

            ershi = dtershi.Rows.Count.ToString();
            wushi = dtwushi.Rows.Count.ToString();
            bashi = dtbashi.Rows.Count.ToString();
            yibai = dtyibai.Rows.Count.ToString();
        }

    }
}