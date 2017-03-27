using cn.jpush.api.push.mode;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using WebSystem.AppCode;
using WebSystem.Systestcomjun.AppCode;
using ZhongLi.Api;
using ZhongLi.Common;

namespace WebSystem.App
{
    /// <summary>
    /// SerAjax 的摘要说明
    /// </summary>
    public class SerAjax : IHttpHandler
    {
        string strResult = "111";
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string action = context.Request["action"];
            try
            {
                switch (action)
                {
                    #region 登陆注册
                    case "login"://登陆
                        login(context);
                        break;
                    case "OtherLogin":
                        OtherLogin(context);
                        break;
                    case "OtherLoginAddPhone":
                        OtherLoginAddPhone(context);
                        break;
                    //case "regist"://保存个人信息
                    //    SavePersonInfo(context);
                    //    break;
                    case "phonecode"://注册发送手机验证码
                        phonecode(context);
                        break;
                    case "checkphonecode"://注册验证手机验证码
                        checkphonecode(context);
                        break;
                    case "savepwd":
                        savepwd(context);
                        break;
                    case "saveInfo":
                        saveInfo(context);
                        break;
                    #endregion
                    #region 个人资料
                    case "getRyToken"://融云聊天token
                        getRyToken(context);
                        break;
                    case "getRyPersons"://融云聊天token
                        getRyPersons(context);
                        break;
                    case "getRyPerson"://融云聊天token
                        getRyPerson(context);
                        break;
                    case "getSerUserInfo":
                        getSerUserInfo(context);
                        break;
                    case "saveSerUser":
                        saveSerUser(context);
                        break;
                    case "saveDescribe":
                        saveDescribe(context);
                        break;
                    case "setPhoto":
                        setPhoto(context);
                        break;
                    case "Pwdcode"://修改密码 获取手机验证码
                        Pwdcode(context);
                        break;
                    case "modPassword"://修改密码 验证验证码并修改密码
                        modPassword(context);
                        break;
                    case "EditPhonecode"://修改手机号 获取手机验证码
                        EditPhonecode(context);
                        break;
                    case "modPhone"://修改手机号 验证验证码并修改手机号码
                        modPhone(context);
                        break;
                    case "FindPwdPhonecode":
                        FindPwdPhonecode(context);
                        break;
                    case"findPwdCheckCode":
                        findPwdCheckCode(context);
                        break;
                    #region 工作经历
                    case "getSerUserWork":
                        getSerUserWork(context);
                        break;
                    case "getSerUserWorkDetail":
                        getSerUserWorkDetail(context);
                        break;
                    case "saveSerUserWork":
                        saveSerUserWork(context);
                        break;
                    case "delSerUserWork":
                        delSerUserWork(context);
                        break;
                    #endregion

                    #region 教育经历
                    case "getSerUserEdu":
                        getSerUserEdu(context);
                        break;
                    case "getSerUserEduDetail":
                        getSerUserEduDetail(context);
                        break;
                    case "saveSerUserEdu":
                        saveSerUserEdu(context);
                        break;
                    case "delSerUserEdu":
                        delSerUserEdu(context);
                        break;
                    #endregion

                    #region 评价
                    case "SerUserEvlList"://给人才经纪人评论
                        SerUserEvlList(context);
                        break;
                    case "AddSerUserEvl"://人才经纪人的评论列表
                        AddSerUserEvl(context);
                        break;
                    case "PersonEvaAdd"://给求职者评论
                        PersonEvaAdd(context);
                        break;
                    case "PersonEvaList"://得到求职者评论列表
                        PersonEvaList(context);
                        break;
                    case "PersonOrderEvaCount":
                        PersonOrderEvaCount(context);
                        break;
                    case "SerUserOrderEvaCount":
                        SerUserOrderEvaCount(context);
                        break;
                    #endregion
                    #region 人才经纪人标签
                    case "getSerUserTag":
                        getSerUserTag(context);
                        break;
                    case "getSerUserTagDetail":
                        getSerUserTagDetail(context);
                        break;
                    case "saveSerUserTag":
                        saveSerUserTag(context);
                        break;
                    case "delSerUserTag":
                        delSerUserTag(context);
                        break;
                    #endregion
                    #region 切换账号
                    case "ChangeAccount":
                        ChangeAccount(context);
                        break;
                    #endregion
                    #endregion
                    #region 悬赏
                    case "getMyReward"://我的悬赏详情
                        getMyReward(context);
                        break;
                    case "getMyRewardDetail":
                        getMyRewardDetail(context);
                        break;
                    case "getRewardList":
                        getRewardList(context);
                        break;
                    case "getRewardDetail":
                        getRewardDetail(context);
                        break;
                    case "MatReward":
                        MatReward(context);
                        break;
                    #endregion
                    #region 省市区
                    case "allcity":
                        allcity(context);
                        break;
                    case "shengshiqu":
                        shengshiqu(context);
                        break;
                    #endregion
                    #region 身份认证
                    case "IdCardApprove":
                        IdCardApprove(context);
                        break;
                    case "setIdcardImg":
                        setIdcardImg(context);
                        break;
                    case "setSerImg":
                        setSerImg(context);
                        break;
                    #endregion
                    #region 职位
                    case "checkPost":
                        checkPost(context);
                        break;
                    case "HomeMyPost":
                        HomeMyPost(context);
                        break;
                    case "SerUserPost":
                        SerUserPost(context);
                        break;
                    case "saveSerUserPost":
                        saveSerUserPost(context);
                        break;
                    case "getSerUserPostDetail":
                        getSerUserPostDetail(context);
                        break;
                    case "delSerUserPost":
                        delSerUserPost(context);
                        break;
                    case "getSerUserPost":
                        getSerUserPost(context);
                        break;
                    #endregion
                    #region 订单
                    case "HomeMyOrder":
                        HomeMyOrder(context);
                        break;
                    case"SerUserEntryPost":
                        SerUserEntryPost(context);
                        break;
                    case "SerUserFailPost":
                        SerUserFailPost(context);
                        break;
                    case"SerUserOrder":
                        SerUserOrder(context);
                        break;
                    case"getOrderDetail":
                        getOrderDetail(context);
                        break;
                    case "setOrderFail"://确认订单失败
                        setOrderFail(context);
                        break;
                    case "setOrderSus"://人才已经入职
                        setOrderSus(context);
                        break;
                    case "PersonOrderList":
                        PersonOrderList(context);
                        break;
                    case "PersonOrderDetail":
                        PersonOrderDetail(context);
                        break;
                    case "setPersonRewNoMat":
                        setPersonRewNoMat(context);
                        break;
                    case "setPersonRewMat":
                        setPersonRewMat(context);
                        break;
                    #endregion
                    #region 朋友
                    case "RefuseApply":
                        RefuseApply(context);
                        break;
                    case "AgreeApply":
                        AgreeApply(context);
                        break;
                    case "IsFriend":
                        IsFriend(context);
                        break;
                    case　"ApplyFriend":
                        ApplyFriend(context);
                        break;
                    case "DeleteFriend":
                        DeleteFriend(context);
                        break;
                    case "SerUserFriend":
                        SerUserFriend(context);
                        break;
                    #endregion
                    #region 消息提醒
                    case "getMsgCount":
                        getMsgCount(context);
                        break;
                    case "getMsgCountByType":
                        getMsgCountByType(context);
                        break;
                    case "getMsgByType":
                        getMsgByType(context);
                        break;
                    #endregion
                    #region 交易记录
                    case "getSerUserRecord":
                        getSerUserRecord(context);
                        break;
                    #endregion
                    #region 余额
                    case "getBalance":
                        getBalance(context);
                        break;
                    case "AddPresent":
                        AddPresent(context);
                        break;
                    case "getNowPre":
                        getNowPre(context);
                        break;
                    case"getMyPre":
                        getMyPre(context);
                        break;
                    case "getMyPreDetail":
                        getMyPreDetail(context);
                        break;
                    #endregion
                    #region 版本
                    case "getEditeion":
                        getEditeion(context);
                        break;
                    #endregion
                    case "getALlPost":
                        getALlPost(context);
                        break;
                }
            }
            catch (Exception ex)
            {
                strResult = ex.Message;
            }
            context.Response.Write(strResult);
        }

        #region 登陆
        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="context"></param>
        private void login(HttpContext context)
        {
            try
            {
                string phone = context.Request.Form["phone"];
                string password = DESEncrypt.GetStringMD5(context.Request.Form["password"]);
                int state = new ZhongLi.BLL.ServerUser().checklogin(phone, password);
                if (state == 0)
                {
                    DataTable dt = new ZhongLi.BLL.ServerUser().findinfo("SerUserID,RealName,PhotoImg,Flag,IDCardImg,SerImg,IDCardState,SerImgState,ImOpenID", " Phone='" + phone + "'");
                    string flag = "";
                    strResult = "{\"state\":" + state + ",\"serveruser\":{\"seruserid\":" + dt.Rows[0]["SerUserID"] + ",\"realname\":\"" + dt.Rows[0]["RealName"] + "\",\"PhotoImg\":\"" + dt.Rows[0]["PhotoImg"] + "\",\"Flag\":" + dt.Rows[0]["Flag"] + ",\"token\":\"" + dt.Rows[0]["ImOpenID"] + "\"}}";
                }
                else
                {
                    strResult = "{\"state\":" + state + ",\"serveruser\":\"\"}";
                }
            }
            catch (Exception ex)
            {
                strResult = ex.Message;
            }
        }

