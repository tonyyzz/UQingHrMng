using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ZhouFu.Common;
using ZhouFu.DBUtility;
using System.Text.RegularExpressions;

namespace ZhouFu.ServiceCs
{
    public class TB_Project
    {
        private ZhouFu.Bll.DataHandler bll = new Bll.DataHandler();
        private ZhouFu.Model.siteconfig config = new ZhouFu.Bll.siteconfig().loadConfig(Utils.GetXmlMapPath(DTKeys.FILE_SITE_XML_CONFING));

        #region 获取投资项目
        public string GetProjectList(int _Page, int _PageSize, string  _Type, string _OrderField, bool _OrderBy)
        {
            StringBuilder sbStr = new StringBuilder();
            if (_Page == 0) { _Page = 0; }
            if (_PageSize == 0) { _PageSize = 10; }
            if (_OrderField == "") { _OrderField = "pro_starttime"; }
            StringBuilder sbSqlWhere = new StringBuilder();
            sbSqlWhere.AppendFormat(" status in({0})","4,6,7");//4,6,7
            sbSqlWhere.AppendFormat(" and pro_type in({0})", _Type);
            sbSqlWhere.Append(" and pro_starttime <= GETDATE() and GETDATE()<=dateadd(dd,1,pro_endtime)");
            string _Fields = "id,pro_number,pro_title,pro_datum_gain,pro_starttime,pro_endtime,pro_Stars,status,pro_money,hk_month,isnull((select user_picture from sys_manager where id=TB_Project.pub_user),'') as pubuserpic,isnull((select SUM(tz_money) from TB_ProjectFinancing where tz_proid=TB_Project.id),0) as nowMoney";
            //true 降序 false 升序
            DataSet ds = bll.GetList("TB_Project", _Fields, _OrderField, _PageSize, _Page, false, _OrderBy, sbSqlWhere.ToString());
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                sbStr.Append("[{\"msg\":\"获取成功。\",\"data\":");
                sbStr.Append(EasyUIJsonHelper.TableToJson(dt));
                sbStr.Append(",\"state\":\"0\"}]");
            }
            else
            {
                sbStr.Append("[{\"msg\":\"获取失败,无匹配数据。\",\"data\":\"\",\"state\":\"1\"}]");
            }
            return sbStr.ToString();
        }
        #endregion

