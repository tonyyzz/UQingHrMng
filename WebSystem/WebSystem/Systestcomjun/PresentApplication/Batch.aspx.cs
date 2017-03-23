using Com.Admin.Alipay;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZhongLi.Common;

namespace WebSystem.Systestcomjun.PresentApplication
{
    public partial class Batch : System.Web.UI.Page
    {
        ZhongLi.BLL.PresentApplication bll = new ZhongLi.BLL.PresentApplication();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Utils.CheckRole("11"))
            {
                Page.ClientScript.RegisterStartupScript(Page.GetType(), "set", "<script>window.onload=showmsgclose('权限信息','没有权限！','/Systestcomjun/index.aspx',2)</script>");
                return;
            }
            if (!IsPostBack)
            {
                Databind();
            }
        }

        private void Databind()
        {
            string key = Utils.ReplaceString(txtkey.Text.Trim());
            string where = " Batch_No like '%" + key + "%'";
            AspNetPager1.RecordCount = bll.GetBatchRecordCount(where);
            Repeater1.DataSource = bll.GetBatchListByPage(where, " BatchID desc", AspNetPager1.StartRecordIndex, AspNetPager1.EndRecordIndex);
            Repeater1.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Databind();
        }

        protected void AspNetPager1_PageChanged(object sender, EventArgs e)
        {
            Databind();
        }

        protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            //1得到批次 2获取批次提现数据 3拼接数据 4发送请求
            int BatchID=Convert.ToInt32(e.CommandArgument);
            Response.Write("<script>window.open('pay.aspx?BatchID=" + BatchID + "')</script>");
            //DataTable batchDt = bll.getBatchByID(BatchID);
            //DataTable dt = bll.GetList(" BatchID =" + BatchID + "").Tables[0];
            //int batch_num = dt.Rows.Count;//付款总笔数
            //string detail_data = "";//付款详细数据
            //decimal Batch_Fee = Convert.ToDecimal(batchDt.Rows[0]["Batch_Fee"]);//付款总金额
            //foreach (DataRow dr in dt.Rows)
            //{
            //    detail_data += dr["PreNum"] + "^";//流水号
            //    detail_data += dr["AliAccount"] + "^";//收款账号
            //    detail_data += dr["AliAccounttName"] + "^";//收款姓名
            //    detail_data += dr["Money"] + "^"; ;//付款金额
            //    detail_data += "提现";//备注
            //    detail_data += "|";
            //}
            //detail_data = detail_data.TrimEnd('|');
            //int AdminID = Convert.ToInt32(Utils.GetCookie("UserID"));
            ////生成批次

            //string Batch_No = batchDt.Rows[0]["Batch_No"].ToString();//当前批次号

            //if (BatchID > 0)
            //{
            //    //把请求参数打包成数组
            //    SortedDictionary<string, string> sParaTemp = new SortedDictionary<string, string>();
            //    sParaTemp.Add("partner", Config.Partner);
            //    sParaTemp.Add("_input_charset", Config.Input_charset.ToLower());
            //    sParaTemp.Add("service", "batch_trans_notify");
            //    sParaTemp.Add("notify_url", "http://www.uqinger.com/Systestcomjun/PresentApplication/notify_url.aspx");
            //    sParaTemp.Add("email", "58191362@qq.com");
            //    sParaTemp.Add("account_name", "武汉优青人力资源有限公司");
            //    sParaTemp.Add("pay_date", DateTime.Now.ToString("yyyyMMdd"));
            //    sParaTemp.Add("batch_no", Batch_No);
            //    sParaTemp.Add("batch_fee", Batch_Fee.ToString());//
            //    sParaTemp.Add("batch_num", batch_num.ToString());
            //    sParaTemp.Add("detail_data", detail_data);
            //    //建立请求
            //    string sHtmlText = Submit.BuildRequest(sParaTemp, "get", "确认");
            //    Response.Write(sHtmlText);
            //}
            
        }
    }
}