        private void OtherLogin(HttpContext context)
        {
            string loginType = context.Request.Form["loginType"];
            string OpenID = context.Request.Form["OpenID"];
            string NikeName = context.Request.Form["NikeName"];
            string Sex = context.Request.Form["Sex"];
            string Photo = context.Request.Form["Photo"];
            string where = "";
            switch (loginType)
            {
                case"wx":
                    where = " WxOpenID='"+OpenID+"'";
                    break;
                case "wb":
                    where = " WbOpenID='" + OpenID + "'";
                    break;
                case "qq":
                    where = " QQOpenID='" + OpenID + "'";
                    break;
            }
            DataTable dt = new ZhongLi.BLL.ServerUser().findinfo("SerUserID,RealName,PhotoImg,Flag,IDCardImg,Phone,SerImg,IDCardState,SerImgState,ImOpenID,Password", where);
            if (dt.Rows.Count > 0)
            {
                string pwd = "0";
                if (dt.Rows[0]["Password"].ToString() != "")
                {
                    pwd = "1";
                }
                strResult = "{\"state\":0,\"serveruser\":{\"seruserid\":" + dt.Rows[0]["SerUserID"] + ",\"realname\":\"" + dt.Rows[0]["RealName"] + "\",\"PhotoImg\":\"" + dt.Rows[0]["PhotoImg"] + "\",\"Flag\":" + dt.Rows[0]["Flag"] + ",\"token\":\"" + dt.Rows[0]["ImOpenID"] + "\",\"pwd\":\"" + pwd + "\",\"phone\":\""+dt.Rows[0]["Phone"]+"\"}}";
            }
            else
            {
                ZhongLi.Model.ServerUser s = new ZhongLi.Model.ServerUser();
                s.RealName = NikeName;
                s.Sex = bool.Parse(Sex);
                string photourl = "/upload/seruser/" + Guid.NewGuid() + ".png";
                string imgFileName = context.Server.MapPath(photourl);
                ImgDownLoad.DownloadPicture(Photo, imgFileName, 300);
                s.PhotoImg = photourl;
                //s.Phone = phone;
                s.RegTime = DateTime.Now;
                s.Balance = 0;
                s.Flag = 0;
                s.Password = "";
                switch (loginType)
                {
                    case "wx":
                        s.WxOpenID = OpenID;
                        break;
                    case "qq":
                        s.QQOpenID = OpenID;
                        break;
                    case "wb":
                        s.WbOpenID = OpenID;
                        break;
                }
                int SerUserID = new ZhongLi.BLL.ServerUser().Add(s);
                if (SerUserID > 0)
                {
                    strResult = "{\"state\":1,\"SerUserID\":" + SerUserID + ",\"Photo\":\"" + photourl + "\"}";
                }
                else
                {
                    strResult = "{\"state\":2}";
                }
            }

        }
        private void OtherLoginAddPhone(HttpContext context)
        {
            string phone = context.Request.Form["phone"];
            string code = context.Request.Form["code"];
            string OpenID = context.Request.Form["OpenID"];
            string NikeName = context.Request.Form["NikeName"];
            string Sex = context.Request.Form["Sex"];
            string Photo = context.Request.Form["Photo"];
            string loginType = context.Request.Form["loginType"];
            if (new ZhongLi.BLL.PhoneCode().CheckPhoneCode(phone, code, "0"))
            {
                ZhongLi.Model.ServerUser s = new ZhongLi.Model.ServerUser();
                s.RealName = NikeName;
                s.Sex = bool.Parse(Sex);
                string photourl = "/upload/seruser/" + Guid.NewGuid() + ".png";
                string imgFileName = context.Server.MapPath(photourl);
                ImgDownLoad.DownloadPicture(Photo, imgFileName, 300);
                s.PhotoImg = photourl;
                s.Phone = phone;
                s.RegTime = DateTime.Now;
                s.Balance = 0;
                switch (loginType)
                {
                    case "wx":
                        s.WxOpenID = OpenID;
                        break;
                    case "qq":
                        s.QQOpenID = OpenID;
                        break;
                    case "wb":
                        s.WbOpenID = OpenID;
                        break;
                }
                int SerUserID = new ZhongLi.BLL.ServerUser().Add(s);
                if (SerUserID <= 0)
                {
                    strResult = "{\"SerUserID\":" + SerUserID + ",\"Photo\":\""+photourl+"\"}";
                }
                else
                {
                    strResult = "{\"SerUserID\":0}";
                }
            }
            else
            {
                strResult = "{\"SerUserID\":-1}";
            }
        }
        #endregion

        #region 注册
        /// <summary>
        /// 发送手机验证码
        /// </summary>
        /// <param name="context"></param>
        private void phonecode(HttpContext context)
        {
            string phone = context.Request.QueryString["phone"];
            //验证手机号码是否已存在
            if (new ZhongLi.BLL.ServerUser().checkphone(phone))
            {
                strResult = "{\"state\":1}";
            }
            else
            {
                string code = getphonecode();
                ZhongLi.Model.PhoneCode pc = new ZhongLi.Model.PhoneCode();
                pc.Phone = phone;
                pc.VerCode = code;
                pc.SendTime = DateTime.Now;
                pc.SendType = 0;
                //发送验证码
                MessageServices.SendRegistrationMessage(phone,code);
                //数据库
                new ZhongLi.BLL.PhoneCode().Add(pc);
                strResult = "{\"state\":0}";
            }
        }
        //得到6位随机数
        private string getphonecode()
        {
            Random random = new Random();
            string str = "";
            //循环的次数     
            int Nums = 6;
            while (Nums > 0)
            {
                int i = random.Next(0, 9);
                str += i.ToString();
                Nums -= 1;
            }
            return str;
        }

        /// <summary>
        /// 注册验证手机验证码 成功则添加账号
        /// </summary>
        /// <param name="context"></param>
        private void checkphonecode(HttpContext context)
        {
            try
            {
                string phone = context.Request.Form["phone"];
                string code = context.Request.Form["phonecode"];
                if (new ZhongLi.BLL.PhoneCode().CheckPhoneCode(phone, code, "0"))
                {
                    ZhongLi.Model.ServerUser user = new ZhongLi.Model.ServerUser();
                    user.Phone = phone;
                    user.Flag = 0;
                    user.IDCardState = 0;
                    user.SerImgState = 0;
                    user.Balance = 0;
                    user.RegTime = DateTime.Now;
                    int SerUserID = new ZhongLi.BLL.ServerUser().Add(user);
                    if (SerUserID > 0)
                    {
                        strResult = "{\"state\":0,\"seruserid\":" + SerUserID + "}";
                    }
                    else
                    {
                        strResult = "{\"state\":2,\"seruserid\":0}";
                    }
                }
                else
                {
                    strResult = "{\"state\":1}";
                }
            }
            catch (Exception ex)
            {
                strResult = ex.Message;
            }
        }

        /// <summary>
        /// 注册填写密码
        /// </summary>
        /// <param name="context"></param>
        private void savepwd(HttpContext context)
        {
            string password = context.Request.Form["password"];
            int seruserid = Convert.ToInt32(context.Request.Form["seruserid"]);
            if (new ZhongLi.BLL.ServerUser().editPwd(DESEncrypt.GetStringMD5(password), seruserid))
            {
                strResult = "{\"state\":0}";
            }
            else
            {
                strResult = "{\"state\":1}";
            }
        }
        /// <summary>
        /// 注册保存信息
        /// </summary>
        /// <param name="context"></param>
        private void saveInfo(HttpContext context)
        {
            int SerUserID = Convert.ToInt32(context.Request.Form["SerUserID"]);
            ZhongLi.Model.ServerUser seruser = new ZhongLi.BLL.ServerUser().GetModel(SerUserID);
            seruser.RealName = context.Request.Form["RealName"];
            seruser.Position = context.Request.Form["Position"];
            seruser.Email = context.Request.Form["Email"];
            seruser.Company = context.Request.Form["Company"];
            if (new ZhongLi.BLL.ServerUser().Update(seruser))
            {
                strResult = "{\"state\":0}";
            }
            else
            {
                strResult = "{\"state\":1}";
            }
        }
        #endregion

        #region 个人资料
        
