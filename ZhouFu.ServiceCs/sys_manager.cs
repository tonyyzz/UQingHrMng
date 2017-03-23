using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZhouFu.DBUtility;
using ZhouFu.Common;
using System.Data;
using System.Text.RegularExpressions;
using System.IO;
using System.Web;

namespace ZhouFu.ServiceCs
{
    public class sys_manager
    {

        private ZhouFu.Bll.DataHandler bll = new Bll.DataHandler();
        #region 用户注册
        public string Register(string _LoginName, string _LoginPassword, int _LoginType,string  _Action)
        {
            StringBuilder sbStr = new StringBuilder();
            object objRowCount = DbHelperSQL.GetSingle(string.Format("select count(1) from sys_manager where login_name='{0}' and login_category={1}", _LoginName, _LoginType));
            if (Convert.ToInt32(objRowCount) > 0)
            {
                sbStr.Append("[{\"msg\":\"用户已存在\",\"data\":\"\",\"state\":\"1\"}]");
            }
            else
            {
                int  iCt = InfoData(_LoginName, _LoginPassword, _LoginType,_Action);
                if (iCt > 0)
                {
                    sbStr.Append("[{\"msg\":\"注册成功\",\"data\":\"\",\"state\":\"0\"}]");
                }
                else {
                    sbStr.Append("[{\"msg\":\"注册失败,服务器处理错误\",\"data\":\"\",\"state\":\"2\"}]");
                }
            }
            return sbStr.ToString();
        }

        private int InfoData(string _LoginName, string _LoginPassword,int _LoginType,string _Action)
        {
            int iCt = 0;
           // ZhouFu.Model.sys_Manager model = new ZhouFu.Model.sys_Manager();
           // ZhouFu.Bll.sys_Manager bll = new ZhouFu.Bll.sys_Manager();
           // model.login_name = _LoginName;
           // model.user_name = _LoginName;
           // model.login_password = DESEncrypt.GetStringMD5(_LoginPassword);
           // model.DealPassword = DESEncrypt.GetStringMD5(_LoginPassword);
           // model.user_category = 1;
           // model.AccountBalance = 0;
           // model.DJAccountBalance = 0;
           // model.department_id = 49;
           // model.role_id = 13;
           // model.user_picture = "/images/mortx.jpg";
           // model.ByClerk = 0;
           // switch (_Action)
           // {
           //     case "Email": //Email邮箱
           //         model.user_email = _LoginName;
           //         break;
           //     case "Mobile"://Phone手机号码
           //         model.user_mobile = _LoginName;
           //         model.IsMobileVerify = true;
           //         break;
           //     default:
           //         break;
           // }
           //iCt = bll.Add(model);
           //if (iCt > 0)
           // {
           //     if (_Action == "Email")
           //     { 
           //         //发邮件
           //         SendEmail(_LoginName,iCt);
           //     }
           //     if (model.login_category == 1) //如果是企业用户
           //     {
           //         ZhouFu.Model.Sm_Monad mondmodel = new ZhouFu.Model.Sm_Monad();
           //         mondmodel.userid = iCt;
           //         new ZhouFu.Bll.Sm_Monad().Add(mondmodel);
           //     }
           // }
            return iCt;
        }

        private void SendEmail(string _LoginName, int _iCt) 
        {
            // siteconfig业务逻辑
            ZhouFu.Bll.siteconfig sitebll = new ZhouFu.Bll.siteconfig();
            ZhouFu.Model.siteconfig site = sitebll.loadConfig(Utils.GetXmlMapPath(DTKeys.FILE_SITE_XML_CONFING));
            string smtpserver = site.emailstmp;
            string userName = site.emailusername;
            string pwd = DESEncrypt.Decrypt(site.emailpassword);
            string nickName = site.emailnickname;
            string strfrom = site.emailfrom;
            string strto = _LoginName;
            string subj = "邮箱认证";
            string bodys = HttpContext.Current.Request.Url.Authority+ "/RzEmail.aspx?Id=" + Base64Protector.Base64Code(_iCt.ToString());
            DTMail.sendMail(smtpserver, userName, pwd, nickName, strfrom, strto, subj, bodys);
        }

