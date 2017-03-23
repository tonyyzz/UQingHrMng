using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSystem.AppCode;
using ZhongLi.Common;
using ZhongLi.Model;

namespace WebSystem.Systestcomjun
{
    public partial class SysSet : BasePage
    {
        ZhongLi.Bll.siteconfig sitebll = new ZhongLi.Bll.siteconfig();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Utils.CheckRole("1"))
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('权限信息','没有权限！','/Systestcomjun/index.aspx',2)</script>");
                return;
            }
            if (!IsPostBack)
            {
                siteconfig site = sitebll.loadConfig(Server.MapPath("/xmlconfig/site.config"));
                txtFileSize.Text = site.FileSize + "";
                foreach (ListItem item in chkImgFormat.Items)
                {
                    if (site.ImgFormat.Contains(item.Text))
                    {
                        item.Selected = true;
                    }
                }
                txtOrderTime.Text = site.OrderTime + "";
                txtSetOrderTime.Text = site.SetOrderTime + "";
               
                txtCommission.Text = site.Commission+"";
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            siteconfig site = sitebll.loadConfig(Server.MapPath("/xmlconfig/site.config"));
            site.FileSize=Convert.ToInt32(txtFileSize.Text) ;
            var imgformat = "";
            foreach (ListItem item in chkImgFormat.Items)
            {
                if (item.Selected)
                {
                    imgformat += item.Text + "," ;
                }
            }
            imgformat = imgformat.TrimEnd(',');
            site.ImgFormat = imgformat;
            site.OrderTime =Convert.ToInt32(txtOrderTime.Text);
            site.SetOrderTime=Convert.ToInt32(txtSetOrderTime.Text);
            site.Commission = Convert.ToInt32(txtCommission.Text);
            new ZhongLi.BLL.Reward_Order().SetOrderTime(site.OrderTime,site.SetOrderTime);
            sitebll.saveConifg(site, Server.MapPath("/xmlconfig/site.config"));
            webHelper.addLog("修改了“系统管理”的配置信息");
            Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('系统设置','保存成功','',1)</script>");
        }
    }
}