        /// <summary>
        /// 得到融云聊天token
        /// </summary>
        /// <param name="context"></param>
        private void getRyToken(HttpContext context)
        {
            int seruserid = Convert.ToInt32(context.Request.Form["seruserid"]);
            string realname = context.Request.Form["realname"];
            string photo = context.Request.Form["photo"];
            RYToken rytoken = new RYToken();
            string tokenjson = rytoken.getToken("s" + seruserid, realname, photo);
            JObject obj = JsonConvert.DeserializeObject(tokenjson) as JObject;
            if (obj["code"].ToString().Equals("200"))
            {
                string token = obj["token"].ToString();
                new ZhongLi.BLL.ServerUser().editImOpenID(seruserid, token);
                strResult = "{\"state\":0,\"token\":\"" + token + "\"}";
            }
            else
            {
                strResult = "{\"state\":1,\"code\":\"" + obj["code"] + "\"}";
            }
        }
        /// <summary>
        /// 融云聊天 得到用户信息多个用户信息
        /// </summary>
        /// <param name="context"></param>
        private void getRyPersons(HttpContext context)
        {
            string perid = context.Request.Form["userids"].Replace("p", "").Replace("s","");
            DataTable dt = new ZhongLi.BLL.Person().findField("('p'+cast(PerID as varchar(8))) as userid,RealName as realname,Photo as avatar", perid);
            strResult = JsonConvert.SerializeObject(dt); 
        }
        /// <summary>
        /// 融云聊天 得到用户信息
        /// </summary>
        /// <param name="context"></param>
        private void getRyPerson(HttpContext context)
        {
            string perid = context.Request.Form["userid"].Replace("p", "").Replace("s", "");
            DataTable dt = new ZhongLi.BLL.Person().findField("('p'+cast(PerID as varchar(8))) as userid,RealName as realname,Photo as avatar", Convert.ToInt32(perid));
            strResult = "{\"userid\":\"" + dt.Rows[0]["userid"] + "\",\"avatar\":\"" + dt.Rows[0]["avatar"] + "\",\"realname\":\"" + dt.Rows[0]["realname"] + "\"}";
        }

        /// <summary>
        /// 得到个人资料
        /// </summary>
        /// <param name="context"></param>
        private void getSerUserInfo(HttpContext context)
        {
            int SerUserID = Convert.ToInt32(context.Request.QueryString["SerUserID"]);
            ZhongLi.Model.ServerUser seruser = new ZhongLi.BLL.ServerUser().GetModel(SerUserID);
            strResult = JsonConvert.SerializeObject(seruser);
        }
        /// <summary>
        /// 上传头像
        /// </summary>
        /// <param name="context"></param>
        private void setPhoto(HttpContext context)
        {
            try
            {
                //Regex RegImgBase64 = new Regex("^data:\\s*image/(\\w+);base64,([\\w/=\\+]*)$");
                string photo64 = context.Request.Form["Photo"];
                string SerUserID = context.Request.Form["SerUserID"];
                string FileUrl = "";
                if (photo64 != "")
                {
                    byte[] buffer = Convert.FromBase64String(photo64);
                    FileUrl = "/upload/seruser/" + Guid.NewGuid().ToString() + ".png";
                    string sFilePath = context.Server.MapPath(FileUrl);
                    File.WriteAllBytes(sFilePath, buffer);
                }
                if (new ZhongLi.BLL.ServerUser().savePhoto(SerUserID, FileUrl))
                {
                    strResult = "{\"state\":0,\"Photo\":\"" + FileUrl + "\"}";
                }
                else
                {
                    strResult = "{\"state\":1}";
                }
            }
            catch (Exception ex)
            {
                strResult = ex.Message;
            }
        }
        /// <summary>
        /// 保存个人资料
        /// </summary>
        /// <param name="context"></param>
        private void saveSerUser(HttpContext context)
        {
            try
            {
                string SerUserID = context.Request.Form["SerUserID"];
                string RealName = context.Request.Form["RealName"];
                string Sex = context.Request.Form["Sex"]=="男"?"True":"False";
                string Trade = context.Request.Form["Trade"];
                string Company = context.Request.Form["Company"];
                string Position = context.Request.Form["Position"];
                string WorkCity = context.Request.Form["WorkCity"];
                string Address = context.Request.Form["Address"];
                string Email = context.Request.Form["Email"];
                if (new ZhongLi.BLL.ServerUser().saveSerUser(RealName, Sex, Trade, Company, Position, WorkCity, Address, Email, SerUserID))
                {
                    strResult = "{\"state\":0}";
                }
                else
                {
                    strResult = "{\"state\":1}";
                }
            }catch(Exception ex){
                strResult = strResult = "{\"state\":\"" +ex.Message+"\",photo:\"\"}";
            }
        }
        /// <summary>
        /// 保存自我介绍
        /// </summary>
        /// <param name="context"></param>
        private void saveDescribe(HttpContext context)
        {
            string Describe = context.Request.Form["Describe"];
            string SerUserID=context.Request.Form["SerUserID"];
            if (new ZhongLi.BLL.ServerUser().saveDescribe(SerUserID, Describe))
            {
                strResult = "{\"state\":0}";
            }
            else
            {
                strResult = "{\"state\":1}";
            }
        }

        #region 修改密码
        /// <summary>
        /// 修改密码 发送验证码
        /// </summary>
        /// <param name="context"></param>
        private void Pwdcode(HttpContext context)
        {
            string SerUserID = context.Request.QueryString["SerUserID"];
            string phone = new ZhongLi.BLL.ServerUser().getPhone(SerUserID);
            string code = getphonecode();
            ZhongLi.Model.PhoneCode pc = new ZhongLi.Model.PhoneCode();
            pc.Phone = phone;
            pc.VerCode = code;
            pc.SendTime = DateTime.Now;
            pc.SendType = 1;
            //发送验证码
            MessageServices.SendCaptchaMessage(phone, code);
            //数据库
            new ZhongLi.BLL.PhoneCode().Add(pc);
            strResult = "{\"state\":0}";
        }
        /// <summary>
        /// 修改密码 获取验证码
        /// </summary>
        /// <param name="context"></param>
        private void modPassword(HttpContext context)
        {
            string Password = context.Request.Form["password"];
            string SerUserID = context.Request.Form["SerUserID"];
            string code = context.Request.Form["code"];
            string phone = new ZhongLi.BLL.ServerUser().getPhone(SerUserID);
            if (new ZhongLi.BLL.PhoneCode().CheckPhoneCode(phone, code, "1"))
            {
                if (new ZhongLi.BLL.ServerUser().editPwd(DESEncrypt.GetStringMD5(Password), Convert.ToInt32(SerUserID)))
                {
                    strResult = "{\"state\":0}";
                }
                else
                {
                    strResult = "{\"state\":1}";
                }
            }
            else
            {
                strResult = "{\"state\":2}";
            }
        }
        #endregion
        #region 修改手机号码
        /// <summary>
        /// 修改手机号 发送验证码
        /// </summary>
        /// <param name="context"></param>
        private void EditPhonecode(HttpContext context)
        {
            string phone = context.Request.QueryString["phone"];
            //验证手机号码是否已存在
            if (new ZhongLi.BLL.ServerUser().checkphone(phone))
            {
                strResult = "{\"state\":1}";
            }
            else
            {
                string code = getphonecode();
                ZhongLi.Model.PhoneCode pc = new ZhongLi.Model.PhoneCode();
                pc.Phone = phone;
                pc.VerCode =code;
                pc.SendTime = DateTime.Now;
                pc.SendType = 2;
                //发送验证码
                MessageServices.SendPublicMessage(phone, code);
                //数据库
                new ZhongLi.BLL.PhoneCode().Add(pc);
                strResult = "{\"state\":0}";
            }
        }
        /// <summary>
        /// 修改手机号 获取验证码
        /// </summary>
        /// <param name="context"></param>
        private void modPhone(HttpContext context)
        {
            string SerUserID = context.Request.Form["SerUserID"];
            string code = context.Request.Form["code"];
            string phone = context.Request.Form["phone"];
            if (new ZhongLi.BLL.PhoneCode().CheckPhoneCode(phone, code, "2"))
            {
                if (new ZhongLi.BLL.ServerUser().ModPhone(phone, SerUserID))
                {
                    strResult = "{\"state\":0}";
                }
                else
                {
                    strResult = "{\"state\":1}";
                }
            }
            else
            {
                strResult = "{\"state\":2}";
            }
        }
        #endregion
        #region 找回密码

