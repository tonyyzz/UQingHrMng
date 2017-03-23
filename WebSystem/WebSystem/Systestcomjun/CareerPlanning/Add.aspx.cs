using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSystem.AppCode;
using ZhongLi.Common;

namespace WebSystem.Systestcomjun.CareerPlanning
{
    public partial class Add : BasePage
    {
        ZhongLi.BLL.CareerPlanning bll = new ZhongLi.BLL.CareerPlanning();
        public string imgformat = ""; 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Utils.CheckRole("7"))
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('权限信息','没有权限！','/Systestcomjun/index.aspx',2)</script>");
                return;
            }
            if (!IsPostBack)
            {
                txtSort.Text = "20";
                ltlTitle.Text = "新增职场攻略";
                ZhongLi.Model.siteconfig site = new ZhongLi.Bll.siteconfig().loadConfig(Server.MapPath("/xmlconfig/site.config"));
                imgformat = site.ImgFormat;
                if (Request.QueryString["CPID"] != null)
                {
                    ltlTitle.Text = "修改职场攻略";
                    int CPID = Convert.ToInt32(Request.QueryString["CPID"]);
                    ZhongLi.Model.CareerPlanning cp = bll.GetModel(CPID);
                    rbtType.SelectedValue = cp.CPType;
                    txtCPTitle.Text = cp.CPTitle;
                    txtCPName.Text = cp.CPName;
                    txtPhone.Text = cp.Phone;
                    txtSort.Text = cp.Sort + "";
                    txtAbsDes.Text = cp.AbsDes;
                    txtCPDes.Text = cp.CPDes;
                    if (cp.ImgUrl != "")
                    {
                        img_Photo.ImageUrl = cp.ImgUrl;
                    }
                }
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            ZhongLi.Model.CareerPlanning cp = null;
            if (Request.QueryString["CPID"] != null)
            {
                cp = bll.GetModel(Convert.ToInt32(Request.QueryString["CPID"]));
            }
            else
            {
                cp = new ZhongLi.Model.CareerPlanning();
            }
            cp.CPTitle = txtCPTitle.Text;
            cp.CPName = txtCPName.Text;
            cp.Phone = txtPhone.Text;
            cp.CPType = rbtType.SelectedValue;
            cp.Sort = Convert.ToInt32(txtSort.Text);
            cp.AbsDes = txtAbsDes.Text;
            cp.CPDes = txtCPDes.Text;
            
            ZhongLi.Model.siteconfig site = new ZhongLi.Bll.siteconfig().loadConfig(Server.MapPath("/xmlconfig/site.config"));
            if (fileImg.HasFile)
            {
                if (fileImg.PostedFile.ContentLength <= site.FileSize * 1024)
                {
                    string fileExt = Utils.GetFileExt(fileImg.FileName);
                    string newname = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "." + fileExt;
                    string filePath = Utils.GetMapPath("/upload/news/") + newname;
                    fileImg.SaveAs(filePath);
                    cp.ImgUrl = "/upload/news/" + newname;
                }
            }
            if (cp.CPID == 0)
            {
                if (bll.Add(cp) > 0)
                {
                    webHelper.addLog("新添加了职场攻略“" + cp.CPTitle + "”");
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('新增职场攻略','保存成功！','',1)</script>");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('新增职场攻略','保存失败','',2)</script>");
                }
            }
            else
            {
                if (bll.Update(cp))
                {
                    webHelper.addLog("修改了职场攻略“" + cp.CPTitle + "”");
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('编辑职场攻略','保存成功！','',1)</script>");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('编辑职场攻略','保存失败','',2);</script>");
                }
            }
        }
    }
}