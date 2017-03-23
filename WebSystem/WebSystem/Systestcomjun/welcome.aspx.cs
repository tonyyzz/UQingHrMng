using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZhongLi.Common;

namespace WebSystem.Systestcomjun
{
    public partial class welcome : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //订单
            ltlorder.Text = new ZhongLi.BLL.Reward_Order().getAuthOrderCount() + "";
            //人才
            ltlperson.Text = new ZhongLi.BLL.Person().getAuthPersonCount()+"";
            //人才经纪人
            ltlseruser.Text = new ZhongLi.BLL.ServerUser().getSerUserAuthCount() + "";
            //提现
            ltltixian.Text = new ZhongLi.BLL.PresentApplication().GetRecordCount(" state=0 or state=1")+"";
        }
    }
}