        /// <summary>
        /// 找回密码 发送验证码
        /// </summary>
        /// <param name="context"></param>
        private void FindPwdPhonecode(HttpContext context)
        {
            string phone = context.Request.QueryString["phone"];
            //验证手机号码是否已存在
            if (new ZhongLi.BLL.ServerUser().checkphone(phone))
            {
                string code = getphonecode();
                ZhongLi.Model.PhoneCode pc = new ZhongLi.Model.PhoneCode();
                pc.Phone = phone;
                pc.VerCode = code;
                pc.SendTime = DateTime.Now;
                pc.SendType = 3;
                //发送验证码
                MessageServices.SendCaptchaMessage(phone, code);
                //数据库
                new ZhongLi.BLL.PhoneCode().Add(pc);
                strResult = "{\"state\":0}";
                
            }
            else
            {
                strResult = "{\"state\":1}";
            }
        }
        /// <summary>
        /// 找回密码 验证并返回主键ID
        /// </summary>
        /// <param name="context"></param>
        private void findPwdCheckCode(HttpContext context)
        {
            string phone=context.Request.Form["phone"];
            string code=context.Request.Form["code"];
            if (new ZhongLi.BLL.PhoneCode().CheckPhoneCode(phone, code, "3"))
            {
                DataTable dt = new ZhongLi.BLL.ServerUser().findinfo("SerUserID"," Phone='"+phone+"'");
                strResult = "{\"state\":0,\"SerUserID\":"+dt.Rows[0]["SerUserID"]+"}";
            }
            else
            {
                strResult = "{\"state\":1}";
            }
        }
        #endregion
        #region 余额
        private void getBalance(HttpContext context)
        {
            int seruserid = Convert.ToInt32(context.Request["seruserid"]);
            DataTable dt = new ZhongLi.BLL.ServerUser().findField("Balance", seruserid);
            strResult = "{\"Balance\":"+dt.Rows[0][0]+"}";
        }
        #endregion
        #region 切换账号
        private void ChangeAccount(HttpContext context)
        {
            int SerUserID = Convert.ToInt32(context.Request.Form["SerUserID"]);
            strResult = new ZhongLi.BLL.Person().PersonFromSerUser(SerUserID);
        }
        #endregion
        #region 工作经历
        /// <summary>
        /// 得到人才经纪人工作经历列表
        /// </summary>
        /// <param name="context"></param>
        private void getSerUserWork(HttpContext context)
        {
            string SerUserID = context.Request.QueryString["SerUserID"];
            DataSet ds = new ZhongLi.BLL.ServerUser_Work().GetList(" SerUserID="+SerUserID);
            strResult = JsonConvert.SerializeObject(ds.Tables[0]);
        }
        /// <summary>
        /// 得到人才经纪人经历列表详情
        /// </summary>
        /// <param name="context"></param>
        private void getSerUserWorkDetail(HttpContext context)
        {
            int SerUserWorkID = Convert.ToInt32(context.Request.QueryString["SerUserWorkID"]);
            ZhongLi.Model.ServerUser_Work seruserwork = new ZhongLi.BLL.ServerUser_Work().GetModel(SerUserWorkID);
            strResult = JsonConvert.SerializeObject(seruserwork);
        }
        /// <summary>
        /// 保存人才经纪人工作经历
        /// </summary>
        /// <param name="context"></param>
        private void saveSerUserWork(HttpContext context)
        {
            ZhongLi.Model.ServerUser_Work serUserWork = new ZhongLi.Model.ServerUser_Work();
            serUserWork.SerUserWorkID = Convert.ToInt32(context.Request.Form["SerUserWorkID"]);
            serUserWork.SerUserID = Convert.ToInt32(context.Request.Form["SerUserID"]);
            serUserWork.Company = context.Request.Form["Company"];
            serUserWork.Position = context.Request.Form["Position"];
            serUserWork.StartTime=context.Request.Form["StartTime"];
            serUserWork.EndTime = context.Request.Form["EndTime"];
            serUserWork.WorkDes = context.Request.Form["WorkDes"];
            serUserWork.CreateTime = DateTime.Now;
            if (serUserWork.SerUserWorkID <= 0)
            {
                if (new ZhongLi.BLL.ServerUser_Work().Add(serUserWork) > 0)
                {
                    strResult = "{\"state\":0}";
                }
                else
                {
                    strResult = "{\"state\":1}";
                }
            }
            else
            {
                if (new ZhongLi.BLL.ServerUser_Work().Update(serUserWork))
                {
                    strResult = "{\"state\":0}";
                }
                else
                {
                    strResult = "{\"state\":1}";
                }
            }
           
        }
        /// <summary>
        /// 删除工作经历
        /// </summary>
        /// <param name="context"></param>
        private void delSerUserWork(HttpContext context)
        {
            int SerUserWorkID = Convert.ToInt32(context.Request.Form["SerUserWorkID"]);
            if (new ZhongLi.BLL.ServerUser_Work().Delete(SerUserWorkID))
            {
                strResult = "{\"state\":0}";
            }
            else
            {
                strResult = "{\"state\":1}";
            }
        }
        #endregion
        #region 教育经历
        /// <summary>
        /// 得到教育经历列表
        /// </summary>
        /// <param name="context"></param>
        private void getSerUserEdu(HttpContext context)
        {
            string SerUserID=context.Request.QueryString["SerUserID"];
            DataSet ds = new ZhongLi.BLL.ServerUser_Education().GetList(" SerUserID="+SerUserID);
            strResult = JsonConvert.SerializeObject(ds.Tables[0]);
        }
        /// <summary>
        /// 得到教育简历详情
        /// </summary>
        /// <param name="context"></param>
        private void getSerUserEduDetail(HttpContext context)
        {
            int SerUserEduID = Convert.ToInt32(context.Request.QueryString["SerUserEduID"]);
            ZhongLi.Model.ServerUser_Education serUserEdu=new ZhongLi.BLL.ServerUser_Education().GetModel(SerUserEduID);
            strResult = JsonConvert.SerializeObject(serUserEdu);
        }
        /// <summary>
        /// 保存教育经历信息
        /// </summary>
        /// <param name="context"></param>
        private void saveSerUserEdu(HttpContext context)
        {
            ZhongLi.Model.ServerUser_Education serUserEdu = new ZhongLi.Model.ServerUser_Education();
            serUserEdu.SerUserEduID = Convert.ToInt32(context.Request.Form["SerUserEduID"]);
            serUserEdu.SerUserID = Convert.ToInt32(context.Request.Form["SerUserID"]);
            serUserEdu.SchoolName = context.Request.Form["SchoolName"];
            serUserEdu.Major = context.Request.Form["Major"];
            serUserEdu.Education = context.Request.Form["Education"];
            serUserEdu.StartTime = context.Request.Form["StartTime"];
            serUserEdu.EndTime=context.Request.Form["EndTime"];
            serUserEdu.CreateTime = DateTime.Now;
            serUserEdu.EduDes = context.Request.Form["EduDes"];
            if (serUserEdu.SerUserEduID <= 0)
            {
                if (new ZhongLi.BLL.ServerUser_Education().Add(serUserEdu) > 0)
                {
                    strResult = "{\"state\":0}";
                }
                else
                {
                    strResult = "{\"state\":1}";
                }
            }
            else
            {
                if (new ZhongLi.BLL.ServerUser_Education().Update(serUserEdu))
                {
                    strResult = "{\"state\":0}";
                }
                else
                {
                    strResult = "{\"state\":1}";
                }
            }
        }
        /// <summary>
        /// 删除教育经历
        /// </summary>
        /// <param name="context"></param>
        private void delSerUserEdu(HttpContext context)
        {
            int SerUserEduID = Convert.ToInt32(context.Request.Form["SerUserEduID"]);
            if (new ZhongLi.BLL.ServerUser_Education().Delete(SerUserEduID))
            {
                strResult = "{\"state\":0}";
            }
            else
            {
                strResult = "{\"state\":1}";
            }
        }
        #endregion
        #region 评论
        /// <summary>
        /// 评论列表
        /// </summary>
        /// <param name="context"></param>
        private void SerUserEvlList(HttpContext context)
        {
            int SerUserID = Convert.ToInt32(context.Request.QueryString["SerUserID"]);
            int PageIndex=Convert.ToInt32(context.Request.QueryString["PageIndex"]);
            DataTable dt = new ZhongLi.BLL.ServerUser_Evaluate().GetListByPage(" SerUserID=" + SerUserID + "", "EvaluateTime desc",(PageIndex-1)*20+1,PageIndex*20).Tables[0];
            strResult = JsonConvert.SerializeObject(dt);
        }
        /// <summary>
        /// 添加评论
        /// </summary>
        /// <param name="context"></param>
        private void AddSerUserEvl(HttpContext context)
        {
            int SerUserID = Convert.ToInt32(context.Request.Form["SerUserID"]);
            string RealName=context.Request.Form["RealName"];
            string EvaluateCon = context.Request.Form["EvaluateCon"];
            int PerID = Convert.ToInt32(context.Request.Form["PerID"]);
            string PerRealName=context.Request.Form["PerRealName"];
            int EvaLevel = Convert.ToInt32(context.Request.Form["EvaLevel"]);
            int OrderID = Convert.ToInt32(context.Request.Form["OrderID"]);
            int EvaluateType = Convert.ToInt32(context.Request.Form["EvaluateType"]);
            ZhongLi.Model.ServerUser_Evaluate se = new ZhongLi.Model.ServerUser_Evaluate();
            se.SerUserID = SerUserID;
            se.RealName = RealName;
            se.EvaluateCon = EvaluateCon;
            se.EvaluateTime = DateTime.Now;
            se.EvaluateUserID = PerID;
            se.EvaluateName = PerRealName;
            se.EvaLevel = EvaLevel;
            se.OrderID = OrderID;
            se.EvaluateType = EvaluateType;
            if (new ZhongLi.BLL.ServerUser_Evaluate().Add(se) > 0)
            {
                strResult = "{\"state\":0}";
            }
            else
            {
                strResult = "{\"state\":1}";
            }
        }
        /// <summary>
        /// 人才在当前订单给人才经纪人的评论次数
        /// </summary>
        /// <param name="context"></param>
        private void PersonOrderEvaCount(HttpContext context)
        {
            int OrderID = Convert.ToInt32(context.Request.QueryString["OrderID"]);
            int PerID = Convert.ToInt32(context.Request.QueryString["PerID"]);
            int count = new ZhongLi.BLL.ServerUser_Evaluate().GetRecordCount(" OrderID=" + OrderID + " and EvaluateUserID=" + PerID);
            strResult = "{\"state\":"+count+"}";
        }

