using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebSystem
{
    public partial class post : System.Web.UI.Page
    {
        public string title = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["p"] != null)
            {
                int PostID = Convert.ToInt32(Request.QueryString["p"]);
                ZhongLi.Model.ServerUser_Post post = new ZhongLi.BLL.ServerUser_Post().GetModel(PostID);
                ltlPostName.Text = post.PostName;
                title = post.PostName;
                ltlSalary.Text = post.Salary == "" ? "面议" : post.Salary;
                ltlWorkAddress.Text = post.WorkAdress;
                ltlTrade.Text = post.Trade;
                ltlOtherPoint.Text = post.OtherPoint == "" ? "待完善职位诱惑" : post.OtherPoint;
                ltlPostDuty.Text = post.PostDuty == "" ? "待完善岗位职责" : post.PostDuty;
                ltlCompany.Text = post.Company == "" ? "公司名称" : post.Company;
                ltlNature.Text = post.Nature == "" ? "公司性质" : post.Nature;
                ltlScale.Text = post.Scale == "" ? "公司规模" : post.Scale;
                ltlAddress.Text = post.Address == "" ? "待完善公司详细地址信息" : post.Address;
                ltlDevelopProspect.Text = post.DevelopProspect == "" ? "待完善公司简介" : post.DevelopProspect;
                ltlCompanyMatching.Text = post.CompanyMatching == "" ? "待完善配套环境" : post.CompanyMatching;
                ComImg.ImageUrl = post.ComImg;
            }
            else
            {
                
            }
        }
    }
}