        #endregion

        #region 用户登陆
        public string Login(string _LoginName, string _LoginPassword)
        {
            ZhouFu.Bll.DataHandler bll = new Bll.DataHandler();
            StringBuilder sbStr = new StringBuilder();
            try
            {
                string _Fields = "ID,user_name,user_mobile,user_email,user_sex,user_province,user_city,user_county,user_address,user_picture,(select LinkPicture from sys_ManagerGrade where ID=sys_manager.user_category) as user_category,(select picture from dbo.TB_HonorSet where  (dbo.sys_Manager.HonorPoints)  BETWEEN  startnumber and endnumber)as HonorSetPic,AccountBalance,DJAccountBalance,JLAccountBalance,IsEmailVerify,IsMobileVerify,IsPersonVerify,RealName,CodeNumber,DealPassword,bank_id,bank_province,bank_city,bank_address,bank_card,login_category,LastTime";
                string _SqlWhere =string.Format(" login_name='{0}' and login_password='{1}'",_LoginName,DESEncrypt.GetStringMD5(_LoginPassword));
                DataSet ds = bll.GetList("sys_manager", _Fields, "ID", 1, 1, false, false, _SqlWhere);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    DataTable dt = ds.Tables[0];
                    
                    if (dt.Columns["DealPassword"].ColumnName == "DealPassword")
                    {
                        dt.Rows[0]["DealPassword"] = DESEncrypt.GetStringMD5(dt.Rows[0]["DealPassword"].ToString());
                    }
                    sbStr.Append("[{\"msg\":\"登陆成功\",");
                    sbStr.Append("\"data\":");
                    sbStr.Append(EasyUIJsonHelper.TableToJson(dt));
                    sbStr.Append(",\"state\":\"0\"}]");
                    ZhouFu.Model.sys_Manager mModel = new ZhouFu.Bll.sys_Manager().GetModel(Convert.ToInt32(dt.Rows[0]["ID"]));
                    mModel.LastTime =  DateTime.Now;
                    new ZhouFu.Bll.sys_Manager().Update(mModel);
                }
                else
                {
                    sbStr.Append("[{\"msg\":\"登陆失败，用户名或密码错误\",\"data\":\"\",\"state\":\"1\"}]");
                }
            }
            catch
            {
                sbStr.Append("[{\"msg\":\"登陆失败，服务器处理错误\",\"data\":\"\",\"state\":\"2\"}]");
            }
            return sbStr.ToString();
        }
        #endregion