        /// <summary>
        /// 人才经纪人在当前订单给人才的评论次数
        /// </summary>
        /// <param name="context"></param>
        private void SerUserOrderEvaCount(HttpContext context)
        {
            int OrderID = Convert.ToInt32(context.Request.QueryString["OrderID"]);
            int SerUserID = Convert.ToInt32(context.Request.QueryString["SerUserID"]);
            int count = new ZhongLi.BLL.Person_Evaluate().GetRecordCount(" OrderID=" + OrderID + " and EvaluateUserID=" + SerUserID);
            strResult = "{\"state\":" + count + "}";
        }
        /// <summary>
        /// 给人才评论
        /// </summary>
        /// <param name="context"></param>
        private void PersonEvaAdd(HttpContext context)
        {
            int PerID = Convert.ToInt32(context.Request.Form["PerID"]);
            string RealName = context.Request.Form["RealName"];
            string EvaluateCon = context.Request.Form["EvaluateCon"];
            int SerUserID = Convert.ToInt32(context.Request.Form["SerUserID"]);
            string SerRealName = context.Request.Form["SerRealName"];
            int EvaLevel = Convert.ToInt32(context.Request.Form["EvaLevel"]);
            int OrderID = Convert.ToInt32(context.Request.Form["OrderID"]);
            int EvaluateType = Convert.ToInt32(context.Request.Form["EvaluateType"]);
            ZhongLi.Model.Person_Evaluate se = new ZhongLi.Model.Person_Evaluate();
            se.PerID = PerID;
            se.PerName = RealName;
            se.EvaluateCon = EvaluateCon;
            se.EvaluateTime = DateTime.Now;
            se.EvaluateUserID = SerUserID;
            se.EvaluateName = SerRealName;
            se.EvaLevel = EvaLevel;
            se.OrderID = OrderID;
            se.EvaluateType = EvaluateType;
            if (new ZhongLi.BLL.Person_Evaluate().Add(se) > 0)
            {
                strResult = "{\"state\":0}";
            }
            else
            {
                strResult = "{\"state\":1}";
            }
        }

        /// <summary>
        /// 得到人才评论列表
        /// </summary>
        /// <param name="context"></param>
        private void PersonEvaList(HttpContext context)
        {
            int PerID = Convert.ToInt32(context.Request.QueryString["PerID"]);
            int PageIndex = Convert.ToInt32(context.Request.QueryString["PageIndex"]);
            DataTable dt = new ZhongLi.BLL.Person_Evaluate().GetListByPage(" PerID=" + PerID + "", "EvaluateTime desc", (PageIndex - 1) * 20 + 1, PageIndex * 20).Tables[0];
            strResult = JsonConvert.SerializeObject(dt);
        }
        #endregion
        #region 人才经纪人标签
        /// <summary>
        /// 得到人才经纪人标签列表
        /// </summary>
        /// <param name="context"></param>
        private void getSerUserTag(HttpContext context)
        {
            string serUserID=context.Request.QueryString["SerUserID"];
            DataSet ds = new ZhongLi.BLL.ServerUser_Tag().GetList(" SerUserID=" + serUserID);
            strResult=JsonConvert.SerializeObject(ds.Tables[0]);
        }
        /// <summary>
        /// 得到标签详情
        /// </summary>
        /// <param name="context"></param>
        private void getSerUserTagDetail(HttpContext context)
        {
            int SerUserTagID = Convert.ToInt32(context.Request.QueryString["SerUserTagID"]);
            ZhongLi.Model.ServerUser_Tag tag = new ZhongLi.BLL.ServerUser_Tag().GetModel(SerUserTagID);
            strResult = JsonConvert.SerializeObject(tag);
        }
        /// <summary>
        /// 保存标签
        /// </summary>
        /// <param name="context"></param>
        private void saveSerUserTag(HttpContext context)
        {
            ZhongLi.Model.ServerUser_Tag tag = new ZhongLi.Model.ServerUser_Tag();
            tag.SerUserID = Convert.ToInt32(context.Request.Form["SerUserID"]);
            tag.SerUserTagID = Convert.ToInt32(context.Request.Form["SerUserTagID"]);
            tag.TagName=context.Request.Form["TagName"];
            if (tag.SerUserTagID <= 0)
            {
                if (new ZhongLi.BLL.ServerUser_Tag().Add(tag) > 0)
                {
                    strResult = "{\"state\":0}";
                }
                else
                {
                    strResult = "{\"state\":1}";
                }
            }
            else
            {
                if (new ZhongLi.BLL.ServerUser_Tag().Update(tag))
                {
                    strResult = "{\"state\":0}";
                }
                else
                {
                    strResult = "{\"state\":1}";
                }
            }
        }
        /// <summary>
        /// 删除标签
        /// </summary>
        /// <param name="context"></param>
        private void delSerUserTag(HttpContext context)
        {
            string SerUserTagID = context.Request.Form["SerUserTagID"];
            if (new ZhongLi.BLL.ServerUser_Tag().DeleteList(SerUserTagID))
            {
                strResult = "{\"state\":0}";
            }
            else
            {
                strResult = "{\"state\":1}";
            }
        }
        #endregion
        #endregion

        #region 身份认证
        /// <summary>
        /// 身份认证
        /// </summary>
        private void IdCardApprove(HttpContext context)
        {
            int SerUserID = Convert.ToInt32(context.Request.Form["SerUserID"]);
            string IDCardImg = context.Request.Form["IDCardImg"];
            string SerImg = context.Request.Form["SerImg"];

			string attestTypeStr = context.Request["attestType"] ?? "";
			int attestType = 0; int.TryParse(attestTypeStr, out attestType);

            string FileUrl = "";
            byte[] buffer = Convert.FromBase64String(IDCardImg);
            FileUrl = "/upload/seruser/idcardimg/" + Guid.NewGuid().ToString() + ".png";
            string sFilePath = context.Server.MapPath(FileUrl);
            File.WriteAllBytes(sFilePath, buffer);

            //byte[] buffer1 = Convert.FromBase64String(SerImg);
            //string FileUrl1 = "/upload/seruser/idcardimg/" + Guid.NewGuid().ToString() + ".png";
            //sFilePath = context.Server.MapPath(FileUrl1);
            //File.WriteAllBytes(sFilePath, buffer1);
			if (new ZhongLi.BLL.ServerUser().uploadIdCardApprove(SerUserID, FileUrl, "", attestType))
            {
                strResult = "{\"state\":0,\"url1\":\"" + FileUrl + "\"}";//,\"url2\":\""+FileUrl1+"\"
            }
            else
            {
                strResult = "{\"state\":1}";
            }
        }
        private void setIdcardImg(HttpContext context)
        {
            string SerUserID=context.Request.Form["SerUserID"];
            string IDCardImg = context.Request.Form["IDCardImg"];
            string FileUrl = "";
            byte[] buffer = Convert.FromBase64String(IDCardImg);
            FileUrl = "/upload/seruser/idcardimg/" + Guid.NewGuid().ToString() + ".png";
            string sFilePath = context.Server.MapPath(FileUrl);
            File.WriteAllBytes(sFilePath, buffer);
            if (new ZhongLi.BLL.ServerUser().saveIDCardImg(SerUserID, FileUrl))
            {
                strResult = "{\"state\":0,\"IDCardImg\":\"" + FileUrl + "\"}";
            }
            else
            {
                strResult = "{\"state\":1}";
            }
        }
        private void setSerImg(HttpContext context)
        {
            string SerUserID = context.Request.Form["SerUserID"];
            string SerImg = context.Request.Form["SerImg"];
            string FileUrl = "";
            byte[] buffer = Convert.FromBase64String(SerImg);
            FileUrl = "/upload/seruser/idcardimg/" + Guid.NewGuid().ToString() + ".png";
            string sFilePath = context.Server.MapPath(FileUrl);
            File.WriteAllBytes(sFilePath, buffer);
            if (new ZhongLi.BLL.ServerUser().saveSerImg(SerUserID, FileUrl))
            {
                strResult = "{\"state\":0,\"IDCardImg\":\"" + FileUrl + "\"}";
            }
            else
            {
                strResult = "{\"state\":1}";
            }
        }
        #endregion

        #region 职位
        //判断职位是否正在进行中
        private void checkPost(HttpContext context)
        {
            int PostID = Convert.ToInt32(context.Request.Form["PostID"]);
            if (new ZhongLi.BLL.ServerUser_Post().checkPost(PostID))
            {
                strResult = "{\"state\":0}";
            }
            else
            {
                strResult = "{\"state\":1}";
            }
        }
        /// <summary>
        /// 首页我的职位
        /// </summary>
        public void HomeMyPost(HttpContext context)
        {
            int SerUserID = Convert.ToInt32(context.Request.QueryString["SerUserID"]);
            DataTable dt = new ZhongLi.BLL.ServerUser_Post().HomeMyPost(SerUserID);
            strResult = JsonConvert.SerializeObject(dt);
        }
        /// <summary>
        /// 得到人才经纪人职位详情  带人才经纪人头像 名字 公司
        /// </summary>
        /// <param name="context"></param>
        private void getSerUserPost(HttpContext context)
        {
            int PostID = Convert.ToInt32(context.Request.QueryString["PostID"]);
            DataTable dt = new ZhongLi.BLL.ServerUser_Post().getPostSerUser(PostID);
            strResult = JsonConvert.SerializeObject(dt);
        }

