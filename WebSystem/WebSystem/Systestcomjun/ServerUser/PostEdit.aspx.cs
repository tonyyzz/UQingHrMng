using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZhongLi.Common;

namespace WebSystem.Systestcomjun.ServerUser
{
    public partial class PostEdit : System.Web.UI.Page
    {
        ZhongLi.BLL.ServerUser_Post bll = new ZhongLi.BLL.ServerUser_Post();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["SerUserPostID"] != null)
                {
                    ZhongLi.Model.ServerUser_Post post = bll.GetModel(Convert.ToInt32(Request.QueryString["SerUserPostID"]));
                    txtSerUserID.Text = post.SerUserID + "";
                    txtCompany.Text = post.Company;
                    ddlTrade.SelectedValue = post.Trade;
                    txtPostName.Text = post.PostName;
                    ddlSalary.SelectedValue = post.Salary;
                    txtWorkAdress.Text = post.WorkAdress;
                    imgcom.ImageUrl = post.ComImg;
                    ddlScale.SelectedValue = post.Scale;
                    ddlNature.SelectedValue = post.Nature;
                    txtDirectLeader.Text = post.DirectLeader;
                    txtPostDuty.Text = post.PostDuty;
                    txtDevelopProspect.Text = post.DevelopProspect;
                    txtCreateTime.Text = post.CreateTime.Value.ToString("yyyy-MM-dd");
                    txtSeeCount.Text = post.SeeCount + "";
                    txtAdress.Text = post.Address;
                    string html = "<div class='mat'>";
                    string[] ms = { "地铁周边", "提供午餐", "周末双休", "带薪年假", "年度旅游", "提供住宿", "五险一金", "加班补助" };
                    if (post.CompanyMatching != "")
                    {
                        txtCompanyMatching.Value = post.CompanyMatching;
                        string[] m = post.CompanyMatching.Split(',');
                        foreach (string str in ms)
                        {
                            if (m.Contains(str))
                            {
                                html += "<span onclick='search(this)' class='search' s='1'>" + str + "</span>";
                            }
                            else
                            {
                                html += "<span onclick='search(this)' s='0'>" + str + "</span>";
                            }
                        }
                        html += "</div>";
                        ltlCompanyMatching.Text = html;
                    }
                    else
                    {
                        foreach (string str in ms)
                        {
                            html += "<span onclick='search(this)' s='0'>" + str + "</span>";
                        }
                        html += "</div>";
                        ltlCompanyMatching.Text = html;
                    }
                    txtOtherPoint.Text = post.OtherPoint;
                }
            }
        }

        protected void btnsave_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["SerUserPostID"] != null)
            {
                ZhongLi.Model.ServerUser_Post post = bll.GetModel(Convert.ToInt32(Request.QueryString["SerUserPostID"]));
                post.SerUserID = Convert.ToInt32(txtSerUserID.Text);
                post.Company = txtCompany.Text;
                post.Trade = ddlTrade.SelectedValue;
                post.PostName = txtPostName.Text;
                post.Salary = ddlSalary.SelectedValue;
                post.WorkAdress = txtWorkAdress.Text;
                if (upImgCom.HasFile)
                {
                    string fileExt = Utils.GetFileExt(upImgCom.FileName);
                    string newname = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "." + fileExt;
                    string filePath = Utils.GetMapPath("/upload/seruser/post/") + newname;
                    upImgCom.SaveAs(filePath);
                    post.ComImg = "/upload/seruser/post/" + newname;
                }
                post.Scale = ddlScale.SelectedValue;
                post.Nature = ddlNature.SelectedValue;
                post.DirectLeader = txtDirectLeader.Text;
                post.PostDuty = txtPostDuty.Text;
                post.DevelopProspect = txtDevelopProspect.Text;
                post.CreateTime = DateTime.Parse(txtCreateTime.Text);
                post.SeeCount = Convert.ToInt32(txtSeeCount.Text);
                post.Address = txtAdress.Text;
                post.CompanyMatching = txtCompanyMatching.Value;
                post.OtherPoint = txtOtherPoint.Text;
                if (bll.Update(post))
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('编辑职位信息','保存成功！','',1)</script>");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('编辑职位信息','保存失败','',2);</script>");
                }
            }
            else
            {
                ZhongLi.Model.ServerUser_Post post = new ZhongLi.Model.ServerUser_Post();
                post.SerUserID = Convert.ToInt32(txtSerUserID.Text);
                post.Company = txtCompany.Text;
                post.Trade = ddlTrade.SelectedValue;
                post.PostName = txtPostName.Text;
                post.Salary = ddlSalary.SelectedValue;
                post.WorkAdress = txtWorkAdress.Text;
                if (upImgCom.HasFile)
                {
                    string fileExt = Utils.GetFileExt(upImgCom.FileName);
                    string newname = DateTime.Now.ToString("yyyyMMddHHmmssffff") + "." + fileExt;
                    string filePath = Utils.GetMapPath("/upload/seruser/post/") + newname;
                    upImgCom.SaveAs(filePath);
                    post.ComImg = "/upload/seruser/post/" + newname;
                }
                post.Scale = ddlScale.SelectedValue;
                post.Nature = ddlNature.SelectedValue;
                post.DirectLeader = txtDirectLeader.Text;
                post.PostDuty = txtPostDuty.Text;
                post.DevelopProspect = txtDevelopProspect.Text;
                post.CreateTime = DateTime.Parse(txtCreateTime.Text);
                post.SeeCount = Convert.ToInt32(txtSeeCount.Text);
                post.Address = txtAdress.Text;
                post.CompanyMatching = txtCompanyMatching.Value;
                post.OtherPoint = txtOtherPoint.Text;
                post.Colvalue = "0";
                if (bll.Add(post)>0)
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('添加职位信息','保存成功！','',1)</script>");
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('添加职位信息','保存失败','',2);</script>");
                }
            }
        }
    }
}