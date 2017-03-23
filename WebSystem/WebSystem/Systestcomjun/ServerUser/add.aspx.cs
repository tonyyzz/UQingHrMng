using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZhongLi.Common;

namespace WebSystem.Systestcomjun.ServerUser
{
    public partial class add : System.Web.UI.Page
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
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            ZhongLi.Model.ServerUser suser = new ZhongLi.Model.ServerUser();
            suser.RealName= txtRealName.Text ;
            suser.Password = DESEncrypt.GetStringMD5(txtPwd.Text);
            suser.Phone=txtPhne.Text ;
            suser.Sex = rbtSex.SelectedValue == "1" ? true : false;
            suser.Trade=txtTrade.Text;
            suser.Company=txtCompany.Text;
            suser.Position=txtPosition.Text;
            suser.WorkCity=txtWorkCity.Text;
            suser.Email=txtEmail.Text ;
            suser.Flag = 0;
            suser.RegTime = DateTime.Now;
            suser.Balance = 0;
            if (bll.Add(suser)>0)
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('添加职业介绍人','保存成功！','',1)</script>");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('添加职业介绍人','保存失败！','',2)</script>");
            }
        }
    }
}