using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSystem.AppCode;
using ZhongLi.Common;

namespace WebSystem.Systestcomjun.JobTraining
{
    public partial class Add : BasePage
    {
        ZhongLi.BLL.JobTraining bll = new ZhongLi.BLL.JobTraining();
        public string imgformat = ""; 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Utils.CheckRole("6"))
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('权限信息','没有权限！','/Systestcomjun/index.aspx',2)</script>");
                return;
            }
            if (!IsPostBack)
            {
                ZhongLi.Model.siteconfig site = new ZhongLi.Bll.siteconfig().loadConfig(Server.MapPath("/xmlconfig/site.config"));
                imgformat = site.ImgFormat;
                txtSort.Text = "20";
                ltlTitle.Text = "新增职位信息";
                if (Request.QueryString["JobTraID"] != null)
                {
                    ltlTitle.Text = "修改职位信息";
                    int JobTraID = Convert.ToInt32(Request.QueryString["JobTraID"]);
                    ZhongLi.Model.JobTraining jt = bll.GetModel(JobTraID);
                    rbtType.SelectedValue = jt.JobTraType;
                    txtJobTraTitle.Text = jt.JobTraTitle;
                    txtJobTraName.Text = jt.JobTraName;
                    txtPhone.Text = jt.Phone;
                    txtSort.Text = jt.Sort + "";
                    txtAbsDes.Text = jt.AbsDes;
                    txtJobTraDes.Text = jt.JobTraDes;
                    if (jt.Imgurl != "")
                    {
                        img_Photo.ImageUrl = jt.Imgurl;
                    }
                }
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
             ZhongLi.Model.JobTraining jt=null;
             if (Request.QueryString["JobTraID"] != null)
             {
                 jt = bll.GetModel(Convert.ToInt32(Request.QueryString["JobTraID"]));
             }
             else
             {
                 jt = new ZhongLi.Model.JobTraining();
             }
             jt.JobTraTitle = txtJobTraTitle.Text;
             jt.JobTraName = txtJobTraName.Text;
             jt.Phone = txtPhone.Text;
             jt.JobTraType = rbtType.SelectedValue; 
             jt.Sort = Convert.ToInt32(txtSort.Text);
             jt.AbsDes = txtAbsDes.Text;
             jt.JobTraDes = txtJobTraDes.Text;
             
             ZhongLi.Model.siteconfig site = new ZhongLi.Bll.siteconfig().loadConfig(Server.MapPath("/xmlconfig/site.config"));
             if (fileImg.HasFile)
             {
                 if (fileImg.PostedFile.ContentLength <= site.FileSize * 1024)
                 {
                     string fileExt = Utils.GetFileExt(fileImg.FileName);
                     string newname = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "." + fileExt;
                     string filePath = Utils.GetMapPath("/upload/news/") + newname;
                     fileImg.SaveAs(filePath);
                     jt.Imgurl = "/upload/news/" + newname;
                 }
             }
             if (jt.JobTraID == 0)
             {
                 if (bll.Add(jt) > 0)
                 {
                     webHelper.addLog("新添加了职位信息“" + jt.JobTraTitle + "”");
                     Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('新增职位信息','保存成功！','',1)</script>");
                 }
                 else
                 {
                     Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('新增职位信息','保存失败','',2)</script>");
                 }
             }
             else
             {
                 if (bll.Update(jt))
                 {
                     webHelper.addLog("修改了职位信息“" + jt.JobTraTitle + "”");
                     Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('编辑职位信息','保存成功！','',1)</script>");
                 }
                 else
                 {
                     Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('编辑职位信息','保存失败','',2);</script>");
                 }
             }
        }
    }
}