        #region 完善个人信息
        public string UpdatePersonInformation(string _StrJson)
        {
            StringBuilder sbStr = new StringBuilder();
            try
            {
                StringBuilder sbsql = new StringBuilder();
                CommonJsonModel model = new CommonJsonModel(Regex.Replace(_StrJson, @"\r\n", ""));
                List<CommonJsonModel> lst = model.GetCollection();
                ZhouFu.Bll.sys_Manager bllManager = new Bll.sys_Manager();
                ZhouFu.Model.sys_Manager modelManager = new Model.sys_Manager();
                foreach (CommonJsonModel item in lst)
                {
                    #region 模型参数设置
                    string _UserId = item.GetValue("_UserId");//用户编号
                    string aaaa = item.Rawjson;
                    string _RealName = item.GetValue("_RealName");//真实姓名
                    string _Sex = item.GetValue("_Sex");//性别
                    string _Province = item.GetValue("_Province");//省
                    string _City = item.GetValue("_City");//城市
                    string _County = item.GetValue("_County");//区县
                    string _Email = item.GetValue("_Email");//邮箱
                    string _Mobile = item.GetValue("_Mobile");//手机
                    string _CodeNumber = item.GetValue("_CodeNumber");//身份证号
                    string _BankId = item.GetValue("_BankId");//银行ID号
                    string _BankCard = item.GetValue("_BankCard");//银行卡号
                    string _BankProvince = item.GetValue("_BankProvince");//开户省份
                    string _BankCity = item.GetValue("_BankCity");//开户城市
                    string _BankAddress = item.GetValue("_BankAddress");//开户地址
                    if (_UserId != "")
                    {
                        modelManager = bllManager.GetModel(Convert.ToInt32(_UserId));
                    }
                    if (_RealName != "")
                    {
                        modelManager.RealName = _RealName;
                    }
                    if (_Sex != "")
                    {
                        modelManager.user_sex = _Sex;
                    }
                    if (_Province != "")
                    {
                        modelManager.user_province = _Province;
                    }
                    if (_City != "")
                    {
                        modelManager.user_city = _City;
                    }
                    if (_County != "")
                    {
                        modelManager.user_county = _County;
                    }
                    if (_Email !="")
                    {
                        modelManager.user_email = _Email;
                    }
                    if (_Mobile != "")
                    {
                        modelManager.user_mobile = _Mobile;
                    }
                    if (_CodeNumber !="")
                    {
                        modelManager.CodeNumber = _CodeNumber;
                    }
                    if (_BankId !="")
                    {
                        modelManager.bank_id =Convert.ToInt32(_BankId);
                    }
                    if (_BankCard != "")
                    {
                        modelManager.bank_card = _BankCard;
                    }
                    if (_BankProvince != "")
                    {
                        modelManager.bank_province = _BankProvince;
                    }
                    if (_BankCity !="")
                    {
                        modelManager.bank_city = _BankCity;
                    }
                    if (_BankAddress != "")
                    {
                        modelManager.bank_address = _BankAddress;
                    }
                    #endregion
                }
                if (bllManager.Update(modelManager))
                {
                    sbStr.Append("[{\"msg\":\"修改成功\",\"data\":\"\",\"state\":\"0\"}]");
                }
                else {
                    sbStr.Append("[{\"msg\":\"修改失败，服务器处理错误\",\"data\":\"\",\"state\":\"1\"}]");
                }
            }
            catch
            {
                sbStr.Append("[{\"msg\":\"修改失败，服务器处理错误\",\"data\":\"\",\"state\":\"2\"}]");
            }
            return sbStr.ToString();
        }
        #endregion

        #region 修改个人头像
        public string UpdateHeadPortrait(string _StrJson)
        {
            StringBuilder sbResult = new StringBuilder();
            try
            {
                string strSql = "update sys_manager set user_picture='{0}' where ID={1}";
                string filepath = string.Empty;
                int iRowCount = 0;
                CommonJsonModel model = new CommonJsonModel(Regex.Replace(_StrJson, @"\r\n", ""));
                List<CommonJsonModel> lst = model.GetCollection();
                string imgname = string.Empty;
                foreach (CommonJsonModel item in lst)
                {
                    #region 图片上传
                    
                    byte[] imgStream = Convert.FromBase64String(item.GetValue("_Stream"));
                    if (!imgStream.Equals(""))
                    {
                        imgname = DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
                        filepath = "/Upload/" + DateTime.Now.ToString("yyyyMM") + "/" + DateTime.Now.Date.Day + "/";
                        string webpath = System.Web.HttpContext.Current.Server.MapPath("/" + filepath);
                        if (!Directory.Exists(webpath))//不存在此目录则创建目录
                        {
                            Directory.CreateDirectory(webpath);
                        }
                        FileStream fStream = new FileStream((webpath+imgname), FileMode.Create, FileAccess.Write);
                        BinaryWriter bw = new BinaryWriter(fStream);
                        bw.Write(imgStream);
                        bw.Close();
                        fStream.Close();
                    }
                    #endregion
                    iRowCount = DbHelperSQL.ExecuteSql(string.Format(strSql, (filepath + imgname), item.GetValue("_LoginId")));
                }
                if (iRowCount > 0)
                {
                    sbResult.Append("[{\"msg\":\"修改成功\",\"data\":\"" + filepath + imgname + "\",\"state\":\"0\"}]");
                }
                else {
                    sbResult.Append("[{\"msg\":\"修改失败,执行修改出错。\",\"data\":\"\",\"state\":\"1\"}]");
                }
            }
            catch
            {
                sbResult.Append("[{\"msg\":\"修改失败,服务器处理出错\",\"data\":\"\",\"state\":\"2\"}]");
            }
            return sbResult.ToString();
        }
        #endregion

