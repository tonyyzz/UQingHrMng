using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ZhongLi.Common;


namespace WebSystem
{
    public partial class neslist : System.Web.UI.Page
    {
        ZhongLi.BLL.News NEW = new ZhongLi.BLL.News();
        public static string log = null;
        public static string phone = null;
        public static string mail = null;
        public static string bjtu = null;
        public static string QRCode = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            BindNews();
            ZhongLi.Model.siteconfig config = new ZhongLi.Bll.siteconfig().loadConfig(Server.MapPath("/xmlconfig/site.config"));
            log = config.log;
            phone = config.phone;
            mail = config.mail;
            bjtu = config.bgtu;
            QRCode = config.QRCode;
        }
        protected void BindNews()
        {
            string where = " ";
            AspNetPager1.RecordCount = NEW.GetRecordCount(where);
            rptnews.DataSource = NEW.GetListByPage(where, "CreateTime desc", AspNetPager1.StartRecordIndex, AspNetPager1.EndRecordIndex);
            rptnews.DataBind();
            DataSet ds = NEW.GetList("hot=1");
            rptnewshot.DataSource = ds;
            rptnewshot.DataBind();
        }
        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            BindNews();
        }
    }
}