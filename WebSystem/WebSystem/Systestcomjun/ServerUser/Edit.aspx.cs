using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSystem.AppCode;
using ZhongLi.Common;

namespace WebSystem.Systestcomjun.ServerUser
{
    public partial class Edit : BasePage
    {
        ZhongLi.BLL.ServerUser bll = new ZhongLi.BLL.ServerUser();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Utils.CheckRole("5"))
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('权限信息','没有权限！','/Systestcomjun/index.aspx',2)</script>");
                return;
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["SerUserID"]!=null)
                {
                    int SerUserID = Convert.ToInt32(Request.QueryString["SerUserID"]);
                    ZhongLi.Model.ServerUser suser = bll.GetModel(SerUserID);
                    txtRealName.Text = suser.RealName;
                    txtPhne.Text = suser.Phone;
                    rbtSex.SelectedValue = suser.Sex == true ? "1" : "2";
                    txtTrade.Text = suser.Trade;
                    txtCompany.Text = suser.Company;
                    txtPosition.Text = suser.Position;
                    txtWorkCity.Text = suser.WorkCity;
                    txtEmail.Text = suser.Email;
                }
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["SerUserID"] != null)
            {
                ZhongLi.Model.ServerUser suser = bll.GetModel(Convert.ToInt32(Request.QueryString["SerUserID"]));
                suser.RealName= txtRealName.Text ;
                suser.Phone=txtPhne.Text ;
                suser.Sex = rbtSex.SelectedValue == "1" ? true : false;
                suser.Trade=txtTrade.Text;
                suser.Company=txtCompany.Text;
                suser.Position=txtPosition.Text;
                suser.WorkCity=txtWorkCity.Text;
                suser.Email=txtEmail.Text ;
                if (bll.Update(suser))
                {
                    webHelper.addLog("修改了职业介绍人“" + suser.RealName + "”");
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('编辑职业介绍人','保存成功！','',1)</script>");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('编辑职业介绍人','保存失败！','',2)</script>");
                }
            }
        }
    }
}