        #region 修改账户密码
        public string UpdatePassword(int _LoginId, string _NewPassword)
        {
            StringBuilder sbResult = new StringBuilder();
            int iRowCount = DbHelperSQL.ExecuteSql(string.Format("update sys_manager set login_password='{0}' where id={1}", DESEncrypt.GetStringMD5(_NewPassword), _LoginId));
                if (iRowCount > 0)
                {
                    sbResult.Append("[{\"msg\":\"修改成功\",\"data\":\"\",\"state\":\"0\"}]");
                }
                else {
                    sbResult.Append("[{\"msg\":\"修改失败服务器处理出错\",\"data\":\"\",\"state\":\"1\"}]");
                }
            return sbResult.ToString();
        }
        #endregion

        #region 修改支付密码
        public string UpdatePaymentPassword(int _LoginId, string _NewPaymentPassword)
        {
                StringBuilder sbResult = new StringBuilder();
                int iRowCount = DbHelperSQL.ExecuteSql(string.Format("update sys_manager set DealPassword='{0}' where id={1}", DESEncrypt.GetStringMD5(_NewPaymentPassword), _LoginId));
                if (iRowCount > 0)
                {
                    sbResult.Append("[{\"msg\":\"修改成功\",\"data\":\"\",\"state\":\"0\"}]");
                }
                else
                {
                    sbResult.Append("[{\"msg\":\"修改失败\",\"data\":\"\",\"state\":\"1\"}]");
                }
            return sbResult.ToString();
        }
        
        #endregion

