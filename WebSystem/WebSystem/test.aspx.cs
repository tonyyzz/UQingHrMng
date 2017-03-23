using cn.jpush.api.push.mode;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSystem.AppCode;
using WebSystem.Systestcomjun.AppCode;
using ZhongLi.Common;

namespace WebSystem
{
    public partial class test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IDictionary<string, DataTable> dict = new Dictionary<string, DataTable>();
            DataTable dt = new ZhongLi.BLL.News().GetList("").Tables[0];
            dt.Columns[0].ColumnName = "ID";
            dict.Add("order",dt);
            PublicMethod.DumpExcel(HttpContext.Current,"order",dict);
        }
    }
}