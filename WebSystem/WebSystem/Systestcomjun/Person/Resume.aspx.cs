using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZhongLi.Common;

namespace WebSystem.Systestcomjun.Person
{
    public partial class Resume : BasePage
    {
        private string url = "Resume.aspx?PerID=";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Utils.CheckRole("4"))
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('权限信息','没有权限！','/Systestcomjun/index.aspx',2)</script>");
                return;
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["PerID"]!=null)
                {
                    int PerID = Convert.ToInt32(Request.QueryString["PerID"]);
                    url += PerID;
                    //基本资料
                    ZhongLi.Model.Person person = new ZhongLi.BLL.Person().GetModel(PerID);
                    ltlRealName.Text = person.RealName;
                    ltlSex.Text = person.Sex == true ? "男" : "女";
                    ltlEducation.Text = person.Education;
                    ltlWorkLife.Text = person.WorkLife;
                    ltlCity.Text = person.City;
                    ltlPhne.Text = person.Phne;
                    if (person.Photo != "")
                    {
                        imgPhoto.ImageUrl = person.Photo;
                    }
                    ltlEmail.Text = person.Email;
                    //期望工作
                    List<ZhongLi.Model.Person_ExpectWork> listperex = new ZhongLi.BLL.Person_ExpectWork().GetModelList(" PerID="+PerID);
                    if (listperex.Count > 0)
                    {
                        ltlExpectedPostion.Text = listperex[0].ExpectedPostion;
                        ltlWorkType.Text = listperex[0].WorkType;
                        ltlExCity.Text = listperex[0].ExCity;
                        ltlExSalary.Text = listperex[0].ExSalary;
                        ltlReMark.Text = listperex[0].ReMark;
                    }
                    //工作经历
                    rptPerWork.DataSource = new ZhongLi.BLL.Person_Work().GetList(" PerID="+PerID);
                    rptPerWork.DataBind();
                    //教育经历
                    rptEducation.DataSource = new ZhongLi.BLL.Person_Education().GetList(" PerID="+PerID);
                    rptEducation.DataBind();
                    //项目经历
                    rptPerProject.DataSource = new ZhongLi.BLL.Person_Project().GetList(" PerID="+PerID);
                    rptPerProject.DataBind();
                    //技能评价
                    rptPerSkill.DataSource = new ZhongLi.BLL.Person_Skill().GetList("PerID="+PerID);
                    rptPerSkill.DataBind();
                    //自我描述
                    ltlMyDes.Text = person.MyDes;
                }
            }
        }


        

        public string skillMasterDegree(string MasterDegree)
        {
            int m = Convert.ToInt32(MasterDegree);
            if (m <= 10)
            {
                return "了解";
            }
            if (m > 10 && m <= 50)
            {
                return "掌握";
            }
            if (m > 50 && m <= 90)
            {
                return "精通";
            }
            if (m > 90)
            {
                return "专家";
            }
            return "";
        }

        protected void rptPerWork_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("del"))
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                new ZhongLi.BLL.Person_Work().Delete(ID);
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('删除求职者工作经历','删除成功！','"+url+"',1)</script>");
            }
        }

        protected void rptEducation_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("del"))
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                new ZhongLi.BLL.Person_Education().Delete(ID);
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('删除求职者教育经历','删除成功！','" + url + "',1)</script>");
            }
        }

        protected void rptPerProject_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("del"))
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                new ZhongLi.BLL.Person_Project().Delete(ID);
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('删除求职者项目经历','删除成功！','" + url + "',1)</script>");
            }
        }

        protected void rptPerSkill_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName.Equals("del"))
            {
                int ID = Convert.ToInt32(e.CommandArgument);
                new ZhongLi.BLL.Person_Skill().Delete(ID);
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('删除求职者技能评价','删除成功！','" + url + "',1)</script>");
            }
        }
    }
}