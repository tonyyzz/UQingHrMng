using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZhongLi.Common;

namespace WebSystem.Systestcomjun.homepage
{
    public partial class indexconfigure : System.Web.UI.Page
    {
        public string imgformat = ""; 
        public static string  bjtu="";
        public static string ggtu = "";
        public static string lgo = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            ZhongLi.Model.siteconfig site = new ZhongLi.Bll.siteconfig().loadConfig(Server.MapPath("/xmlconfig/site.config"));
            imgformat = site.ImgFormat;
            if (!IsPostBack)
            {
                phone.Text = site.phone;
                mail.Text = site.mail;
                bjtu = site.bgtu;
                ggtu = site.QRCode;
                lgo = site.log;
                ggimg.ImageUrl = "../../" + site.QRCode;
                logimg.ImageUrl = "../../" + site.log;
                img_Photo.ImageUrl = "../../" + site.bgtu;
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            ZhongLi.Model.siteconfig site = new ZhongLi.Bll.siteconfig().loadConfig(Server.MapPath("/xmlconfig/site.config"));
            if (fileLogo.HasFile)
            {
                //if (fileLogo.PostedFile.ContentLength <= site.FileSize * 1024)
                //{
                    string fileExt = Utils.GetFileExt(fileLogo.FileName);
                    string newname = Guid.NewGuid() + "." + fileExt;
                    string filePath = Utils.GetMapPath("/img/") + newname;
                    fileLogo.SaveAs(filePath);
                    bjtu = "img/" + newname;
                    site.bgtu = bjtu;
                //}

            }
            if (lgofill.HasFile)
            {
                //if (lgofill.PostedFile.ContentLength <= site.FileSize * 1024)
                //{
                    string logfileExt = Utils.GetFileExt(lgofill.FileName);
                    string lognewname = Guid.NewGuid() + "." + logfileExt;
                    string logfilePath = Utils.GetMapPath("/img/") + lognewname;
                    lgofill.SaveAs(logfilePath);
                    lgo = "img/" + lognewname;
                    site.log = lgo;
                //}
            }
            if (ggfill.HasFile)
            {
                //if (ggfill.PostedFile.ContentLength <= site.FileSize * 1024)
                //{
                    string ggfileExt = Utils.GetFileExt(ggfill.FileName);
                    string ggnewname = Guid.NewGuid() + "." + ggfileExt;
                    string ggfilePath = Utils.GetMapPath("/img/") + ggnewname;
                    ggfill.SaveAs(ggfilePath);
                    ggtu = "img/" + ggnewname;
                    site.QRCode = ggtu;
                //}
            }

            site.phone = phone.Text;
            site.mail = mail.Text;

            ZhongLi.Model.siteconfig sites = new ZhongLi.Bll.siteconfig().saveConifg(site, Server.MapPath("/xmlconfig/site.config"));
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('首页设置','保存成功','',1)</script>");
        }
    }
}