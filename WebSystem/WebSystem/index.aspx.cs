using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;


namespace WebSystem
{
    public partial class index : System.Web.UI.Page
    {
        ZhongLi.BLL.News NEW = new ZhongLi.BLL.News();
        ZhongLi.BLL.CareerPlanning CP = new ZhongLi.BLL.CareerPlanning();
        ZhongLi.BLL.JobTraining JO = new ZhongLi.BLL.JobTraining();
        ZhongLi.BLL.CooperativePartner cop = new ZhongLi.BLL.CooperativePartner();
        public static string log = null;
        public static string phone = null;
        public static string mail = null;
        public static string bjtu = null;
        public static string QRCode = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            bindhezuo();
            ZhongLi.Model.siteconfig config = new ZhongLi.Bll.siteconfig().loadConfig(Server.MapPath("/xmlconfig/site.config"));
        
            log = config.log;
            phone = config.phone;
            mail = config.mail;
            bjtu = config.bgtu;
            QRCode = config.QRCode;
            bindDujiaPost();
        }
        protected void bindhezuo()
        {
            DataTable dt = cop.GetList(10, "1=1", "ID desc").Tables[0];
            hezuo.DataSource = dt;
            hezuo.DataBind();
        }
        private void bindDujiaPost()
        {
            DataTable dt = new ZhongLi.BLL.ServerUser_Post().GetList(" IsSole=1 order by CreateTime desc").Tables[0];
            dujia.DataSource = dt;
            dujia.DataBind();
        }
    }
}