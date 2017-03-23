using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace WebSystem
{
    public partial class newsdetai : System.Web.UI.Page
    {
        ZhongLi.BLL.News NEW = new ZhongLi.BLL.News();
        ZhongLi.Model.News NEWM = new ZhongLi.Model.News();

        ZhongLi.BLL.JobTraining jo = new ZhongLi.BLL.JobTraining();
        ZhongLi.Model.JobTraining jom = new ZhongLi.Model.JobTraining();

        ZhongLi.BLL.CareerPlanning cp = new ZhongLi.BLL.CareerPlanning();
        ZhongLi.Model.CareerPlanning cpm = new ZhongLi.Model.CareerPlanning();
        public static string log = null;
        public static string phone = null;
        public static string mail = null;
        public static string bjtu = null;
        public static string QRCode = null;
        public static string count;
        public static string time;
        public static string title;
        protected void Page_Load(object sender, EventArgs e)
        {
            BindNews();
            string type = Request["type"];
            string id = Request["id"];
            switch (type)
            { 
                case "news":
                    NEWM = NEW.GetModel(Convert.ToInt32(id));
                    title = NEWM.Title;
                    count = NEWM.NewsCon;
                    time ="发表时间："+ NEWM.CreateTime.ToString();
                    break;
                case "jo":
                    jom = jo.GetModel(Convert.ToInt32(id));
                    title = jom.JobTraTitle;
                    count = jom.JobTraDes;
                    time = "";
                    break;
                case "cp":
                    cpm = cp.GetModel(Convert.ToInt32(id));
                    title = cpm.CPTitle;
                    count = cpm.CPDes;
                    time = "发表时间：" + cpm.CreateTime.ToString();
                    break;
            }
            ZhongLi.Model.siteconfig config = new ZhongLi.Bll.siteconfig().loadConfig(Server.MapPath("/xmlconfig/site.config"));
            log = config.log;
            phone = config.phone;
            mail = config.mail;
            bjtu = config.bgtu;
            QRCode = config.QRCode;
            
        }
        protected void BindNews()
        {
            DataSet ds = NEW.GetList(10, "hot=1", "CreateTime desc");
            rptnews.DataSource = ds;
            rptnews.DataBind();
        }
    }
}