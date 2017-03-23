using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSystem.AppCode;
using ZhongLi.Common;

namespace WebSystem.Systestcomjun.CooperativePartner
{
    public partial class add : System.Web.UI.Page
    {
        ZhongLi.BLL.CooperativePartner bll = new ZhongLi.BLL.CooperativePartner();
        public string imgformat = ""; 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Utils.CheckRole("14"))
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('权限信息','没有权限！','/Systestcomjun/index.aspx',2)</script>");
                return;
            }

            if (!IsPostBack)
            {
                ZhongLi.Model.siteconfig site = new ZhongLi.Bll.siteconfig().loadConfig(Server.MapPath("/xmlconfig/site.config"));
                imgformat = site.ImgFormat;
                ltlTitle.Text = "新增内容";
                if (Request.QueryString["ID"] != null)
                {
                    int ID = Convert.ToInt32(Request.QueryString["ID"]);
                    ZhongLi.Model.CooperativePartner CP = bll.GetModel(ID);
                    txtName.Text = CP.Name;
                    if (CP.Logo != "")
                    {
                        img_Photo.ImageUrl = CP.Logo;
                    }
                    Sort.Text = CP.Sort.ToString() ;
                    LinkUrl.Text = CP.LinkUrl;
                }
            }
        }
        protected void btnsave_Click(object sender, EventArgs e)
        {
            ZhongLi.Model.CooperativePartner cp = null;
            if (Request.QueryString["ID"] != null)
            {
                cp = bll.GetModel(Convert.ToInt32(Request.QueryString["ID"]));
            }
            else
            {
                cp = new ZhongLi.Model.CooperativePartner();
                cp.CreateDate = DateTime.Now;
                cp.Logo = "";
            }
            cp.Name = txtName.Text;
            ZhongLi.Model.siteconfig site = new ZhongLi.Bll.siteconfig().loadConfig(Server.MapPath("/xmlconfig/site.config"));
            if (fileLogo.HasFile)
            {
                if (fileLogo.PostedFile.ContentLength <= site.FileSize * 1024)
                {
                    string fileExt = Utils.GetFileExt(fileLogo.FileName);
                    string newname = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "." + fileExt;
                    string filePath = Utils.GetMapPath("/upload/CooperativePartner/") + newname;
                    fileLogo.SaveAs(filePath);
                    cp.Logo = "/upload/CooperativePartner/" + newname;
                }
            }
            cp.Sort = Convert.ToInt32(Sort.Text);
            cp.LinkUrl = LinkUrl.Text;
            if (cp.ID == 0)
            {
                if (bll.Add(cp) > 0)
                {
                    webHelper.addLog("新添加了合作伙伴“" + cp.Name + "”");
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('合作伙伴','保存成功！','',1)</script>");
                }
                else
                {

                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('合作伙伴','保存失败','',2)</script>");
                }
            }
            else
            {
                if (bll.Update(cp))
                {
                    webHelper.addLog("修改了内容“" + cp.Name + "”");
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('合作伙伴','保存成功！','',1)</script>");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('合作伙伴','保存失败','',2);</script>");
                }

            }
        }
    }
}