        /// <summary>
        /// 我的职位列表
        /// </summary>
        /// <param name="context"></param>
        private void SerUserPost(HttpContext context)
        {
            string SerUserID=context.Request.QueryString["SerUserID"];
            DataTable dt=new ZhongLi.BLL.ServerUser_Post().GetList(" SerUserID="+SerUserID).Tables[0];
            strResult = JsonConvert.SerializeObject(dt);
        }
        /// <summary>
        /// 添加职位
        /// </summary>
        /// <param name="context"></param>
        private void saveSerUserPost(HttpContext context)
        {
            ZhongLi.Model.ServerUser_Post serpost = new ZhongLi.Model.ServerUser_Post();
            serpost.SerUserPostID = Convert.ToInt32(context.Request.Form["SerUserPostID"]);
            serpost.SerUserID = Convert.ToInt32(context.Request.Form["SerUserID"]);
            serpost.Company=context.Request.Form["Company"];
            serpost.Trade = context.Request.Form["Trade"];
            serpost.Scale=context.Request.Form["Scale"];
            serpost.Nature=context.Request.Form["Nature"];
            serpost.PostName=context.Request.Form["PostName"];
            serpost.PostDuty = context.Request.Form["PostDuty"];
            serpost.WorkAdress = context.Request.Form["WorkAdress"];
            serpost.Address = context.Request.Form["Address"];
            serpost.DirectLeader = context.Request.Form["DirectLeader"];
            serpost.CompanyMatching = context.Request.Form["CompanyMatching"];
            serpost.Salary = context.Request.Form["Salary"];
            serpost.DevelopProspect = context.Request.Form["DevelopProspect"];
            serpost.WelfareTag = context.Request.Form["WelfareTag"];
            serpost.OtherPoint = context.Request.Form["OtherPoint"];
            serpost.CreateTime = DateTime.Now;
            serpost.IsSole = 2;
            serpost.SeeCount=Convert.ToInt32(context.Request.Form["SeeCount"]);
            string comimgs = context.Request.Form["ComImg"];
            if (!comimgs.Contains("post"))
            {
                byte[] buffer = Convert.FromBase64String(comimgs);
                serpost.ComImg = "/upload/seruser/post/" + Guid.NewGuid().ToString() + ".png";
                string sFilePath = context.Server.MapPath(serpost.ComImg);
                File.WriteAllBytes(sFilePath, buffer);
            }
            else
            {
                serpost.ComImg = comimgs;
            }
            if (serpost.SerUserPostID == 0)
            {
                
                if (new ZhongLi.BLL.ServerUser_Post().Add(serpost) > 0)
                {
                    strResult = "{\"state\":0}";
                }
                else
                {
                    strResult = "{\"state\":1}";
                }
            }
            else
            {
                if (new ZhongLi.BLL.ServerUser_Post().Update(serpost))
                {
                    strResult = "{\"state\":0}";
                }
                else
                {
                    strResult = "{\"state\":1}";
                }
            }
        }
        /// <summary>
        /// 得到人才经纪人职位详情
        /// </summary>
        /// <param name="context"></param>
        private void getSerUserPostDetail(HttpContext context)
        {
            int SerUserPostID = Convert.ToInt32(context.Request.QueryString["SerUserPostID"]);
            ZhongLi.Model.ServerUser_Post serPost = new ZhongLi.BLL.ServerUser_Post().GetModel(SerUserPostID);
            strResult=JsonConvert.SerializeObject(serPost);
        }
        /// <summary>
        /// 删除职位
        /// </summary>
        /// <param name="context"></param>
        private void delSerUserPost(HttpContext context)
        {
            int SerUserPostID = Convert.ToInt32(context.Request.Form["SerUserPostID"]);
            int state = new ZhongLi.BLL.ServerUser_Post().delSerUser_Post(SerUserPostID);
            strResult = "{\"state\":"+state+"}";
        }
        #endregion

        #region 朋友
        private void DeleteFriend(HttpContext context)
        {
            int SerUserID = Convert.ToInt32(context.Request.Form["SerUserID"]);
            int PerID = Convert.ToInt32(context.Request.Form["PerID"]);
            if (new ZhongLi.BLL.Friends().DelFriend(PerID, SerUserID))
            {
                strResult = "{\"state\":0}";
            }
            else
            {
                strResult = "{\"state\":1}";
            }
        }
        /// <summary>
        /// 人才经纪人朋友列表
        /// </summary>
        /// <param name="context"></param>
        private void SerUserFriend(HttpContext context)
        {
            string SerUserID=context.Request.QueryString["SerUserID"];
            DataSet dt = new ZhongLi.BLL.Friends().SerUserFriend(SerUserID);
            strResult= JsonConvert.SerializeObject(dt);
        }
        /// <summary>
        /// 申请添加求职者为好友
        /// </summary>
        /// <param name="context"></param>
        private void ApplyFriend(HttpContext context)
        {
            int PerID = Convert.ToInt32(context.Request.Form["PerID"]);//求职者ID
            string PerRealName = context.Request.Form["PerRealName"];//求职者姓名
            int SerUserID = Convert.ToInt32(context.Request.Form["SerUserID"]);//经纪人ID
            string SerRealName= context.Request.Form["SerRealName"];//经纪人姓名
            if (new ZhongLi.BLL.Friends().PersonApply(SerUserID, SerRealName, PerID, PerRealName, 1))
            {
                JPushApiExample.ALERT = "人才经纪人" + SerRealName + "申请添加您为好友";
                JPushApiExample.MSG_CONTENT = "人才经纪人" + SerRealName + "申请添加您为好友";
                PushPayload pushsms = JPushApiExample.PushObject_ios_audienceMore_messageWithExtras("p" + PerID, "Order");
                JPushApiExample.push(pushsms);
                strResult = "{\"state\":0}";//添加成功
            }
            else
            {
                strResult = "{\"state\":1}";//添加失败
            }
        }
        /// <summary>
        /// 判断是否是好友
        /// </summary>
        /// <param name="context"></param>
        private void IsFriend(HttpContext context)
        {
            int PerID = Convert.ToInt32(context.Request.Form["PerID"]);//求职者ID
            int SerUserID = Convert.ToInt32(context.Request.Form["SerUserID"]);//经纪人ID
            int state=new ZhongLi.BLL.Friends().SerIsFriend(PerID, SerUserID);
            strResult = "{\"state\":"+state+"}";//0 可添加  1 已申请 2已经是好友
        }
        /// <summary>
        /// 同意好友申请
        /// </summary>
        /// <param name="context"></param>
        private void AgreeApply(HttpContext context)
        {
            int PerID = Convert.ToInt32(context.Request.Form["PerID"]);
            int SerUserID = Convert.ToInt32(context.Request.Form["SerUserID"]);
            int ApplyID = Convert.ToInt32(context.Request.Form["ApplyID"]);
            string SerRealName = context.Request.Form["RealName"];
            if (new ZhongLi.BLL.Friends().AgreeApply(PerID, SerUserID, ApplyID))
            {
                JPushApiExample.ALERT = "人才经纪人" + SerRealName + "同意了您的好友申请";
                JPushApiExample.MSG_CONTENT = "人才经纪人" + SerRealName + "同意了您的好友申请";
                PushPayload pushsms = JPushApiExample.PushObject_ios_audienceMore_messageWithExtras("p" + PerID, "Order");
                JPushApiExample.push(pushsms);
                strResult = "{\"state\":0}";//同意成功
            }
            else
            {
                strResult = "{\"state\":1}";//同意失败
            }
        }
        /// <summary>
        /// 拒绝好友申请
        /// </summary>
        /// <param name="context"></param>
        private void RefuseApply(HttpContext context)
        {
            int ApplyID = Convert.ToInt32(context.Request.Form["ApplyID"]);
            int PerID = Convert.ToInt32(context.Request.Form["PerID"]);
            string RealName = context.Request.Form["RealName"];
            if (new ZhongLi.BLL.Friends().SerRefuseApply(ApplyID,PerID,RealName))
            {
                JPushApiExample.ALERT = "人才经纪人" + RealName + "拒绝了您的好友申请";
                JPushApiExample.MSG_CONTENT = "人才经纪人" + RealName + "拒绝了您的好友申请";
                PushPayload pushsms = JPushApiExample.PushObject_ios_audienceMore_messageWithExtras("p" + PerID, "Order");
                JPushApiExample.push(pushsms);
                strResult = "{\"state\":0}";//拒绝成功
            }
            else
            {
                strResult = "{\"state\":1}";//拒绝失败
            }
        }
        #endregion

