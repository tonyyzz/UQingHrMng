using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSystem.AppCode;
using ZhongLi.Common;

namespace WebSystem.Systestcomjun.News
{
    public partial class Add : BasePage
    {
        ZhongLi.BLL.News bll = new ZhongLi.BLL.News();
        public string imgformat = ""; 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Utils.CheckRole("9"))
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('权限信息','没有权限！','/Systestcomjun/index.aspx',2)</script>");
                return;
            }
            if (!IsPostBack)
            {
                ZhongLi.Model.siteconfig site = new ZhongLi.Bll.siteconfig().loadConfig(Server.MapPath("/xmlconfig/site.config"));
                imgformat = site.ImgFormat;
                ddlNewsType.DataSource = new ZhongLi.BLL.NewsType().GetAllList();
                ddlNewsType.DataTextField = "Name";
                ddlNewsType.DataValueField = "NewsTypeID";
                ddlNewsType.DataBind();
                ltlTitle.Text = "新增内容";
                if (Request.QueryString["NewsID"] != null)
                {
                    int NewsID=Convert.ToInt32(Request.QueryString["NewsID"]);
                    ZhongLi.Model.News news=bll.GetModel(NewsID);
                    txtTitle.Text = news.Title;
                    if (news.ImgUrl != "")
                    {
                        img_Photo.ImageUrl = news.ImgUrl;
                    }
                    ddlNewsType.SelectedValue = news.NewsType + "";
                    ddlhot.SelectedValue = news.Hot == true ? "1" : "2";
                    txtAbsDes.Text = news.AbsDes;
                    txtNewsCon.Text = news.NewsCon;
                }
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            ZhongLi.Model.News news = null;
            if (Request.QueryString["NewsID"] != null)
            {
                news=bll.GetModel(Convert.ToInt32(Request.QueryString["NewsID"]));
            }
            else
            {
                news = new ZhongLi.Model.News();
                news.CreateTime = DateTime.Now;
                news.ImgUrl="";
            }
            news.Title = txtTitle.Text;
            news.NewsType = Convert.ToInt32(ddlNewsType.SelectedValue);
            ZhongLi.Model.siteconfig site = new ZhongLi.Bll.siteconfig().loadConfig(Server.MapPath("/xmlconfig/site.config"));
            if (fileImg.HasFile)
            {
                if (fileImg.PostedFile.ContentLength <= site.FileSize * 1024)
                {
                    string fileExt = Utils.GetFileExt(fileImg.FileName);
                    string newname = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "." + fileExt;
                    string filePath = Utils.GetMapPath("/upload/news/") + newname;
                    fileImg.SaveAs(filePath);
                    news.ImgUrl ="/upload/news/"+ newname;
                }
            }
            news.Hot = ddlhot.SelectedValue == "1" ? true : false;
            news.NewsCon = txtNewsCon.Text;
            news.AbsDes = txtAbsDes.Text;
            if (news.NewsID == 0)
            {
                if (bll.Add(news) > 0)
                {
                    webHelper.addLog("新添加了内容“" + news.Title + "”");
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('新增内容','保存成功！','',1)</script>");
                }
                else
                {
                    
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('新增内容','保存失败','',2)</script>");
                }
            }
            else
            {
                if (bll.Update(news))
                {
                    webHelper.addLog("修改了内容“" + news.Title + "”");
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('编辑内容','保存成功！','',1)</script>");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('编辑内容','保存失败','',2);</script>");
                }

            }

        }
    }
}