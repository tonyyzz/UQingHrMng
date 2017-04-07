using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebSystem.AppCode;
using ZhongLi.Common;

namespace WebSystem.Systestcomjun.Order
{
	public partial class OrderList : BasePage
	{
		ZhongLi.BLL.Reward_Order bll = new ZhongLi.BLL.Reward_Order();
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Utils.CheckRole("10"))
			{
				Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('权限信息','没有权限！','/Systestcomjun/index.aspx',2)</script>");
				return;
			}
			if (!IsPostBack)
			{
				databind(true);
			}

		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="fromRequest">是否是从url请求获取的参数值，默认为不是</param>
		private void databind(bool isFromRequest = false)
		{
			string orderStateStr = "";
			if (isFromRequest) //是从url获取的参数值
			{
				orderStateStr = HttpContext.Current.Request["state"] ?? "";
			}
			else
			{
				orderStateStr = ddOrderState.SelectedValue;
			}
			if (string.IsNullOrWhiteSpace(orderStateStr))
			{
				orderStateStr = "-1";
			}

			int orderStateInt = Convert.ToInt32(orderStateStr);

			if (orderStateInt < -1 || orderStateInt > 12)
			{
				orderStateInt = -1;
			}

			if (isFromRequest)
			{
				//选中列表中的状态值
				ddOrderState.Items.FindByValue(orderStateInt.ToString()).Selected = true;
			}

			string where = " 1=1 ";
			if (orderStateInt != -1)
			{
				where += string.Format(" and OrderState={0} ", orderStateInt);
			}

			string key = Utils.ReplaceString(txtkey.Text.Trim());
			if (!string.IsNullOrWhiteSpace(key))
			{
				where += " and (SerRealName like '%" + key + "%' or RealName like '%" + key + "%' or OrderNum like '%" + key + "%') ";
			}
			AspNetPager1.RecordCount = bll.GetRecordCount(where);
			Repeater1.DataSource = bll.GetListByPage(where, "CreateTime desc", AspNetPager1.StartRecordIndex, AspNetPager1.EndRecordIndex);
			Repeater1.DataBind();
		}

		protected void btndel_Click(object sender, EventArgs e)
		{
			string ids = "";
			foreach (RepeaterItem item in Repeater1.Items)
			{
				CheckBox chk = (CheckBox)item.FindControl("chkid");
				if (chk.Checked)
				{
					HiddenField txtid = (HiddenField)item.FindControl("txtid");
					ids += txtid.Value + ",";
				}
			}
			if (ids != "")
			{
				ids = ids.TrimEnd(',');
				string delinfo = webHelper.delInfo("Reward_Order", "OrderNum", "OrderID", ids);
				if (bll.DeleteList(ids))
				{
					webHelper.addLog("删除订单：" + delinfo);
					Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('删除订单','删除成功！','',1)</script>");
					databind();
				}
				else
				{
					Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsg('删除订单','删除失败！','',2)</script>");
				}
			}
		}
		/// <summary>
		/// 查询按钮
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void Button1_Click(object sender, EventArgs e)
		{
			databind();
		}

		protected void AspNetPager1_PageChanged(object sender, EventArgs e)
		{

			databind();
		}
		public string GetOrderState(string OrderState)
		{
			string state = "";
			switch (OrderState)
			{
				case "0":
					state = "<span style='color:red;'>待付款</span>";
					break;
				case "1":
					state = "<span style='color:blue;'>悬赏中</span>";
					break;
				case "2":
					state = "<span style='color:blue;'>待审核</span>";
					break;
				case "3":
					state = "<span style='color:green;'>已完成</span>";
					break;
				case "4":
					state = "<span style='color:red;'>面试交流</span>";
					break;
				case "5":
					state = "<span style='color:red;'>订单失败</span>";
					break;
				case "6":
					state = "<span style='color:blue;'>客服处理</span>";
					break;
				case "7":
					state = "<span style='color:red;'>重新上传资料</span>";
					break;
				case "8":
					state = "<span style='color:blue;'>面试交流</span>";
					break;
				case "9":
					state = "<span style='color:blue;'>订单过期</span>";
					break;
				case "10":
					state = "<span style='color:blue;'>订单已取消</span>";
					break;
				case "11":
					state = "<span style='color:blue;'>等待HR确认</span>";
					break;
				case "12":
					state = "<span style='color:blue;'>HR已拒绝</span>";
					break;
			}
			return state;
		}
	}
}