        #region 悬赏
        /// <summary>
        /// 人才经纪人悬赏列表 
        /// </summary>
        /// <param name="context"></param>
        private void getMyReward(HttpContext context)
        {
            string SerUserID=context.Request.QueryString["SerUserID"];
            int PageIndex=Convert.ToInt32(context.Request.QueryString["PageIndex"]);
            DataTable dt = new ZhongLi.BLL.Person_Reward().getSerUserReward(SerUserID,PageIndex);
            strResult = JsonConvert.SerializeObject(dt);
        }
        /// <summary>
        /// 得到我的悬赏详情
        /// </summary>
        /// <param name="context"></param>
        private void getMyRewardDetail(HttpContext context)
        {
            int PerRewMatID = Convert.ToInt32(context.Request.QueryString["PerRewMatID"]);
            DataTable dt = new ZhongLi.BLL.Person_Reward().getSerUserRewardDetail(PerRewMatID);
            strResult = JsonConvert.SerializeObject(dt);
        }
        /// <summary>
        /// 得到悬赏列表
        /// </summary>
        /// <param name="context"></param>
        private void getRewardList(HttpContext context)
        {
            int PageIndex = Convert.ToInt32(context.Request.QueryString["PageIndex"]);
            DataTable dt = new ZhongLi.BLL.Person_Reward().getRewardList(PageIndex);
            strResult = JsonConvert.SerializeObject(dt);
        }
        /// <summary>
        /// 得到悬赏详情
        /// </summary>
        /// <param name="context">ret[0].xxx</param>
        private void getRewardDetail(HttpContext context)
        {
            string PerRewardID = context.Request.QueryString["PerRewardID"];
            string SerUserID=context.Request.QueryString["SerUserID"];
            DataTable dt = new ZhongLi.BLL.Person_Reward().getRewardDetail(PerRewardID,SerUserID);
            strResult=JsonConvert.SerializeObject(dt);
        }
        /// <summary>
        /// 匹配悬赏
        /// </summary>
        /// <param name="context"></param>
        private void MatReward(HttpContext context)
        {
            int PerRewardID = Convert.ToInt32(context.Request.Form["PerRewardID"]);
            int PerID = Convert.ToInt32(context.Request.Form["PerID"]);
            int OrderID = Convert.ToInt32(context.Request.Form["OrderID"]);
            string SerRealName=context.Request.Form["SerRealName"];
            int SerUserID = Convert.ToInt32(context.Request.Form["SerUserID"]);
            int SerPostID = Convert.ToInt32(context.Request.Form["SerPostID"]);
            if (new ZhongLi.BLL.Person_Reward_Matching().setRewardMatching(OrderID,PerRewardID, PerID, SerUserID, SerPostID, SerRealName))
            {
                JPushApiExample.ALERT = "人才经纪人"+SerRealName+"匹配了您的悬赏订单，去我的订单查看吧";
                JPushApiExample.MSG_CONTENT = "人才经纪人"+SerRealName+"匹配了您的悬赏订单，去我的订单查看吧";
                PushPayload pushsms = JPushApiExample.PushObject_ios_audienceMore_messageWithExtras("p" + PerID, "Order");
                JPushApiExample.push(pushsms);
                strResult = "{\"state\":0}";
            }
            else
            {
                strResult = "{\"state\":1}";
            }
        }
        #endregion

        #region 订单
        /// <summary>
        /// 首页我的3个正在进行中悬赏订单
        /// </summary>
        /// <param name="context"></param>
        public void HomeMyOrder(HttpContext context)
        {
            int SerUserID = Convert.ToInt32(context.Request.QueryString["SerUserID"]);
            DataTable dt = new ZhongLi.BLL.Person_Reward_Matching().HomeSerUserOrder(SerUserID);
            strResult = JsonConvert.SerializeObject(dt);
        }
        /// <summary>
        /// 人才经纪人发起入职
        /// </summary>
        /// <param name="context"></param>
        private void SerUserEntryPost(HttpContext context)
        {
            int PerRewMatID = Convert.ToInt32(context.Request.Form["PerRewMatID"]);
            string SerRealName=context.Request.Form["SerRealName"];
            int PerID = Convert.ToInt32(context.Request.Form["PerID"]);
            if (new ZhongLi.BLL.Person_Reward_Matching().SerUserEntryPost(PerRewMatID,SerRealName))
            {
                JPushApiExample.ALERT = "人才经纪人" + SerRealName + "已发起入职，去我的订单查看吧";
                JPushApiExample.MSG_CONTENT = "人才经纪人" + SerRealName + "已发起入职，去我的订单查看吧";
                PushPayload pushsms = JPushApiExample.PushObject_ios_audienceMore_messageWithExtras("p" + PerID, "Order");
                JPushApiExample.push(pushsms);
                strResult = "{\"state\":0}";
            }
            else
            {
                strResult = "{\"state\":1}";
            }
        }
        /// <summary>
        /// 人才经纪人发起入职失败
        /// </summary>
        /// <param name="context"></param>
        private void SerUserFailPost(HttpContext context)
        {
            int PerRewMatID = Convert.ToInt32(context.Request.Form["PerRewMatID"]);
            string SerRealName = context.Request.Form["SerRealName"];
            int PerID = Convert.ToInt32(context.Request.Form["PerID"]);
            if (new ZhongLi.BLL.Person_Reward_Matching().SerUserFailPost(PerRewMatID,SerRealName))
            {
                JPushApiExample.ALERT = "人才经纪人" + SerRealName + "确认您入职失败，去我的订单查看吧";
                JPushApiExample.MSG_CONTENT = "人才经纪人" + SerRealName + "确认您入职失败，去我的订单查看吧";
                PushPayload pushsms = JPushApiExample.PushObject_ios_audienceMore_messageWithExtras("p" + PerID, "Order");
                JPushApiExample.push(pushsms);
                strResult = "{\"state\":0}";
            }
            else
            {
                strResult = "{\"state\":1}";
            }
        }
        /// <summary>
        /// 拒绝求职者悬赏订单
        /// </summary>
        /// <param name="context"></param>
        public void setPersonRewNoMat(HttpContext context)
        {
            int PerRewMatID = Convert.ToInt32(context.Request.Form["PerRewMatID"]);
            string SerRealName = context.Request.Form["SerRealName"];
            int PerID = Convert.ToInt32(context.Request.Form["PerID"]);
            string PostName = context.Request.Form["PostName"];
            if (new ZhongLi.BLL.Person_Reward_Matching().setSerUserRewardNoMat(PerRewMatID,SerRealName,PostName))
            {
                JPushApiExample.ALERT = "人才经纪人" + SerRealName + "拒绝了您针对职位" + PostName + "发送的悬赏订单，去看看其他职位吧";
                JPushApiExample.MSG_CONTENT = "人才经纪人" + SerRealName + "拒绝了您针对职位" + PostName + "发送的悬赏订单，去看看其他职位吧";
                PushPayload pushsms = JPushApiExample.PushObject_ios_audienceMore_messageWithExtras("p" + PerID, "Order");
                JPushApiExample.push(pushsms);
                strResult = "{\"state\":0}";
            }
            else
            {
                strResult = "{\"state\":1}";
            }
        }
        /// <summary>
        /// 接受求职者悬赏订单
        /// </summary>
        /// <param name="context"></param>
        public void setPersonRewMat(HttpContext context)
        {
            int PerRewMatID = Convert.ToInt32(context.Request.Form["PerRewMatID"]);
            string SerRealName=context.Request.Form["SerRealName"];
            int PerID = Convert.ToInt32(context.Request.Form["PerID"]);
            string PostName = context.Request.Form["PostName"];
            if (new ZhongLi.BLL.Person_Reward_Matching().setSerUserRewardMat(PerRewMatID,SerRealName,PostName))
            {
                JPushApiExample.ALERT = "人才经纪人" + SerRealName + "接受了您针对职位" + PostName + "发送的悬赏订单，去我的订单查看吧";
                JPushApiExample.MSG_CONTENT = "人才经纪人" + SerRealName + "接受了您针对职位" + PostName + "发送的悬赏订单，去我的订单查看吧";
                PushPayload pushsms = JPushApiExample.PushObject_ios_audienceMore_messageWithExtras("p" + PerID, "Order");
                JPushApiExample.push(pushsms);
                strResult = "{\"state\":0}"; //成功

				//发送短信通知给经纪人
				var prMatchModel = new ZhongLi.BLL.Person_Reward_Matching().GetModel(PerRewMatID);
				if (prMatchModel != null)
				{
					var serverUser = new ZhongLi.BLL.ServerUser().GetModel(prMatchModel.PerID ?? 0);
					if (serverUser != null && !String.IsNullOrWhiteSpace(serverUser.Phone)) 
					{
						MessageServices.SendToPerInform(serverUser.Phone);
					}
				}
            }
            else
            {
                strResult = "{\"state\":1}";
            }
        }
        /// <summary>
        /// 人才悬赏订单
        /// </summary>
        /// <param name="context"></param>
        private void PersonOrderList(HttpContext context)
        {
            int PageIndex = Convert.ToInt32(context.Request.QueryString["PageIndex"]);
            DataTable dt = new ZhongLi.BLL.Reward_Order().GetListByPage(" OrderState in (1,8)", " RewardMoney desc,CreateTime desc", (PageIndex - 1) * 10 + 1, PageIndex * 10).Tables[0];
            strResult = JsonConvert.SerializeObject(dt);
        }
        /// <summary>
        /// 人才悬赏订单详情
        /// </summary>
        /// <param name="context"></param>
        private void PersonOrderDetail(HttpContext context)
        {
            int OrderID = Convert.ToInt32(context.Request.Form["OrderID"]);
            int SerUserID = Convert.ToInt32(context.Request.Form["SerUserID"]);
            DataTable dt = new ZhongLi.BLL.Reward_Order().GetPersonOrderDetail(OrderID, SerUserID);
            strResult = JsonConvert.SerializeObject(dt);
        }
        private void SerUserOrder(HttpContext context)
        {
            string SerUserID = context.Request.QueryString["SerUserID"];
            int PageIndex = Convert.ToInt32(context.Request.QueryString["PageIndex"]);
            string state=context.Request.QueryString["State"];
            DataTable dt = new ZhongLi.BLL.Reward_Order().SerUserOrder(SerUserID,PageIndex,state);
            strResult = JsonConvert.SerializeObject(dt);
        }
        private void getOrderDetail(HttpContext context)
        {
            int PerRewMatID = Convert.ToInt32(context.Request.QueryString["PerRewMatID"]);
            DataTable dt = new ZhongLi.BLL.Reward_Order().SerUserOrderDetail(PerRewMatID);
            strResult = JsonConvert.SerializeObject(dt);
        }
        /// <summary>
        /// 人才经纪人确认订单失败   是否需要后台确认
        /// </summary>
        /// <param name="context"></param>
        private void setOrderFail(HttpContext context)
        {
            int OrderID = Convert.ToInt32(context.Request.Form["OrderID"]);
            DataTable perdt = new ZhongLi.BLL.Reward_Order().getPerByOrderID(OrderID);
            int PerID = Convert.ToInt32(perdt.Rows[0]["PerID"]);
            decimal RewardMoney = Convert.ToDecimal(perdt.Rows[0]["RewardMoney"]);
            if (new ZhongLi.BLL.Reward_Order().SerUserSetOrderFail(OrderID,PerID,RewardMoney))
            {
                strResult = "{\"state\":0}";
            }
            else
            {
                strResult = "{\"state\":1}";
            }
        }
        /// <summary>
        /// 人才经纪人确认入职成功
        /// </summary>
        /// <param name="context"></param>
        private void setOrderSus(HttpContext context)
        {
            int OrderID = Convert.ToInt32(context.Request.Form["OrderID"]);
            
            if (new ZhongLi.BLL.Reward_Order().editOrderState(OrderID, 6))
            {
                strResult = "{\"state\":0}";
            }
            else
            {
                strResult = "{\"state\":1}";
            }
        }
        #endregion
        #region
        /// <summary>
        /// 人才经纪人交易记录
        /// </summary>
        /// <param name="context"></param>
        private void getSerUserRecord(HttpContext context)
        {
            int SerUserID = Convert.ToInt32(context.Request.QueryString["SerUserID"]);
            int PageIndex = Convert.ToInt32(context.Request.QueryString["PageIndex"]);
            DataTable dt = new ZhongLi.BLL.TransactionRecord().getRecord(SerUserID, 1, PageIndex);
            strResult = JsonConvert.SerializeObject(dt);
        }
        /// <summary>
        /// 添加提现申请
        /// </summary>
        /// <param name="context"></param>
        private void AddPresent(HttpContext context)
        {
            int SerUserID = Convert.ToInt32(context.Request.Form["UserID"]);//用户ID  seruserid 或者perid
            string RealName = context.Request.Form["RealName"];//姓名
            int PreType = Convert.ToInt32(context.Request.Form["PreType"]);//支付类型 0支付宝  1微信
            string Account = context.Request.Form["Account"];//提现账号
            string AccountName = context.Request.Form["AccountName"];//收款账号姓名
            decimal Money = Convert.ToDecimal(context.Request.Form["Money"]);//提现金额
            int UserType = Convert.ToInt32(context.Request.Form["UserType"]);//用户类型 0人才 1人才经纪人
            if (new ZhongLi.BLL.PresentApplication().AddPresent(SerUserID, RealName, PreType, Account, Money, UserType,AccountName))
            {
                strResult = "{\"state\":0}";
            }
            else
            {
                strResult = "{\"state\":1}";
            }
        }
        /// <summary>
        /// 判断有没有正在进行的提现
        /// </summary>
        /// <param name="context"></param>
        private void getNowPre(HttpContext context)
        {
            int UserID = Convert.ToInt32(context.Request.QueryString["UserID"]);
            int UserType = Convert.ToInt32(context.Request.QueryString["UserType"]);
            int count = new ZhongLi.BLL.PresentApplication().GetRecordCount(" UserID=" + UserID + " and UserType=" + UserType + " and State in(0,1)");
            if (count > 0)
            {
                strResult = "{\"state\":0}";
            }
            else
            {
                strResult = "{\"state\":1}";
            }
        }
        /// <summary>
        /// 得到提现列表
        /// </summary>
        /// <param name="context"></param>
        private void getMyPre(HttpContext context)
        {
            int UserID = Convert.ToInt32(context.Request.QueryString["UserID"]);
            int UserType = Convert.ToInt32(context.Request.QueryString["UserType"]);
            DataTable dt = new ZhongLi.BLL.PresentApplication().GetList(" UserID=" + UserID + " and UserType=" + UserType + " order by CreateTime Desc").Tables[0];
            strResult = JsonConvert.SerializeObject(dt);
        }
        /// <summary>
        /// 得到提现详情
        /// </summary>
        /// <param name="context"></param>
        private void getMyPreDetail(HttpContext context)
        {
            int ID = Convert.ToInt32(context.Request.QueryString["ID"]);
            ZhongLi.Model.PresentApplication pre = new ZhongLi.BLL.PresentApplication().GetModel(ID);
            strResult = JsonConvert.SerializeObject(pre);
        }
        #endregion
        #region 人才经纪人提示消息
        /// <summary>
        /// 得到所有未读的消息数量
        /// </summary>
        /// <param name="context"></param>
        private void getMsgCount(HttpContext context)
        {
            int SerUserID = Convert.ToInt32(context.Request.QueryString["SerUserID"]);
            int count = new ZhongLi.BLL.ServerUser_Message().getMsgCount(SerUserID);
            strResult = "{\"count\":" + count + "}";
        }
        /// <summary>
        /// 得到各个类型消息类型
        /// </summary>
        /// <param name="context"></param>
        private void getMsgCountByType(HttpContext context)
        {
            int SerUserID = Convert.ToInt32(context.Request.QueryString["SerUserID"]);
            DataTable dt = new ZhongLi.BLL.ServerUser_Message().getMsgCountByType(SerUserID);
            strResult = JsonConvert.SerializeObject(dt);
        }
        /// <summary>
        /// 得到分类的未读消息并设置已读
        /// </summary>
        /// <param name="context"></param>
        private void getMsgByType(HttpContext context)
        {
            int SerUserID = Convert.ToInt32(context.Request.QueryString["SerUserID"]);
            int MsgType = Convert.ToInt32(context.Request.QueryString["MsgType"]);
            DataTable dt = new ZhongLi.BLL.ServerUser_Message().getMsgByType(SerUserID,MsgType);
            strResult = JsonConvert.SerializeObject(dt);
        }
        #endregion
        #region 省市区json
        /// <summary>
        /// 所有职位
        /// </summary>
        private void getALlPost(HttpContext context)
        {
            int ID = Convert.ToInt32(context.Request.QueryString["ID"]);
            DataTable dt = new ZhongLi.BLL.PostType().GetAllPostName(ID);
            strResult = JsonConvert.SerializeObject(dt);
        }