        #region 获取企业详细信息
        public string GetCompanyInformation(int _UserId)
        {
            ZhouFu.Bll.DataHandler bll = new Bll.DataHandler();
            StringBuilder sbStr = new StringBuilder();
            string _Fields = "ID as CompanyId,MonadName,LogoUrl,Phone,MailBox,Type,NumberOfPeople,Nature,Province,City,County,Address,Describe,Url,userid as LoginId,RegisteredCapital,RunRange";
            string _SqlWhere = string.Format(" userid='{0}'", _UserId);
            DataSet ds = bll.GetList("Sm_Monad", _Fields, "ID", 1, 1, false, false, _SqlWhere);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                sbStr.Append("[{\"msg\":\"查询成功\",");
                sbStr.Append("\"data\":");
                string strTemp = EasyUIJsonHelper.TableToJson(dt);
                DataSet dsFile = bll.GetList("Sm_CaseInformation", "ID,Name,FilePath,bigFilePath", "ID", 100, 1, false, false, "MonadID=" + dt.Rows[0]["LoginId"]);
                if (dsFile != null && dsFile.Tables[0].Rows.Count > 0)
                {

                    DataTable dtFile = dsFile.Tables[0];
                    string strTempFile = EasyUIJsonHelper.TableToJson(dtFile);
                    strTemp = strTemp.Insert((strTemp.Length - 2), ",\"FileList\":" + strTempFile);
                }
                sbStr.Append(strTemp);
                sbStr.Append(",\"state\":\"0\"}]");
            }
            else
            {
                sbStr.Append("[{\"msg\":\"查询失败,企业信息不存在\",\"data\":\"\",\"state\":\"1\"}]");
            }
            return sbStr.ToString();
        }
        #endregion

        #region 完善企业信息
        public string UpdateCompanyInformation(string _StrJson)
        {
            StringBuilder sbStr = new StringBuilder();
            try
            {
                StringBuilder sbsql = new StringBuilder();
                CommonJsonModel model = new CommonJsonModel(Regex.Replace(_StrJson, @"\r\n", ""));
                List<CommonJsonModel> lst = model.GetCollection();
                ZhouFu.Bll.Sm_Monad bllMonad = new Bll.Sm_Monad();
                ZhouFu.Model.Sm_Monad modelMonad = new Model.Sm_Monad();
                foreach (CommonJsonModel item in lst)
                {
                    #region 模型参数设置
                    string _CompanyId = item.GetValue("_CompanyId");//主键ID
                    string _MonadName = item.GetValue("_MonadName");//企业名称
                    string _MailBox = item.GetValue("_MailBox");//企业邮箱
                    string _Type = item.GetValue("_Type");//企业类型
                    string _Nature = item.GetValue("_Nature");//企业性质
                    string _NumberOfPeople = item.GetValue("_NumberOfPeople");//企业人数
                    string _RegisteredCapital = item.GetValue("_RegisteredCapital");//注册资金
                    string _Url = item.GetValue("_Url");//网址
                    string _Province = item.GetValue("_Province");//省份
                    string _City = item.GetValue("_City");//城市
                    string _County = item.GetValue("_County");//区县
                    string _RunRange = item.GetValue("_RunRange");//经营范围
                    string _Describe = item.GetValue("_Describe");//简介
                    //string _LogoUrl = item.GetValue("_LogoUrl");//企业Logo

                    if (_CompanyId != ""){modelMonad = bllMonad.GetModel(Convert.ToInt32(_CompanyId));}
                    if (_MonadName != ""){modelMonad.MonadName = _MonadName; }
                    if (_MailBox != ""){modelMonad.MailBox = _MailBox;}
                    if (_Type != ""){modelMonad.Type = Convert.ToInt32(_Type);}
                    if (_Nature != ""){modelMonad.Nature =(_Nature==""?0:Convert.ToInt32(_Nature));}
                    if (_NumberOfPeople != ""){modelMonad.NumberOfPeople = Convert.ToInt32(_NumberOfPeople);}
                    if (_RegisteredCapital != ""){modelMonad.RegisteredCapital =Convert.ToInt32(_RegisteredCapital);}
                    if (_Url != ""){modelMonad.Url = _Url;}
                    if (_Province != ""){modelMonad.Province = _Province;}
                    if (_City != ""){modelMonad.City = _City;}
                    if (_County != ""){modelMonad.County = _County;}
                    if (_RunRange != ""){modelMonad.RunRange = _RunRange;}
                    if (_Describe != ""){modelMonad.Describe = _Describe;}
                    //if (_LogoUrl != ""){modelMonad.LogoUrl = _LogoUrl;}
                    #endregion
                }
                if (bllMonad.Update(modelMonad))
                {
                    sbStr.Append("[{\"msg\":\"修改成功\",\"data\":\"\",\"state\":\"0\"}]");
                }
                else
                {
                    sbStr.Append("[{\"msg\":\"修改失败，服务器处理错误\",\"data\":\"\",\"state\":\"1\"}]");
                }
            }
            catch
            {
                sbStr.Append("[{\"msg\":\"修改失败，服务器处理错误\",\"data\":\"\",\"state\":\"2\"}]");
            }
            return sbStr.ToString();
        }
        #endregion

        #region 删除企业风采信息
        public string DeleteCompanyFiles(int _Id)
        {
            StringBuilder sbResult = new StringBuilder();
            int iRowCount = DbHelperSQL.ExecuteSql(string.Format("delete from Sm_CaseInformation where ID={0}",_Id));
            if (iRowCount > 0)
            {
                sbResult.Append("[{\"msg\":\"删除成功\",\"data\":\"\",\"state\":\"0\"}]");
            }
            else
            {
                sbResult.Append("[{\"msg\":\"删除失败服务器处理出错\",\"data\":\"\",\"state\":\"1\"}]");
            }
            return sbResult.ToString();
        }
        #endregion

        #region 添加企业风采
        public string AddCompanyFiles(string _StrJson)
        {
            StringBuilder sbResult = new StringBuilder();
                string filepath = string.Empty;
                int iRowCount = 0;
                string strTemp=string.Empty;
                CommonJsonModel model = new CommonJsonModel(Regex.Replace(_StrJson, @"\r\n", ""));
                List<CommonJsonModel> lst = model.GetCollection();
                foreach (CommonJsonModel item in lst)
                {
                    #region 图片上传
                    byte[] imgStream = Convert.FromBase64String(item.GetValue("_Stream"));
                    if (!imgStream.Equals(""))
                    {
                        string imgname = DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
                        filepath = "/Upload/" + DateTime.Now.ToString("yyyyMM") + "/" + DateTime.Now.Date.Day.ToString().PadLeft(2,'0') + "/";
                        string webpath = System.Web.HttpContext.Current.Server.MapPath("/" + filepath);
                        if (!Directory.Exists(webpath))//不存在此目录则创建目录
                        {
                            Directory.CreateDirectory(webpath);
                        }
                        
                        FileStream fStream = new FileStream((webpath+imgname), FileMode.Create, FileAccess.Write);
                        BinaryWriter bw = new BinaryWriter(fStream);
                        bw.Write(imgStream);
                        bw.Close();
                        fStream.Close();
                        filepath = filepath + imgname;
                    }
                    #endregion
                    Model.Sm_CaseInformation modelCase = new Model.Sm_CaseInformation();
                    modelCase.Add_Time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    modelCase.Describe = item.GetValue("_Describe");
                    modelCase.MonadID = Convert.ToInt32(item.GetValue("_LoginId"));
                    modelCase.FilePath = filepath;
                    iRowCount = new Bll.Sm_CaseInformation().Add(modelCase);
                    if (iRowCount > 0)
                    {
                        DataSet dsFile = new Bll.DataHandler().GetList("Sm_CaseInformation", "ID,Name,FilePath,bigFilePath", "ID", 100, 1, false, false, "MonadID=" + item.GetValue("_LoginId"));
                        if (dsFile != null && dsFile.Tables[0].Rows.Count > 0)
                        {

                            DataTable dtFile = dsFile.Tables[0];
                            strTemp = EasyUIJsonHelper.TableToJson(dtFile);
                        }
                        sbResult.Append("[{\"msg\":\"添加成功\",\"data\":" + strTemp + ",\"state\":\"0\"}]");
                    }
                    else
                    {
                        sbResult.Append("[{\"msg\":\"添加失败,服务器处理出错\",\"data\":\"\",\"state\":\"1\"}]");
                    }
                }
            return sbResult.ToString();
        }
        #endregion

        #region 修改企业Logo
        public string UpdateCompanyLogo(string _StrJson)
        {
                StringBuilder sbResult = new StringBuilder();
                string strSql = "update Sm_Monad set LogoUrl='{0}' where ID={1}";
                string filepath = string.Empty;
                int iRowCount = 0;
                CommonJsonModel model = new CommonJsonModel(Regex.Replace(_StrJson, @"\r\n", ""));
                List<CommonJsonModel> lst = model.GetCollection();
                foreach (CommonJsonModel item in lst)
                {
                    #region 图片上传
                    byte[] imgStream = Convert.FromBase64String(item.GetValue("_Stream"));
                    string imgname = string.Empty;
                    if (!imgStream.Equals(""))
                    {
                        imgname = DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
                        filepath = "Upload/" + DateTime.Now.ToString("yyyyMM") + "/" + DateTime.Now.Date.Day + "/";
                        string webpath = System.Web.HttpContext.Current.Server.MapPath("/" + filepath);
                        if (!Directory.Exists(webpath))//不存在此目录则创建目录
                        {
                            Directory.CreateDirectory(webpath);
                        }
                        FileStream fStream = new FileStream(webpath, FileMode.Create, FileAccess.Write);
                        BinaryWriter bw = new BinaryWriter(fStream);
                        bw.Write(imgStream);
                        bw.Close();
                        fStream.Close();
                    }
                    #endregion
                    iRowCount = DbHelperSQL.ExecuteSql(string.Format(strSql, (filepath + imgname), item.GetValue("_LoginId")));
                    if (iRowCount > 0)
                    {
                        sbResult.Append("[{\"msg\":\"修改成功\",\"data\":\"\",\"state\":\"0\"}]");
                    }
                    else
                    {
                        sbResult.Append("[{\"msg\":\"修改失败\",\"data\":\"\",\"state\":\"1\"}]");
                    }
                }
               
            return sbResult.ToString();
        }
        #endregion

        #region 获取用户私信
        public string GetUserLetter(int _LoginId, int _Page,int _PageSize)
        {
            if (_Page == 0) { _Page = 1; }
            if (_PageSize == 0) { _PageSize = 10; }
            StringBuilder sbStr = new StringBuilder();
            DataSet ds = bll.GetList("TB_UsersLog", "id,title,content,read_status,send_time", "send_time", _PageSize, _Page, false, true, string.Format(" receiv_userid={0} and isdel=0", _LoginId));
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                sbStr.Append("[{\"msg\":\"查询成功，没匹配数据。\",\"data\":");
                sbStr.Append(EasyUIJsonHelper.TableToJson(dt));
                sbStr.Append(",\"state\":\"0\"}]");
            }
            else
            {
                sbStr.Append("[{\"msg\":\"查询成功，没匹配数据。\",\"data\":\"\",\"state\":\"0\"}]");
            }
            return sbStr.ToString();
        }
        #endregion

        #region 删除用户私信
        public string DeleteUserLetter(string _LetIds)
        {
            StringBuilder sbStr = new StringBuilder();
            if (_LetIds.Split(',').Length>0)
            {
                int iCt = 0;
                foreach (string LetId in _LetIds.Trim(',').Split(','))
                {
                    ZhouFu.Model.TB_UsersLog modelLog = new ZhouFu.Bll.TB_UsersLog().GetModel(Convert.ToInt32(LetId));
                    modelLog.isdel = 1;
                    new ZhouFu.Bll.TB_UsersLog().Update(modelLog);
                    iCt++;
                }
                if (iCt>0)
                {
                    sbStr.Append("[{\"msg\":\"删除成功。\",\"data\":\"\",\"state\":\"0\"}]");
                }
                else {
                    sbStr.Append("[{\"msg\":\"删除失败。\",\"data\":\"\",\"state\":\"1\"}]");
                }
            }
            else {
                sbStr.Append("[{\"msg\":\"删除失败,输入参数错误。\",\"data\":\"\",\"state\":\"2\"}]");
            }
            return sbStr.ToString();
        }
        #endregion

        #region 改变私信阅读状态
        public string UpdateLetReadStatus(int _LetterId)
        {
            StringBuilder sbResult = new StringBuilder();
            int iRowCount = DbHelperSQL.ExecuteSql(string.Format("update TB_UsersLog set read_status=1 where id={0}", _LetterId));
            if (iRowCount > 0)
            {
                sbResult.Append("[{\"msg\":\"修改成功\",\"data\":\"\",\"state\":\"0\"}]");
            }
            else
            {
                sbResult.Append("[{\"msg\":\"修改失败\",\"data\":\"\",\"state\":\"1\"}]");
            }
            return sbResult.ToString();
        }
        #endregion

        #region 获取验证码
        public string Captcha(string _LoginMobile)
        {
            StringBuilder sbResult = new StringBuilder();
            string temp = GetRandom();
            string content = "您的验证码是：" + temp + "。【汇财e家】";
            string statu = ZhouFu.Common.SendMessages.SendMe(_LoginMobile, content);
            if (statu == "Success")
            {
                sbResult.Clear();
                sbResult.Append("[{\"msg\":\"获取成功。\",\"data\":[{\"temp\":\"" + temp + "\"}],\"state\":\"0\"}]");
            }
            else
            {
                sbResult.Clear();
                sbResult.Append("[{\"msg\":\"获取失败。\",\"data\":[{\"temp\":\"12345\"}],\"state\":\"1\"}]");
            }
            return sbResult.ToString();
        }
        #endregion    

        #region 获取随机数
        public string GetRandom()
        {
            Random rd = new Random();
            string strRandom = string.Empty;
            string[] s = { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
            for (int i = 0; i < 4; i++)
            {
                strRandom += s[rd.Next(10)].ToString();
            }
            return strRandom;
        }
        #endregion

        #region 获取我的推荐链接
        public string GetRecommendUrl(int _LoginId)
        {
            StringBuilder sbStr = new StringBuilder();
            sbStr.Append("[{\"msg\":\"获取成功。\",\"data\":[{\"Url\":\"Register.aspx?token=" + Base64Protector.Base64Code(_LoginId.ToString()) + "\"}],\"state\":\"0\"}]");
            return  sbStr.ToString();
        }
        #endregion

        #region 提现申请
        public string InfoMoneyDetails(int _LoginId, int _BankId, string _BankCard, string _Money, string _DealPwd)
        {
            StringBuilder sbStr = new StringBuilder();
            sbStr.Append("[{\"msg\":\"提交失败,参数错误。\",\"data\":\"\",\"state\":\"2\"}]");
            if (_LoginId > 0)
            {
                ZhouFu.Model.sys_Manager mModel = new ZhouFu.Bll.sys_Manager().GetModel(_LoginId);
                if (DESEncrypt.GetStringMD5(_DealPwd) != mModel.DealPassword)
                {
                    sbStr.Clear();
                    sbStr.Append("[{\"msg\":\"提交失败,支付密码不正确。\",\"data\":\"\",\"state\":\"1\"}]");
                }
                else {
                    if (Convert.ToDecimal(_Money) > (mModel.AccountBalance - mModel.DJAccountBalance))
                    {
                        sbStr.Clear();
                        sbStr.Append("[{\"msg\":\"提交失败,可用有效余额不足。\",\"data\":\"\",\"state\":\"1\"}]");
                    }
                    else
                    {
                        #region 修改用户冻结资金
                        mModel.DJAccountBalance = mModel.DJAccountBalance + Convert.ToDecimal(_Money);
                        #endregion

                        #region 发送私信
                        ZhouFu.Model.TB_UsersLog logModel = new Model.TB_UsersLog();
                        logModel.title = "提现申请";
                        logModel.content = "尊敬的用户您好，您的提现" + _Money + "申请已成功，金额会于T+1个交易日返还于您的账户中，请时刻关注账户个人中心余额明细。</br>感谢您对汇财e家一如既往的支持，希望我们的服务能够带来您财富的增长。";
                        logModel.send_userid = 38;
                        logModel.send_time = DateTime.Now;
                        logModel.receiv_userid = mModel.ID;
                        #endregion

                        

                        int obj = 0;
                        if (obj>0)
                        {
                        sbStr.Clear();
                        sbStr.Append("[{\"msg\":\"提交成功。\",\"data\":\"\",\"state\":\"1\"}]");
                        }
                    }
                }
                
            }
            return sbStr.ToString();
        }
        #endregion
    }
}