        #region 获取项目详细信息
        public string GetProDetailed(int _ProId)
        {
            StringBuilder sbStr = new StringBuilder();
            string Fields = "id,pro_money,hk_type,hk_month,remart,pro_number,pro_title,pro_datum_gain,pro_min_money,pro_max_money,pro_starttime,pro_endtime,pro_Stars,pro_max_count,pub_user,pro_reward_gain,isnull((select sum(tz_money)  from TB_ProjectFinancing where tz_proid=TB_Project.ID),0)as nowmoney,isnull((select SUM(t.rows) from (select COUNT(1) rows  from TB_ProjectFinancing where tz_proid=1 group by tz_person)as t),0)as nowperson";
            DataSet ds = bll.GetList("TB_Project", Fields, "id", 1, 1, false, false, "ID=" + _ProId);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                sbStr.Append("[{\"msg\":\"获取成功。\",\"data\":[");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    sbStr.Append("{");
                    sbStr.AppendFormat("\"proId\":\"{0}\",", dr["id"]);
                    sbStr.AppendFormat("\"pro_nowspeed\":\"{0}\",", GetNowSpeed(dr["nowmoney"], dr["pro_money"]));
                    sbStr.AppendFormat("\"pro_money\":\"{0}\",", dr["pro_money"]);
                    sbStr.AppendFormat("\"hk_type\":\"{0}\",", dr["hk_type"].ToString() == "1" ? "每月返息,到期返本" : "");
                    sbStr.AppendFormat("\"hk_month\":\"{0}\",", dr["hk_month"]);
                    sbStr.AppendFormat("\"remart\":\"{0}\",", dr["remart"].ToString().Replace("\"", "'"));
                    sbStr.AppendFormat("\"pro_number\":\"{0}\",", dr["pro_number"]);
                    sbStr.AppendFormat("\"pro_title\":\"{0}\",", dr["pro_title"]);
                    sbStr.AppendFormat("\"pro_datum_gain\":\"{0}\",", dr["pro_datum_gain"]);
                    sbStr.AppendFormat("\"pro_min_money\":\"{0}\",", dr["pro_min_money"]);
                    sbStr.AppendFormat("\"pro_max_money\":\"{0}\",", dr["pro_max_money"]);
                    sbStr.AppendFormat("\"pro_reward_gain\":\"{0}\",", dr["pro_reward_gain"]);
                    sbStr.AppendFormat("\"pro_starttime\":\"{0}\",", dr["pro_starttime"]!=null?Convert.ToDateTime(dr["pro_starttime"]).ToString("yyyy-MM-dd"):"");
                    sbStr.AppendFormat("\"pro_endtime\":\"{0}\",", dr["pro_endtime"] != null ? Convert.ToDateTime(dr["pro_endtime"]).ToString("yyyy-MM-dd") : "");
                    sbStr.AppendFormat("\"pro_Stars\":\"{0}\",", dr["pro_Stars"]);
                    sbStr.AppendFormat("\"pro_max_count\":\"{0}\",", dr["pro_max_count"]);
                    sbStr.AppendFormat("\"pub_user\":\"{0}\",", dr["pub_user"]);
                    sbStr.AppendFormat("\"nowmoney\":\"{0}\",", dr["nowmoney"]);
                    sbStr.AppendFormat("\"nowperson\":\"{0}\"", dr["nowperson"]);
                    sbStr.Append("}");
                }
                sbStr.Append("],\"state\":\"0\"}]");
            }
            else {
                sbStr.Append("[{\"msg\":\"获取失败。\",\"data\":\"\",\"state\":\"1\"");
            }
            return sbStr.ToString();
        }
        #endregion

        #region 获取充值取现记录
        public string GetMoneyDetails(int _Page,int _PageSize,int _Type,int _LoginId)
        {
            StringBuilder sbStr = new StringBuilder();
            if(_Page==0){_Page =1;}
            if(_PageSize==0){_PageSize=10;}
            string Fields = "cz_money,overmoney,add_time,case [status] when 0 then '待审' when 4 then '成功' when 2 then '待审' else '失败' end as [status],case cz_type when 1 then '线下' when 2 then '线上' else '默认' end as cz_type";
            string sqlWhere = string.Format("userid={0} and jy_type={1}", _LoginId, _Type);
            DataSet ds = bll.GetList("TB_ByMoneyDetails", Fields, "add_time", _PageSize, _Page, false, true, sqlWhere);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                sbStr.Append("[{\"msg\":\"获取成功。\",\"data\":");
                sbStr.Append(EasyUIJsonHelper.TableToJson(dt));
                sbStr.Append(",\"state\":\"0\"}]");
            }
            else {
                sbStr.Append("[{\"msg\":\"获取失败,无匹配数据。\",\"data\":\"\",\"state\":\"1\"}]");
            }
            return sbStr.ToString();
        }
        #endregion

        #region 获取用户账户明细信息
        public string GetAccountDetails(int _Page, int _PageSize, int _Type, int _LoginId)
        {
            StringBuilder sbStr = new StringBuilder();
            if (_Page == 0) { _Page = 1; }
            if (_PageSize == 0) { _PageSize = 10; }
            string Fields = "cz_money,overmoney,add_time,case [jy_type] when 1 then '充值' when 2 then '佣金' when 3 then '奖励' when 4 then '投资' when 5 then '提现' else '' end as [jy_type],case cz_type when 1 then '收入' when 2 then '支出' else '' end as cz_type";
            string sqlWhere = string.Format("userid={0} and zh_type={1}", _LoginId, _Type);
            DataSet ds = bll.GetList("TB_AccountDetails", Fields, "add_time", _PageSize, _Page, false, true, sqlWhere);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                sbStr.Append("[{\"msg\":\"获取成功。\",\"data\":");
                sbStr.Append(EasyUIJsonHelper.TableToJson(dt));
                sbStr.Append(",\"state\":\"0\"}]");
            }
            else
            {
                sbStr.Append("[{\"msg\":\"获取失败,无匹配数据。\",\"data\":\"\",\"state\":\"1\"}]");
            }
            return sbStr.ToString();
        }
        #endregion

        #region 计算当前进度
        public  string GetNowSpeed(object nowmoney, object allmoney)
        {
            string strSpeed = "0.00";
            if (Convert.ToDouble(nowmoney) > 0)
            {
                strSpeed = (Convert.ToInt32((Convert.ToDouble(nowmoney) / Convert.ToDouble(allmoney)) * 100)).ToString();
            }
            return strSpeed;
        }
	    #endregion

        #region 我要投资
        public string InfoSource(int _ProId, int _UserId, string _Money, string _Money2, string _DealPassword)
        {
            StringBuilder sbStr = new StringBuilder();
            decimal money = _Money == "" ? 0 : Convert.ToDecimal(_Money);
            decimal money2 = _Money2 == "" ? 0 : Convert.ToDecimal(_Money2);
            if (money > 0)
            {
                ZhouFu.Model.TB_Project pModel = new ZhouFu.Bll.TB_Project().GetModel(_ProId);
                ZhouFu.Model.sys_Manager mModel = new ZhouFu.Bll.sys_Manager().GetModel(_UserId);
                if (Convert.ToDouble(mModel.AccountBalance) < Convert.ToDouble(money))//判断用户余额
                {
                    sbStr.Append("[{\"msg\":\"您的余额不足。\",\"data\":\"\",\"state\":\"1\"}]");
                }
                else
                {
                    if (DESEncrypt.GetStringMD5(_DealPassword) == mModel.DealPassword)
                    {
                        object objSumMoney = new ZhouFu.Bll.DataHandler().GetSum("TB_ProjectFinancing", "tz_money", "tz_proid=" + pModel.id);
                        decimal LastMoney = Convert.ToDecimal(pModel.pro_money) - Convert.ToDecimal(objSumMoney);
                        if (LastMoney > pModel.pro_min_money)//如果还需投资额度大于单笔最小投资额度
                        {
                            if (money < pModel.pro_min_money)//判断单笔投资最小额度
                            {
                                sbStr.Append("[{\"msg\":\"单比最小投资额度￥:" + pModel.pro_min_money + "元。\",\"data\":\"\",\"state\":\"1\"}]");
                            }
                            else
                            {
                                if (money > Convert.ToDecimal(pModel.pro_max_money))//判断单笔投资最大额度
                                {
                                    sbStr.Append("[{\"msg\":\"单比最大投资额度￥:" + pModel.pro_max_money + "元。\",\"data\":\"\",\"state\":\"1\"}]");
                                }
                                else
                                {
                                    int tzCt = new ZhouFu.Bll.TB_ProjectFinancing().GetRecordCount(" tz_person=" + mModel.ID + " and tz_proid=" + pModel.id);
                                    if (tzCt >= pModel.pro_max_count)//如果投资用户所投笔数不在有效范围内
                                    {
                                        sbStr.Append("[{\"msg\":\"此项目个人最多投资" + pModel.pro_max_count + "笔，请您核实是否已投。\",\"data\":\"\",\"state\":\"1\"}]");
                                    }
                                    else
                                    {
                                        sbStr.Append(Info(mModel, pModel, money, money2));
                                    }
                                }
                            }
                        }
                        else
                        {//如果还需投资额度小于单笔最小投资额度
                            if (LastMoney < money)//如果投资额度大于还需投资额度
                            {
                                sbStr.Append("[{\"msg\":\"项目还需融资￥" + LastMoney + "元，请修改投资额度。\",\"data\":\"\",\"state\":\"1\"}]");
                            }
                            else
                            { //成功投资
                                sbStr.Append(Info(mModel, pModel, money, money2));
                            }
                        }
                    }
                    else {
                        sbStr.Append("[{\"msg\":\"交易密码不正确。\",\"data\":\"\",\"state\":\"1\"}]");
                    }
                }
            }
            return sbStr.ToString();
        }

        private string Info(Model.sys_Manager mModel,Model.TB_Project pModel,decimal money,decimal money2)
        {
            StringBuilder sbStr = new StringBuilder();
            int iJF = 0;//积分
            decimal tz_yield = Convert.ToDecimal(GetTzYield(pModel, mModel.user_category.ToString()));//获取用户收益率
            int firstperson = 0, firstbl = 0, secondperson = 0, secondbl = 0;
            if (pModel.pro_type == 0)//普通项目
            {
                firstperson = Convert.ToInt32(GetFirstPerson(mModel).Split('|')[0]);//一级会员ID
                firstbl = Convert.ToInt32(GetFirstPerson(mModel).Split('|')[1]);//一级佣金比例
                secondperson = Convert.ToInt32(GetFirstPerson(mModel).Split('|')[2]);//二级会员ID
                secondbl = Convert.ToInt32(GetFirstPerson(mModel).Split('|')[3]);//二级佣金比例
            }
            int projectid = pModel.id;
            int personid = mModel.ID;
            string ipaddress = DTRequest.GetIP();
            DateTime datetime = DateTime.Now;

            #region 添加项目融资金额
            ZhouFu.Model.TB_ProjectFinancing pfModel = new ZhouFu.Model.TB_ProjectFinancing();
            pfModel.tz_proid = projectid;
            pfModel.tz_person = personid;
            pfModel.tz_money = money;
            pfModel.tz_time = datetime;
            pfModel.tz_yield = float.Parse(tz_yield.ToString());
            #endregion

            //#region 修改用户账户
            //if (money > 0)
            //{
            //    mModel.AccountBalance = mModel.AccountBalance - Convert.ToDecimal(money);
            //    iJF = (int)(Convert.ToInt32(money) / Convert.ToInt32(config.Integral) * 1);//获得荣誉积分
            //    mModel.HonorPoints = mModel.HonorPoints + iJF;
            //}
            //if (money2 > 0)
            //{
            //    mModel.JLAccountBalance = mModel.JLAccountBalance - Convert.ToDecimal(money2);
            //}
            //#endregion

            #region 发送私信
            ZhouFu.Model.TB_UsersLog logModel = new ZhouFu.Model.TB_UsersLog();
            logModel.title = "(项目投资)账户扣款通知";
            logModel.content = string.Format("尊敬的用户您好，您的投资已成功，账户扣除" + pfModel.tz_money + "，请到个人中心查看明细。</br>感谢您对汇财e家一如既往的支持，希望我们的服务能够带来您财富的增长。", mModel.user_name, pModel.pro_title, pModel.pro_number, pfModel.tz_money, iJF);
            logModel.send_userid = 38;
            logModel.send_time = DateTime.Now;
            logModel.receiv_userid = mModel.ID;
            #endregion

            #region 记录用户账户明细
            ZhouFu.Model.TB_AccountDetails ADetailsModel = new ZhouFu.Model.TB_AccountDetails();
            if (money > 0)
            {
                //ADetailsModel.userid = mModel.ID;
                //ADetailsModel.jy_type = 4;
                //ADetailsModel.zh_type = 1;
                //ADetailsModel.cz_type = 2;
                //ADetailsModel.cz_money = pfModel.tz_money;
                //ADetailsModel.overmoney = mModel.AccountBalance - money;
                //ADetailsModel.remart = string.Format("投资项目【{0}/{1}】支出￥{2}元。", pModel.pro_title, pModel.pro_number, pfModel.tz_money);
            }
            #endregion


            if (1==1)
            {
                sbStr.Append("[{\"msg\":\"投资成功,您本次获得积分:" + iJF + "\",\"data\":\"\",\"state\":\"0\"}]");
                object endSumMoney = new ZhouFu.Bll.TB_ProjectFinancing().GetTotalInvestment(" tz_proid=" + pModel.id);//判断项目是否已经融资满额
                if (Convert.ToDecimal(endSumMoney) == pModel.pro_money)
                {
                    pModel.status = 5;
                    new ZhouFu.Bll.TB_Project().Update(pModel);
                }
            }
            else
            {
                sbStr.Append("[{\"msg\":\"投资失败,服务器处理出错。\",\"data\":\"\",\"state\":\"1\"}]");
            }
            return sbStr.ToString();
        }

        

        #region 获取用户投资收益率
        private string GetTzYield(ZhouFu.Model.TB_Project model, string _UserCategory)
        {
            string result = "0";
            decimal pro_datum_gain = (decimal)model.pro_datum_gain;//项目基准收益
            switch (_UserCategory)
            {
                case "1"://普通会员
                    result = pro_datum_gain.ToString();
                    break;
                case "0":
                    result = pro_datum_gain.ToString();
                    break;
                default://系统会员浮动利率
                    result = (Convert.ToDouble(pro_datum_gain) + (Convert.ToDouble(pro_datum_gain) * (Convert.ToDouble(config.profitfloat) / 100))).ToString("F2");
                    break;
            }
            return result;
        }
	    #endregion

        #region 获取一级佣金会员
        private string GetFirstPerson(ZhouFu.Model.sys_Manager model)
        {
            //返回字符串格式 一级上线ID|一级佣金比例|二级上线|二级佣金比例
            string strResult = "0|0|0|0";
            object obj = new ZhouFu.Bll.sys_Manager().GetField("ByClerk", "  id=" + model.ID);
            if (model.user_category == 4 || model.user_category == 5)
            {
                if (Convert.ToInt32(obj) > 0)//如果此用户有上线
                {
                    object obj2 = new ZhouFu.Bll.sys_Manager().GetField("ByClerk", "  id=" + obj);
                    if (Convert.ToInt32(obj2) > 0)//如果上线还有上线
                    {
                        strResult = obj2.ToString() + "|" + config.commission2 + "|" + obj.ToString() + "|" + config.commission1;
                    }
                    else
                    {
                        strResult = obj.ToString() + "|" + config.commission1 + "|0|0";
                    }
                }
            }
            return strResult;
        }
	    #endregion


        #endregion

        #region 获取我投资的项目
        public string GetNowInvestment(int _Page,int _PageSize,int _LoginId)
        {
            StringBuilder sbStr = new StringBuilder();
            string finaIds = new ZhouFu.Bll.TB_ProjectFinancing().GetFieldFormTable("tz_proid", "tz_person=" + _LoginId, "", " group by tz_proid");//获取当前用户投资项目
            if (finaIds != "")
            {
                if (_Page == 0) { _Page = 1; }//当前页
                if (_PageSize == 0) { _PageSize = 10; };//每页行数
                StringBuilder sbSqlWhere = new StringBuilder();
                sbSqlWhere.Append("id in (" + finaIds.Trim(',') + ")");
                sbSqlWhere.Append("and status=4");
                DataTable dt = new DataTable();
                DataSet ds = bll.GetList("dbo.TB_Project", "id as pro_Id,pro_number,pro_title,pro_datum_gain,pro_money,hk_month,[status],pro_Stars,pro_endtime,isnull((select COUNT(tz_person) from TB_ProjectFinancing where tz_proid=TB_Project.id ),0) as allps,isnull((select SUM(tz_money) from TB_ProjectFinancing where tz_proid=TB_Project.id),0) as allmoney", "id", _PageSize, _Page, false, true, sbSqlWhere.ToString());
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    dt = ds.Tables[0];
                    sbStr.Append("[{\"msg\":\"获取成功。\",\"data\":" + EasyUIJsonHelper.TableToJson(dt) + ",\"state\":\"0\"}]");
                }
                else
                {
                    sbStr.Append("[{\"msg\":\"获取成功,无匹配数据。\",\"data\":\"\",\"state\":\"1\"}]");
                }
            }
            else
            {
                sbStr.Append("[{\"msg\":\"获取成功,无匹配数据。\",\"data\":\"\",\"state\":\"1\"}]");
            }
            return sbStr.ToString();
        }
        #endregion

        #region 获取投资返息项目
        public string GetNowBackInterest(int _LoginId,int _Page,int _PageSize,int _State)
        {
            StringBuilder sbStr = new StringBuilder();
            if (_LoginId > 0)
            {
                if (_Page == 0) { _Page = 1; }
                if (_PageSize == 0) { _PageSize = 1; }
                int notTop = (_Page - 1) * _PageSize;//sql分页
                string strFields = "a.id as fcid,a.tz_money,a.tz_jh_money,a.tz_time,a.tz_yield,b.id as proid,b.pro_number,b.pro_title,b.pro_money,b.hk_month,b.pro_money";//需要查询的字段
                string strOrderBy = " a.tz_time desc";//按投资时间降序
                StringBuilder sbSqlWhere = new StringBuilder();//查询条件
                sbSqlWhere.AppendFormat(" a.tz_person={0}", _LoginId);
                sbSqlWhere.AppendFormat(" and b.status={0}", _State);
                StringBuilder sbNotSql = new StringBuilder();//sql分页语句
                sbNotSql.AppendFormat("select top {0} a.id from TB_ProjectFinancing as a left join TB_Project as b on a.tz_proid=b.id where {1} order by {2}", notTop, sbSqlWhere.ToString(), strOrderBy);
                StringBuilder sbSql = new StringBuilder();//SQL语句
                sbSql.AppendFormat("select top {0} {1} from TB_ProjectFinancing as a left join TB_Project as b on a.tz_proid=b.id where {2} and a.id not in({3}) order by {4}", _PageSize, strFields, sbSqlWhere.ToString(), sbNotSql.ToString(), strOrderBy);

                DataSet ds = new ZhouFu.Bll.TB_ProjectFinancing().GetListBySQL(sbSql.ToString());
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    sbStr.Append("[{\"msg\":\"查询成功。\",\"data\":[");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        sbStr.Append("{");
                        sbStr.Append("\"pro_title\":\"" + dt.Rows[i]["pro_title"] + "\",");
                        sbStr.Append("\"pro_number\":\"" + dt.Rows[i]["pro_number"] + "\",");
                        sbStr.Append("\"hk_month\":\"" + dt.Rows[i]["hk_month"] + "\",");
                        sbStr.Append("\"tz_money\":\"" + dt.Rows[i]["tz_money"] + "\",");
                        sbStr.Append("\"tz_jh_money\":\"" + dt.Rows[i]["tz_jh_money"] + "\",");
                        sbStr.Append("\"tz_yield\":\"" + dt.Rows[i]["tz_yield"] + "\",");
                        sbStr.Append("\"tz_time\":\"" + dt.Rows[i]["tz_time"] + "\",");
                        sbStr.Append("\"detailedList\":");
                        sbStr.Append(EasyUIJsonHelper.TableToJson(GetCreateTable(dt.Rows[i]["proid"], Convert.ToInt32(dt.Rows[i]["hk_month"]), dt.Rows[i]["tz_money"], dt.Rows[i]["tz_jh_money"], dt.Rows[i]["tz_yield"])));
                        sbStr.Append("}");
                        if (i < dt.Rows.Count-1) { sbStr.Append(","); }

                    }
                    sbStr.Append("],\"state\":\"0\"}]");
                }
                else {
                    sbStr.Append("[{\"msg\":\"查询成功,无匹配数据。\",\"data\":\"\",\"state\":\"1\"}]");
                }
            }
            else {
                sbStr.Append("[{\"msg\":\"获取失败,输入参数错误。\",\"data\":\"\",\"state\":\"2\"}]");
            }
            return sbStr.ToString();
        }

        

        #region 获取用户收益数据
        public DataTable GetCreateTable(object proid, int month, object money, object jlmoney, object yield)//项目ID、返款期数、投资金额、激活奖励金、投资收益率
        {
            #region 获取项目返息时间表
            StringBuilder sbSqlWhere = new StringBuilder();
            sbSqlWhere.AppendFormat(" proid=" + proid);
            DataSet ds = new ZhouFu.Bll.DataHandler().GetList("dbo.TB_ProjectBackDetails", "backcount,backtime,backstatus,status, DATEDIFF(day,getdate(),backtime) as nowday ", "id", 100, 1, false, false, sbSqlWhere.ToString());
            #endregion
            DataTable edt = new DataTable();
            edt.Columns.Add("qs", Type.GetType("System.String"));//返息期数
            edt.Columns.Add("yfbj", Type.GetType("System.String"));//应还本金
            edt.Columns.Add("yflx", Type.GetType("System.String"));//应还利息
            edt.Columns.Add("fxsj", Type.GetType("System.String"));//返息时间
            edt.Columns.Add("jlts", Type.GetType("System.String"));//距离天数
            edt.Columns.Add("zt", Type.GetType("System.String"));//返息状态

            if (ds != null && ds.Tables.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int qs = Convert.ToInt32(dt.Rows[i]["backcount"]);
                    string bj = GetBenJin(month, qs, money, jlmoney);
                    string lx = GetLiXi(month, money, jlmoney, yield);
                    string fxsj = dt.Rows[i]["backtime"].ToString();
                    string jlts = dt.Rows[i]["nowday"].ToString();
                    string zt = dt.Rows[i]["status"].ToString() == "5" ? "已返" : "未返";
                    edt.Rows.Add(qs, bj, lx, fxsj, jlts, zt);
                }
            }
            return edt;
        }

        #region 应返本金
        private string GetBenJin(int allMonth, int nowMonth, object tzMoney, object jlMoney)
        {
            string money = "0.00";
            if (nowMonth == allMonth)
            {
                money = (Convert.ToDecimal(tzMoney) + Convert.ToDecimal(jlMoney)).ToString();
            }
            return money;
        }
        #endregion

        #region 应返用户利息
        private  string GetLiXi(int allMonth, object tzMoney, object jlMoney, object syl)
        {
            string money;
            double money2 = (Convert.ToDouble(tzMoney) + Convert.ToDouble(jlMoney)) * (Convert.ToDouble(syl) / 100) / allMonth;
            money = money2.ToString("F2");
            return money;
        }
        #endregion

        #endregion

        #endregion

        

        #region 在审核的项目
        public string GetApplyForProList(string _StrJson)
        {
            StringBuilder sbStr = new StringBuilder();
            sbStr.Append("[{\"msg\":\"获取失败，内部处理错误。\",\"data\":\"\",\"state\":\"2\"}]");
            try { 
                StringBuilder SqlWhere = new StringBuilder();
                string Fields = "id,title,pro_money,hk_type,hk_month,hope_rate,status";
                CommonJsonModel model = new CommonJsonModel(Regex.Replace(_StrJson, @"\r\n", ""));
                List<CommonJsonModel> lst = model.GetCollection();
                Model.TB_Project proModel = new Model.TB_Project();
                foreach (CommonJsonModel item in lst)
                {
                    int Page = Convert.ToInt32(item.GetValue("_Page"));
                    int PageSize = Convert.ToInt32(item.GetValue("_PageSize"));
                    string LoginId = item.GetValue("_LoginId");
                    SqlWhere.AppendFormat("status<=4 and  pub_user={0}", LoginId);
                    DataTable dt = new DataTable();
                    DataSet ds = new ZhouFu.Bll.DataHandler().GetList("TB_Project", Fields, "id", PageSize, Page, false, true, SqlWhere.ToString());
                    if (ds != null && ds.Tables.Count > 0)
                    {
                        sbStr.Append("[{\"msg\":\"获取数据成功。\",\"data\":" + EasyUIJsonHelper.TableToJson(ds.Tables[0]) + ",\"state\":\"0\"}]");
                    }
                    else {
                        sbStr.Append("[{\"msg\":\"获取数据成功,无匹配数据。\",\"data\":\"\",\"state\":\"1\"}]");
                    }
                }
            }
            catch { }
            return sbStr.ToString();
        }
        #endregion

        #region 获取聚焦图片
        public string GetSlidePicture(string _StrJson)
        {
            StringBuilder sbStr = new StringBuilder();
            sbStr.Append("[{\"msg\":\"获取失败，无匹配数据。\",\"data\":\"\",\"state\":\"1\"}]");
            CommonJsonModel model = new CommonJsonModel(Regex.Replace(_StrJson, @"\r\n", ""));
            List<CommonJsonModel> lst = model.GetCollection();
                foreach (CommonJsonModel item in lst)
                {
                    string tempPage = item.GetValue("_Page");
                    string tempPageSize = item.GetValue("_PageSize");
                    int _Page = (tempPage != "" && Convert.ToInt32(tempPage)>0)? Convert.ToInt32(item.GetValue("_Page")) : 1;
                    int _PageSize = (tempPageSize != "" && Convert.ToInt32(tempPageSize)>0) ? Convert.ToInt32(item.GetValue("_PageSize")) : 100;
                    DataTable dt = new DataTable();
                    DataSet ds = new ZhouFu.Bll.DataHandler().GetList("dbo.TB_SlidePicture", "ID,FilePath,Url", "sort", _PageSize, _Page, false, false, "");
                    if (ds != null && ds.Tables[0].Rows.Count > 0)
                    {
                        dt = ds.Tables[0];
                        sbStr.Clear();
                        sbStr.Append(EasyUIJsonHelper.TableToJson(dt));
                    }
                }
            return sbStr.ToString();
        }
        #endregion

    }
}