        public void allcity(HttpContext context)
        {
            List<ZhongLi.Model.sys_City> citys = new ZhongLi.Bll.sys_City().GetListCity("");
            string jsoncity = "{\"topCitys\": [";
            jsoncity += "{\"city\":\"北京\",\"id\": \"0101\",\"pinyin\": \"beijing\"},{\"city\": \"天津\",\"id\": \"0301\",\"pinyin\": \"tianjin\"}],\"citys\":[";
            string cityall = "";
            foreach (ZhongLi.Model.sys_City c in citys)
            {
                cityall += "{";
                cityall += "\"id\":\""+c.Code+"\",";
                cityall += "\"city\":\"" + c.City + "\",";
                cityall += "\"pinyin\":\"" + new ChineseCode().GetSpell(c.City) + "\"";
                cityall += "},";
            }
            cityall=cityall.TrimEnd(',');
            jsoncity += cityall;
            jsoncity += "]}";
            strResult = jsoncity;
        }

        public void shengshiqu(HttpContext context)
        {
            ZhongLi.Bll.sys_City bll = new ZhongLi.Bll.sys_City();
            List<ZhongLi.Model.sys_City> sheng = bll.GetListProvince();
            string json = "[";
            foreach (ZhongLi.Model.sys_City pro in sheng)
            {
                json += "{\"name\":\""+pro.Province+"\",";
                List<ZhongLi.Model.sys_City> shi = bll.GetListCity(pro.Code);
                if (shi.Count > 0)
                {
                    json += "\"sub\":[";
                    foreach (ZhongLi.Model.sys_City city in shi)
                    {
                        json += "{";
                        json += "\"name\":\""+city.City+"\",";
                        List<ZhongLi.Model.sys_City> qu = bll.GetListCounty(city.Code);
                        if (qu.Count > 0)
                        {
                            json += "\"sub\":[";
                            foreach (ZhongLi.Model.sys_City cou in qu)
                            {
                                json += "{";
                                json += "\"name\":\"" + cou.county + "\"";
                                json += "},";
                            }
                            json=json.TrimEnd(',');
                            json += "]";
                        }
                        json += "},";
                    }
                    json = json.TrimEnd(',');
                    json += "]";
                }
                json += "},";
            }
            json = json.TrimEnd(',');
            json += "]";
            strResult = json;
        }
        #endregion

        #region 版本
        /// <summary>
        /// 得到版本号
        /// </summary>
        /// <param name="context"></param>
        public void getEditeion(HttpContext context)
        {
            ZhongLi.Model.siteconfig site = new ZhongLi.Bll.siteconfig().loadConfig(context.Server.MapPath("/xmlconfig/site.config"));
            string Edition = site.Edition;
            strResult = "{\"state\":\"" + Edition + "\"}";
        }
        #endregion
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}