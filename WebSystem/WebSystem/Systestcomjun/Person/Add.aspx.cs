using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSystem.AppCode;
using ZhongLi.Common;

namespace WebSystem.Systestcomjun.Person
{
    public partial class Add : System.Web.UI.Page
    {
        ZhongLi.BLL.Person bll = new ZhongLi.BLL.Person();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Utils.CheckRole("4"))
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('权限信息','没有权限！','/Systestcomjun/index.aspx',2)</script>");
                return;
            }
            if(!IsPostBack){
                if (Request.QueryString["PerID"] != null)
                {
                    ltlTitle.Text = "修改求职者信息";
                    int PerID = Convert.ToInt32(Request.QueryString["PerID"]);
                    ZhongLi.Model.Person person = bll.GetModel(PerID);
                    txtRealName.Text = person.RealName;
                    txtPhne.Text = person.Phne;
                    rbtSex.SelectedValue = person.Sex == true ? "1" : "2";
                    ddlEducation.SelectedValue = person.Education;
                    ddlWorkLife.SelectedValue = person.WorkLife;
                    txtBirth.Text = person.Birth;
                    txtEmail.Text = person.Email;
                    txtCity.Text = person.City;
                    //ltlFlag.Text = person.Flag == 0 ? "<span style='color:red;'>未认证<span>" : "<span style='color:green'>已认证</span>";
                    //if (person.AuthImg != "")
                    //{
                    //    imgAuthImg.ImageUrl = person.AuthImg;
                    //}
                    //else
                    //{

                    //}
                }
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            ZhongLi.Model.Person person = null;
            if (Request.QueryString["PerID"] != null)
            {
                person = bll.GetModel(Convert.ToInt32(Request.QueryString["PerID"]));
                person.RealName = txtRealName.Text;
                person.Phne = txtPhne.Text;
                person.Sex = rbtSex.SelectedValue == "1" ? true : false;
                person.Education = ddlEducation.SelectedValue;
                person.WorkLife = ddlWorkLife.SelectedValue;
                person.Birth = txtBirth.Text;
                person.Email = txtEmail.Text;
                person.City = txtCity.Text;
                if (bll.Update(person))
                {
                    webHelper.addLog("修改了求职者“" + person.RealName + "”");
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('编辑求职者','保存成功！','',1)</script>");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('编辑求职者','保存失败','',2);</script>");

                }
            }

                
        }
    }
}