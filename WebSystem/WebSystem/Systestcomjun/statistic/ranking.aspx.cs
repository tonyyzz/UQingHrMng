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
    public partial class ranking : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            bind();
        }
        protected void bind()
        {
            DataTable dt = DbHelperSQL.ExecuteDataTable("select top 20 ro.SerUserID,count(ro.SerUserID)as counts,su.RealName ,su.Phone from  Reward_Order  ro join ServerUser su on ro.SerUserID=su.SerUserID and ro.SerUserID is not null and OrderState=3  group by  ro.SerUserID ,su.RealName,su.Phone order by counts desc", CommandType.Text);
            binding.DataSource = dt;
            binding.DataBind();
        }
    }
}