using cn.jpush.api.push.mode;
using Com.Alipay;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
    /// Ajax 的摘要说明
    /// </summary>
    public class Ajax : IHttpHandler
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
                    case "SavePersonInfo"://保存个人信息
                        SavePersonInfo(context);
                        break;
                    case "phonecode"://注册发送手机验证码
                        phonecode(context);
                        break;
                    case "checkphonecode"://注册验证手机验证码
                        checkphonecode(context);
                        break;
                    case "savepwd"://保存密码
                        savepwd(context);
                        break;
                    #endregion
                    #region 个人资料
                    #region 个人信息
                    case "checkUser":
                        checkUser(context);
                        break;
                    case "getRyToken"://融云聊天token
                        getRyToken(context);
                        break;
                    case "getRyServerUsers":
                        getRyServerUsers(context);
                        break;
                    case "getRyServerUser":
                        getRyServerUser(context);
                        break;
                    case "getPerson"://获得求职者个人信息
                        getPerson(context);
                        break;
                    case "savePerson"://保存求职者个人信息
                        savePerson(context);
                        break;
                    case "saveMyDes":
                        saveMyDes(context);
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
                    case "findPwdCheckCode":
                        findPwdCheckCode(context);
                        break;
                    #endregion
                    #region 测评
                    case "AddPersonTest":
                        AddPersonTest(context);
                        break;
                    case "getPersonTest":
                        getPersonTest(context);
                        break;
                    #endregion
                    #region 切换身份
                    case "SerUserFromPerson":
                        SerUserFromPerson(context);
                        break;
                    #endregion
                    #region 教育经历
                    case "getPersonEdu"://得到求职者教育经历
                        getPersonEdu(context);
                        break;
                    case "getPersonEduDetail"://得到求职者教育经历详情
                        getPersonEduDetail(context);
                        break;
                    case "SavePersonEdu":
                        SavePersonEdu(context);
                        break;
                    case "DelPersonEdu"://删除教育经历
                        DelPersonEdu(context);
                        break;
                    #endregion
                    #region 工作经历
                    case "getPersonWork":
                        getPersonWork(context);
                        break;
                    case "getPersonWorkDetail":
                        getPersonWorkDetail(context);
                        break;
                    case "savePersonWork":
                        savePersonWork(context);
                        break;
                    case "delPersonWork":
                        delPersonWork(context);
                        break;
                    #endregion
                    #region 期望工作
                    case "getPostType":
                        getPostType(context);
                        break;
                    case "getExpectWork":
                        getExpectWork(context);
                        break;
                    case "saveExpectWork":
                        saveExpectWork(context);
                        break;
                    #region
                    case "getPersonPreject":
                        getPersonPreject(context);
                        break;
                    case "getPersonPrejectDetail":
                        getPersonPrejectDetail(context);
                        break;
                    case "savePersonProject":
                        savePersonProject(context);
                        break;
                    case "delPersonProject":
                        delPersonProject(context);
                        break;
                    #endregion
                    #endregion
                    #region 技能评价
                    case "getPersonSkill":
                        getPersonSkill(context);
                        break;
                    case "getPersonSkillDetail":
                        getPersonSkillDetail(context);
                        break;
                    case "savePersonSkill":
                        savePersonSkill(context);
                        break;
                    case "delPersonSkill":
                        delPersonSkill(context);
                        break;
                    #endregion
                    #endregion
                    #region 悬赏
                    case "getPersonReward":
                        getPersonReward(context);//得到悬赏列表
                        break;
                    case "getPersonRewardDetail"://悬赏详情
                        getPersonRewardDetail(context);
                        break;
                    case "addPersonReward"://添加悬赏
                        addPersonReward(context);
                        break;
                    case "editPersonReward"://修改悬赏
                        editPersonReward(context);
                        break;
                    case "delPersonReward":
                        delPersonReward(context);
                        break;
                    case "getPersonRewardPost"://悬赏解决方案
                        getPersonRewardPost(context);
                        break;
                    case "getPersonRewardPostDetail"://悬赏解决方案详情
                        getPersonRewardPostDetail(context);
                        break;
                    case "setPersonRewardPostMat"://确认解决方案
                        setPersonRewardPostMat(context);
                        break;
                    case "setPersonRewardNoMat":
                        setPersonRewardNoMat(context);
                        break;
                    case "PerSetInPost":
                        PerSetInPost(context);
                        break;
                    case "PerSetFailPost":
                        PerSetFailPost(context);
                        break;
                    case "getMatState":
                        getMatState(context);
                        break;
                    #endregion
                    #region 身份认证
                    case "setAuthImg":
                        setAuthImg(context);
                        break;
                    case "getFlagState":
                        getFlagState(context);
                        break;
                    #endregion
                    #region 订单
                    case "PerRewardOrder":
                        PerRewardOrder(context);
                        break;
                    case "getAgr":
                        getAgr(context);
                        break;
                    case "OrderDelay":
                        OrderDelay(context);
                        break;
                    case "checkIsSendOrder":
                        checkIsSendOrder(context);
                        break;
                    case "AddOrder":
                        AddOrder(context);
                        break;
                    //case "AliPayOrderResult":
                    //    AliPayOrderResult(context);
                    //    break;
                    case "PerOrder":
                        PerOrder(context);
                        break;
                    case "getOrderDetail":
                        getOrderDetail(context);
                        break;
                    case "getBalance":
                        getBalance(context);
                        break;
                    case "OrderPay":
                        OrderPay(context);
                        break;
                    case "perOrderFail":
                        perOrderFail(context);
                        break;
                    case "getOrderPayInfo":
                        getOrderPayInfo(context);
                        break;
                    case "setOrderAutoImg":
                        setOrderAutoImg(context);
                        break;
                    case "getAutoImg":
                        getAutoImg(context);
                        break;
                    case "CanceOrder":
                        CanceOrder(context);
                        break;
                    case "UsingOrder":
                        UsingOrder(context);
                        break;
                    case "setRewardOrderByPost":
                        setRewardOrderByPost(context);
                        break;
                    case "getMatPostByOrder":
                        getMatPostByOrder(context);
                        break;
                    case "getOrderState":
                        getOrderState(context);
                        break;
                    #endregion

                    #region 经纪人
                    case "moreSolePost":
                        moreSolePost(context);
                        break;
                    case "SerUserList":
                        SerUserList(context);
                        break;
                    case "SerUserPostList":
                        SerUserPostList(context);
                        break;
                    case "getSolePost":
                        getSolePost(context);
                        break;
                    case "SerUserPostSee":
                        SerUserPostSee(context);
                        break;
                    case "getHomePostSearch":
                        getHomePostSearch(context);
                        break;
                    #endregion
                    #region 消息
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
                    #region 朋友
                    case "PerFriend":
                        PerFriend(context);
                        break;
                    case "RefuseApply":
                        RefuseApply(context);
                        break;
                    case "IsFriend":
                        IsFriend(context);
                        break;
                    case "ApplyFriend":
                        ApplyFriend(context);
                        break;
                    case "AgreeApply":
                        AgreeApply(context);
                        break;
                    case "DeleteFriend":
                        DeleteFriend(context);
                        break;
                    #endregion
                    #region 交易记录
                    case "getPersonRecord":
                        getPersonRecord(context);
                        break;
                    case "AddPayCheck":
                        AddPayCheck(context);
                        break;
                    //case "PayCheck":
                    //    PayCheck(context);
                    //    break;
                    #endregion
                    #region 首页 新闻 职业培训 职业规划
                    case "hotNews":
                        hotNews(context);
                        break;
                    case "newsList":
                        newsList(context);
                        break;
                    case "newsDetail":
                        newsDetail(context);
                        break;
                    case "careerPlan":
                        careerPlan(context);
                        break;
                    case "careerPlanList":
                        careerPlanList(context);
                        break;
                    case "careerPlanDetail":
                        careerPlanDetail(context);
                        break;
                    case "JobTr":
                        JobTr(context);
                        break;
                    case "JobTrList":
                        JobTrList(context);
                        break;
                    case "JobTrDetail":
                        JobTrDetail(context);
                        break;
                    #endregion
                    #region 版本
                    case "getEditeion":
                        getEditeion(context);
                        break;
                    #endregion
                    #region 用户反馈
                    case "GetFeedBack":
                        GetFeedBack(context);
                        break;
                    case "AddFeedBack":
                        AddFeedBack(context);
                        break;
                    #endregion
                    case "test":
                        test(context);
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
        private void login(HttpContext context)
        {
            try
            {
                string phone = context.Request["phone"];
                string password = DESEncrypt.GetStringMD5(context.Request["password"]);
                int state = new ZhongLi.BLL.Person().checklogin(phone, password);
                if (state == 0)
                {
                    DataTable dt = new ZhongLi.BLL.Person().findinfo("PerID,RealName,Photo,Flag,AuthImg,ImOpenID", " Phne='" + phone + "'");
                    strResult = "{\"state\":" + state + ",\"person\":{\"perid\":" + dt.Rows[0]["PerID"] + ",\"realname\":\"" + dt.Rows[0]["RealName"] + "\",\"photo\":\"" + dt.Rows[0]["Photo"] + "\",\"flag\":" + dt.Rows[0]["Flag"] + ",\"token\":\"" + dt.Rows[0]["ImOpenID"] + "\"}}";
                }
                else
                {
                    strResult = "{\"state\":" + state + ",\"person\":\"\"}";
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
            //WxLogger(Sex,context);
            if (Sex.ToString() == "0")
            {
                Sex = "false";
            }
            if (Sex.ToString() == "1")
            {
                Sex = "true";
            }
            string Photo = context.Request.Form["Photo"];
            DataTable dt = new ZhongLi.BLL.Person().getPersonByOpenID(loginType, OpenID);
            if (dt.Rows.Count > 0)
            {
                string pwd = "0";
                if (dt.Rows[0]["Password"].ToString() != "")
                {
                    pwd = "1";
                }
                strResult = "{\"state\":0,\"person\":{\"perid\":" + dt.Rows[0]["PerID"] + ",\"realname\":\"" + dt.Rows[0]["RealName"] + "\",\"phone\":\"" + dt.Rows[0]["Phne"] + "\",\"photo\":\"" + dt.Rows[0]["Photo"] + "\",\"flag\":" + dt.Rows[0]["Flag"] + ",\"token\":\"" + dt.Rows[0]["ImOpenID"] + "\",\"pwd\":\"" + pwd + "\"}}";
            }
            else
            {
                ZhongLi.Model.Person p = new ZhongLi.Model.Person();
                p.RealName = NikeName;
                p.Sex = bool.Parse(Sex);
                string photourl = "/upload/person/" + Guid.NewGuid() + ".png";
                string imgFileName = context.Server.MapPath(photourl);
                ImgDownLoad.DownloadPicture(Photo, imgFileName, 300);
                p.Photo = photourl;
                //p.Phne = phone;
                p.RegTime = DateTime.Now;
                p.Balance = 0;
                p.Flag = 0;
                p.Password = "";
                switch (loginType)
                {
                    case "wx":
                        p.WxOpenID = OpenID;
                        break;
                    case "qq":
                        p.QQOpenID = OpenID;
                        break;
                    case "wb":
                        p.WbOpenID = OpenID;
                        break;
                }
                int PerID = new ZhongLi.BLL.Person().Add(p);
                if (PerID > 0)
                {
                    strResult = "{\"state\":1,\"person\":{\"perid\":" + PerID + ",\"realname\":\"" + NikeName + "\",\"phone\":\"\",\"photo\":\"" + photourl + "\",\"flag\":0,\"token\":\"\"}}";
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
                ZhongLi.Model.Person p = new ZhongLi.Model.Person();
                p.RealName = NikeName;
                p.Sex = bool.Parse(Sex);
                string photourl = "/upload/person/" + Guid.NewGuid() + ".png";
                string imgFileName = context.Server.MapPath(photourl);
                ImgDownLoad.DownloadPicture(Photo, imgFileName, 300);
                p.Photo = photourl;
                p.Phne = phone;
                p.RegTime = DateTime.Now;
                p.Balance = 0;
                switch (loginType)
                {
                    case "wx":
                        p.WxOpenID = OpenID;
                        break;
                    case "qq":
                        p.QQOpenID = OpenID;
                        break;
                    case "wb":
                        p.WbOpenID = OpenID;
                        break;
                }
                int PerID = new ZhongLi.BLL.Person().Add(p);
                if (PerID <= 0)
                {
                    strResult = "{\"PerID\":" + PerID + ",\"Photo\":\"" + photourl + "\"}";
                }
                else
                {
                    strResult = "{\"PerID\":0}";
                }
            }
            else
            {
                strResult = "{\"PerID\":-1}";
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
            if (new ZhongLi.BLL.Person().checkphone(phone))
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
                MessageServices.SendRegistrationMessage(phone, code);
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
            string phone = context.Request.Form["phone"];
            string code = context.Request.Form["code"];
            if (new ZhongLi.BLL.PhoneCode().CheckPhoneCode(phone, code, "0"))
            {
                ZhongLi.Model.Person person = new ZhongLi.Model.Person();
                person.Phne = phone;
                person.RealName = phone;
                person.Flag = 0;
                person.Balance = 0;
                person.RegTime = DateTime.Now;
                int perid = new ZhongLi.BLL.Person().Add(person);
                if (perid > 0)
                {
                    strResult = "{\"state\":0,\"perid\":" + perid + "}";
                }
                else
                {
                    strResult = "{\"state\":2,\"perid\":0}";
                }
            }
            else
            {
                strResult = "{\"state\":1}";
            }
        }

        /// <summary>
        /// 注册填写密码
        /// </summary>
        /// <param name="context"></param>
        private void savepwd(HttpContext context)
        {
            string password = context.Request.Form["password"];
            int perid = Convert.ToInt32(context.Request.Form["perid"]);
            if (new ZhongLi.BLL.Person().editPwd(DESEncrypt.GetStringMD5(password), perid))
            {
                strResult = "{\"state\":0}";
            }
            else
            {
                strResult = "{\"state\":1}";
            }
        }

        /// <summary>
        /// 注册时保存个人信息
        /// </summary>
        /// <param name="context"></param>
        private void SavePersonInfo(HttpContext context)
        {
            string realname = context.Request.Form["realname"];
            string sex = context.Request.Form["sex"];
            string education = context.Request.Form["education"];
            string worklife = context.Request.Form["worklife"];
            //string birth = context.Request.Form["birth"];
            string email = context.Request.Form["email"];
            string city = context.Request.Form["city"];
            int perid = Convert.ToInt32(context.Request.Form["perid"]);
            string ExpectedPostion = context.Request.Form["ExpectedPostion"];
            string WorkType = context.Request.Form["WorkType"];
            string ExCity = context.Request.Form["ExCity"];
            string ExSalary = context.Request.Form["ExSalary"];
            ZhongLi.Model.Person person = new ZhongLi.BLL.Person().GetModel(perid);
            person.RealName = realname;
            person.Sex = sex == "男" ? true : false;
            person.Education = education;
            person.WorkLife = worklife;
            //  person.Birth = birth;
            person.Email = email;
            person.City = city;
            ZhongLi.Model.Person_ExpectWork perExwork = new ZhongLi.Model.Person_ExpectWork();
            perExwork.ExpectedPostion = ExpectedPostion;
            perExwork.WorkType = WorkType;
            perExwork.ExCity = ExCity;
            perExwork.ExSalary = ExSalary;
            perExwork.PerID = perid;
            if (new ZhongLi.BLL.Person().Update(person) && new ZhongLi.BLL.Person_ExpectWork().Add(perExwork) > 0)
            {
                DataTable dt = new ZhongLi.BLL.Person().findinfo("Photo", " PerID='" + perid + "'");
                strResult = "{\"state\":0,\"person\":{\"perid\":" + perid + ",\"realname\":\"" + realname + "\",\"photo\":\"" + dt.Rows[0]["Photo"] + "\"}}";
            }
            else
            {
                strResult = "{\"state\":1,\"person\":\"\"}";
            }

        }
        #endregion

        #region 查看修改个人资料
        #region 个人信息
        /// <summary>
        /// 查看用户是否存在
        /// </summary>
        /// <param name="context"></param>
        private void checkUser(HttpContext context)
        {
            int UserID = Convert.ToInt32(context.Request.Form["UserID"]);
            int UserType = Convert.ToInt32(context.Request.Form["UserType"]);
            bool istrue = false;
            if (UserType == 0)
            {
                istrue = new ZhongLi.BLL.Person().Exists(UserID);
            }
            else
            {
                istrue = new ZhongLi.BLL.ServerUser().Exists(UserID);
            }
            if (istrue)
            {
                strResult = "{\"state\":0}";
            }
            else
            {
                strResult = "{\"state\":1}";
            }
        }
        /// <summary>
        /// 得到融云聊天token
        /// </summary>
        /// <param name="context"></param>
        private void getRyToken(HttpContext context)
        {
            int perid = Convert.ToInt32(context.Request.Form["perid"]);
            string realname = context.Request.Form["realname"];
            string photo = context.Request.Form["photo"];
            RYToken rytoken = new RYToken();
            string tokenjson = rytoken.getToken("p" + perid, realname, photo);
            JObject obj = JsonConvert.DeserializeObject(tokenjson) as JObject;
            if (obj["code"].ToString().Equals("200"))
            {
                string token = obj["token"].ToString();
                new ZhongLi.BLL.Person().editImOpenID(perid, token);
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
        private void getRyServerUsers(HttpContext context)
        {
            string seruserid = context.Request.Form["userids"].Replace("s", "").Replace("p", "");
            DataTable dt = new ZhongLi.BLL.ServerUser().findField("('s'+cast(SerUserID as varchar(8))) as userid,RealName as realname,PhotoImg as avatar", seruserid);
            strResult = JsonConvert.SerializeObject(dt);
        }
        /// <summary>
        /// 融云聊天 得到用户信息
        /// </summary>
        /// <param name="context"></param>
        private void getRyServerUser(HttpContext context)
        {
            string seruserid = context.Request.Form["userid"].Replace("s", "").Replace("p", "");
            DataTable dt = new ZhongLi.BLL.ServerUser().findField("('s'+cast(SerUserID as varchar(8))) as userid,RealName as realname,PhotoImg as avatar", Convert.ToInt32(seruserid));
            strResult = "{\"userid\":\"" + dt.Rows[0]["userid"] + "\",\"avatar\":\"" + dt.Rows[0]["avatar"] + "\",\"realname\":\"" + dt.Rows[0]["realname"] + "\"}";
        }
        /// <summary>
        /// 设置头像
        /// </summary>
        /// <param name="context"></param>
        private void setPhoto(HttpContext context)
        {
            try
            {
                string photo64 = context.Request.Form["Photo"];
                int PerID = Convert.ToInt32(context.Request.Form["PerID"]);
                string FileUrl = "";
                if (photo64 != "")
                {
                    byte[] buffer = Convert.FromBase64String(photo64);
                    FileUrl = "/upload/person/" + Guid.NewGuid().ToString() + ".png";
                    string sFilePath = context.Server.MapPath(FileUrl);
                    File.WriteAllBytes(sFilePath, buffer);
                }
                if (new ZhongLi.BLL.Person().setPhoto(PerID, FileUrl))
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
        /// 修改个人描述
        /// </summary>
        /// <param name="context"></param>
        private void saveMyDes(HttpContext context)
        {
            string PerID = context.Request.Form["PerID"];
            string MyDes = context.Request.Form["MyDes"];
            if (new ZhongLi.BLL.Person().editMyDes(PerID, MyDes))
            {
                strResult = "{\"state\":0}";
            }
            else
            {
                strResult = "{\"state\":1}";
            }
        }

        /// <summary>
        /// 得到个人资料
        /// </summary>
        /// <param name="context"></param>
        private void getPerson(HttpContext context)
        {
            int perid = Convert.ToInt32(context.Request.QueryString["PerID"]);
            ZhongLi.Model.Person person = new ZhongLi.BLL.Person().GetModel(perid);
            person.Password = "";
            strResult = JsonConvert.SerializeObject(person);
        }
        /// <summary>
        /// 保存求职者个人资料
        /// </summary>
        /// <param name="context"></param>
        private void savePerson(HttpContext context)
        {
            int PerID = Convert.ToInt32(context.Request.Form["PerID"]);
            ZhongLi.Model.Person person = new ZhongLi.BLL.Person().GetModel(PerID);
            person.RealName = context.Request.Form["RealName"];
            person.Sex = context.Request.Form["Sex"] == "男" ? true : false;
            person.Birth = context.Request.Form["Birth"];
            person.Education = context.Request.Form["Education"];
            person.WorkLife = context.Request.Form["WorkLife"];
            person.Email = context.Request.Form["Email"];
            person.City = context.Request.Form["City"];
            person.OneDes = context.Request.Form["OneDes"];
            if (new ZhongLi.BLL.Person().Update(person))
            {
                strResult = "{\"state\":0}";
            }
            else
            {
                strResult = "{\"state\":1}";
            }
        }
        #region 切换身份
        private void SerUserFromPerson(HttpContext context)
        {
            int PerID = Convert.ToInt32(context.Request.Form["PerID"]);
            strResult = new ZhongLi.BLL.ServerUser().SerUserFromPerson(PerID);
        }
        #endregion
        #region 修改密码
        /// <summary>
        /// 修改密码 发送验证码
        /// </summary>
        /// <param name="context"></param>
        private void Pwdcode(HttpContext context)
        {
            string PerID = context.Request.QueryString["PerID"];
            string phone = new ZhongLi.BLL.Person().getPhone(PerID);
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
            string PerID = context.Request.Form["PerID"];
            string code = context.Request.Form["code"];
            string phone = new ZhongLi.BLL.Person().getPhone(PerID);
            if (new ZhongLi.BLL.PhoneCode().CheckPhoneCode(phone, code, "1"))
            {
                if (new ZhongLi.BLL.Person().editPwd(DESEncrypt.GetStringMD5(Password), Convert.ToInt32(PerID)))
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
            if (new ZhongLi.BLL.Person().checkphone(phone))
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
            string PerID = context.Request.Form["PerID"];
            string code = context.Request.Form["code"];
            string phone = context.Request.Form["phone"];
            if (new ZhongLi.BLL.PhoneCode().CheckPhoneCode(phone, code, "2"))
            {
                if (new ZhongLi.BLL.Person().ModPhone(phone, PerID))
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
            if (new ZhongLi.BLL.Person().checkphone(phone))
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
            string phone = context.Request.Form["phone"];
            string code = context.Request.Form["code"];
            if (new ZhongLi.BLL.PhoneCode().CheckPhoneCode(phone, code, "3"))
            {
                DataTable dt = new ZhongLi.BLL.Person().findinfo("PerID", " Phne='" + phone + "'");
                strResult = "{\"state\":0,\"perid\":" + dt.Rows[0]["PerID"] + "}";
            }
            else
            {
                strResult = "{\"state\":1}";
            }
        }
        #endregion
        #endregion
        #region 测评
        private void AddPersonTest(HttpContext context)
        {
            int PerID = Convert.ToInt32(context.Request["PerID"]);
            string TestResUrl = context.Request["ResUrl"];
            int AnsID = Convert.ToInt32(context.Request["AnsID"]);
            DataTable dt = new ZhongLi.BLL.Person().getPersonTest(PerID);
            if (dt.Rows.Count > 0)
            {
                if (new ZhongLi.BLL.Person().editPersonTest(PerID, DateTime.Now.ToString("yyyy-MM-dd hh:mm"), AnsID, TestResUrl))
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
                if (new ZhongLi.BLL.Person().AddPersonTest(PerID, 0, 0, "", TestResUrl, DateTime.Now.ToString("yyyy-MM-dd hh:mm"), AnsID))
                {
                    strResult = "{\"state\":0}";
                }
                else
                {
                    strResult = "{\"state\":1}";
                }
            }

        }
        private void getPersonTest(HttpContext context)
        {
            int PerID = Convert.ToInt32(context.Request["PerID"]);
            DataTable dt = new ZhongLi.BLL.Person().getPersonTest(PerID);
            strResult = JsonConvert.SerializeObject(dt);
        }

        #endregion
        #region 教育经历
        /// <summary>
        /// 得到用户教育经历
        /// </summary>
        /// <param name="context"></param>
        private void getPersonEdu(HttpContext context)
        {
            int perid = Convert.ToInt32(context.Request.QueryString["perid"]);
            DataSet ds = new ZhongLi.BLL.Person_Education().GetList(" PerID=" + perid);
            strResult = JsonConvert.SerializeObject(ds.Tables[0]);
        }
        /// <summary>
        /// 得到教育经历详情
        /// </summary>
        /// <param name="context"></param>
        private void getPersonEduDetail(HttpContext context)
        {
            int PerEduID = Convert.ToInt32(context.Request.QueryString["PerEduID"]);
            ZhongLi.Model.Person_Education personedu = new ZhongLi.BLL.Person_Education().GetModel(PerEduID);
            strResult = JsonConvert.SerializeObject(personedu);
        }
        /// <summary>
        /// 保存教育经历
        /// </summary>
        /// <param name="context"></param>
        private void SavePersonEdu(HttpContext context)
        {
            ZhongLi.Model.Person_Education personedu = new ZhongLi.Model.Person_Education();
            personedu.PerEduID = Convert.ToInt32(context.Request.Form["PerEduID"]);
            personedu.PerID = Convert.ToInt32(context.Request.Form["PerID"]);
            personedu.SchoolName = context.Request.Form["SchoolName"];
            personedu.Major = context.Request.Form["Major"];
            personedu.GraduationYear = context.Request.Form["GraduationYear"];
            personedu.Education = context.Request.Form["Education"];
            personedu.CreateTime = DateTime.Now;
            if (personedu.PerEduID == 0)
            {
                if (new ZhongLi.BLL.Person_Education().Add(personedu) > 0)
                {
                    strResult = "{\"state\":0}";
                }
                else
                {
                    strResult = "{\"state\":1}"; ;
                }
            }
            else
            {
                if (new ZhongLi.BLL.Person_Education().Update(personedu))
                {
                    strResult = "{\"state\":0}";
                }
                else
                {
                    strResult = "{\"state\":1}"; ;
                }
            }

        }
        /// <summary>
        /// 删除求职者教育经历
        /// </summary>
        /// <param name="context"></param>
        private void DelPersonEdu(HttpContext context)
        {
            int PerEduID = Convert.ToInt32(context.Request.Form["PerEduID"]);
            if (new ZhongLi.BLL.Person_Education().Delete(PerEduID))
            {
                strResult = "{\"state\":0}";
            }
            else
            {
                strResult = "{\"state\":1}"; ;
            }
        }
        #endregion

        #region 工作经历
        /// <summary>
        /// 得到求职者工作经历
        /// </summary>
        /// <param name="context"></param>
        private void getPersonWork(HttpContext context)
        {
            string PerID = context.Request.QueryString["PerID"];
            DataSet ds = new ZhongLi.BLL.Person_Work().GetList(" PerID=" + PerID);
            strResult = JsonConvert.SerializeObject(ds.Tables[0]);
        }
        /// <summary>
        /// 得到求职者工作经历详情
        /// </summary>
        /// <param name="context"></param>
        private void getPersonWorkDetail(HttpContext context)
        {
            int PerWorkID = Convert.ToInt32(context.Request.QueryString["PerWorkID"]);
            ZhongLi.Model.Person_Work perwork = new ZhongLi.BLL.Person_Work().GetModel(PerWorkID);
            strResult = JsonConvert.SerializeObject(perwork);
        }
        /// <summary>
        /// 保存求职者工作经历
        /// </summary>
        /// <param name="context"></param>
        private void savePersonWork(HttpContext context)
        {
            ZhongLi.Model.Person_Work personwork = new ZhongLi.Model.Person_Work();
            personwork.PerWordID = Convert.ToInt32(context.Request.Form["PerWorkID"]);
            personwork.PerID = Convert.ToInt32(context.Request.Form["PerID"]);
            personwork.ComPanyName = context.Request.Form["ComPanyName"];
            personwork.Position = context.Request.Form["Position"];
            personwork.EntryTime = context.Request.Form["EntryTime"];
            personwork.QuitTime = context.Request.Form["QuitTime"];
            personwork.WorkCon = context.Request.Form["WorkCon"];
            personwork.CreateTime = DateTime.Now;
            if (personwork.PerWordID == 0)
            {
                if (new ZhongLi.BLL.Person_Work().Add(personwork) > 0)
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
                if (new ZhongLi.BLL.Person_Work().Update(personwork))
                {
                    strResult = "{\"state\":0}";
                }
                else
                {
                    strResult = "{\"state\":0}";
                }
            }
        }

        private void delPersonWork(HttpContext context)
        {
            int PerWorkID = Convert.ToInt32(context.Request.Form["PerWorkID"]);
            if (new ZhongLi.BLL.Person_Work().Delete(PerWorkID))
            {
                strResult = "{\"state\":0}";
            }
            else
            {
                strResult = "{\"state\":1}";
            }
        }
        #endregion

        #region 期望工作
        /// <summary>
        /// 获得职位类型
        /// </summary>
        /// <param name="context"></param>
        private void getPostType(HttpContext context)
        {
            DataTable dt = new ZhongLi.BLL.PostType().GetList(" ParentID=0 Order by Sort").Tables[0];
            strResult = "[";
            foreach (DataRow dr in dt.Rows)
            {
                strResult += "{";
                strResult += "\"ID\":" + dr["ID"] + ",\"PostName\":\"" + dr["PostTypeName"] + "\",";
                strResult += "\"Child\":[";
                DataTable Childdt = new ZhongLi.BLL.PostType().GetList(" ParentID=" + dr["ID"] + " Order by Sort").Tables[0];
                foreach (DataRow childDr in Childdt.Rows)
                {
                    strResult += "{";
                    strResult += "\"ID\":" + childDr["ID"] + ",\"PostName\":\"" + childDr["PostTypeName"] + "\"";
                    strResult += "},";
                }
                strResult = strResult.TrimEnd(',');
                strResult += "]},";
            }
            strResult = strResult.TrimEnd(',');
            strResult += "]";
        }
        private void getExpectWork(HttpContext context)
        {
            string PerID = context.Request.QueryString["PerID"];
            DataSet ds = new ZhongLi.BLL.Person_ExpectWork().GetList(" PerID=" + PerID);
            strResult = JsonConvert.SerializeObject(ds.Tables[0]);
        }

        private void saveExpectWork(HttpContext context)
        {
            ZhongLi.Model.Person_ExpectWork perex = new ZhongLi.Model.Person_ExpectWork();
            perex.PerExID = Convert.ToInt32(context.Request.Form["PerExID"]);
            perex.PerID = Convert.ToInt32(context.Request.Form["PerID"]);
            perex.ExpectedPostion = context.Request.Form["ExpectedPostion"];
            perex.WorkType = context.Request.Form["WorkType"];
            perex.ExCity = context.Request.Form["ExCity"];
            perex.ExSalary = context.Request.Form["ExSalary"];
            perex.ReMark = context.Request.Form["ReMark"];
            perex.CreateTime = DateTime.Now;
            if (perex.PerExID == 0)
            {
                if (new ZhongLi.BLL.Person_ExpectWork().Add(perex) > 0)
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
                if (new ZhongLi.BLL.Person_ExpectWork().Update(perex))
                {
                    strResult = "{\"state\":0}";
                }
                else
                {
                    strResult = "{\"state\":1}";
                }
            }

        }
        #endregion

        #region 项目经历
        private void getPersonPreject(HttpContext context)
        {
            string PerID = context.Request.QueryString["PerID"];
            DataSet ds = new ZhongLi.BLL.Person_Project().GetList(" PerID=" + PerID);
            strResult = JsonConvert.SerializeObject(ds.Tables[0]);
        }
        private void getPersonPrejectDetail(HttpContext context)
        {
            int PerProID = Convert.ToInt32(context.Request.QueryString["PerProID"]);
            ZhongLi.Model.Person_Project perpro = new ZhongLi.BLL.Person_Project().GetModel(PerProID);
            strResult = JsonConvert.SerializeObject(perpro);
        }
        private void savePersonProject(HttpContext context)
        {
            ZhongLi.Model.Person_Project perpro = new ZhongLi.Model.Person_Project();
            perpro.PerProID = Convert.ToInt32(context.Request.Form["PerProID"]);
            perpro.PerID = Convert.ToInt32(context.Request.Form["PerID"]);
            perpro.ProName = context.Request.Form["ProName"];
            perpro.ProDuty = context.Request.Form["ProDuty"];
            perpro.StartTime = context.Request.Form["StartTime"];
            perpro.EndTime = context.Request.Form["EndTime"];
            perpro.ProDes = context.Request.Form["ProDes"];
            if (perpro.PerProID == 0)
            {
                if (new ZhongLi.BLL.Person_Project().Add(perpro) > 0)
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
                if (new ZhongLi.BLL.Person_Project().Update(perpro))
                {
                    strResult = "{\"state\":0}";
                }
                else
                {
                    strResult = "{\"state\":1}";
                }
            }
        }
        private void delPersonProject(HttpContext context)
        {
            int PerProID = Convert.ToInt32(context.Request.Form["PerProID"]);
            if (new ZhongLi.BLL.Person_Project().Delete(PerProID))
            {
                strResult = "{\"state\":0}";
            }
            else
            {
                strResult = "{\"state\":1}";
            }
        }
        #endregion

        #region 技能评价
        private void getPersonSkill(HttpContext context)
        {
            string PerID = context.Request.QueryString["PerID"];
            DataSet ds = new ZhongLi.BLL.Person_Skill().GetList(" PerID=" + PerID);
            strResult = JsonConvert.SerializeObject(ds.Tables[0]);
        }
        private void getPersonSkillDetail(HttpContext context)
        {
            int PerSkillID = Convert.ToInt32(context.Request.QueryString["PerSkillID"]);
            ZhongLi.Model.Person_Skill perskill = new ZhongLi.BLL.Person_Skill().GetModel(PerSkillID);
            strResult = JsonConvert.SerializeObject(perskill);
        }
        private void savePersonSkill(HttpContext context)
        {
            ZhongLi.Model.Person_Skill perskill = new ZhongLi.Model.Person_Skill();
            perskill.PerSkillID = Convert.ToInt32(context.Request.Form["PerSkillID"]);
            perskill.PerID = Convert.ToInt32(context.Request.Form["PerID"]);
            perskill.SkillName = context.Request.Form["SkillName"];
            perskill.MasterDegree = context.Request.Form["MasterDegree"];
            perskill.CreateTime = DateTime.Now;
            if (perskill.PerSkillID == 0)
            {
                if (new ZhongLi.BLL.Person_Skill().Add(perskill) > 0)
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
                if (new ZhongLi.BLL.Person_Skill().Update(perskill))
                {
                    strResult = "{\"state\":0}";
                }
                else
                {
                    strResult = "{\"state\":1}";
                }
            }
        }
        private void delPersonSkill(HttpContext context)
        {
            int PerSkillID = Convert.ToInt32(context.Request.Form["PerSkillID"]);
            if (new ZhongLi.BLL.Person_Skill().Delete(PerSkillID))
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

        #region 悬赏
        /// <summary>
        /// 协议
        /// </summary>
        /// <param name="context"></param>
        private void getAgr(HttpContext context)
        {
            int OrderID = Convert.ToInt32(context.Request.Form["OrderID"]);
            int PerID = Convert.ToInt32(context.Request.Form["PerID"]);
            int SerUserID = Convert.ToInt32(context.Request.Form["SerUserID"]);
            DataTable dt = new ZhongLi.BLL.Person_Reward_Matching().getSerUserRewardMatPostDetail(OrderID, PerID, SerUserID);
            strResult = JsonConvert.SerializeObject(dt);
        }

        /// <summary>
        /// 人才确认入职
        /// </summary>
        /// <param name="context"></param>
        private void PerSetInPost(HttpContext context)
        {
            int PerRewMatID = Convert.ToInt32(context.Request.Form["PerRewMatID"]);
            int OrderID = Convert.ToInt32(context.Request.Form["OrderID"]);
            int SerUserID = Convert.ToInt32(context.Request.Form["SerUserID"]);
            string RealName = context.Request.Form["PerRealName"];
            ZhongLi.Model.siteconfig site = new ZhongLi.Bll.siteconfig().loadConfig(context.Server.MapPath("/xmlconfig/site.config"));
            if (new ZhongLi.BLL.Person_Reward_Matching().PerSetInPost(PerRewMatID, OrderID, SerUserID, site.Commission))
            {
                string SerUserIDs = new ZhongLi.BLL.Person_Reward_Matching().OrderAuthSerUserMsg(OrderID, SerUserID, RealName);
                if (SerUserIDs != "")
                {
                    string[] ids = SerUserIDs.Split(',');
                    JPushApiExample.ALERT = "您的匹配的悬赏订单，求职者" + RealName + "已同意入职其他经纪人的职位";
                    JPushApiExample.MSG_CONTENT = "您的匹配的悬赏订单，求职者" + RealName + "已同意入职其他经纪人的职位";
                    PushPayload pushsms1 = JPushApiExample.PushObject_ios_audienceMore_messageWithExtras("s" + SerUserID, "Order");
                    JPushApiExample.push(pushsms1);
                    JPushApiExample.ALERT = "您的匹配的悬赏订单，求职者" + RealName + "已同意入职其他经纪人的职位";
                    JPushApiExample.MSG_CONTENT = "您的匹配的悬赏订单，求职者" + RealName + "已同意入职其他经纪人的职位";
                    PushPayload pushsms = JPushApiExample.PushObject_ios_audienceMore_messageWithExtras(ids, "Order");
                    JPushApiExample.push(pushsms);
                    strResult = "{\"state\":0}";
                }
                strResult = "{\"state\":0}";
            }
            else
            {
                strResult = "{\"state\":1}";
            }
        }
        /// <summary>
        /// 人才拒绝入职
        /// </summary>
        /// <param name="context"></param>
        private void PerSetFailPost(HttpContext context)
        {
            int PerRewMatID = Convert.ToInt32(context.Request.Form["PerRewMatID"]);
            int SerUserID = Convert.ToInt32(context.Request.Form["SerUserID"]);
            string PerRealName = context.Request.Form["PerRealName"];
            if (new ZhongLi.BLL.Person_Reward_Matching().PerSetFailPost(SerUserID, PerRewMatID, PerRealName))
            {
                JPushApiExample.ALERT = "您的悬赏订单求职者" + PerRealName + "已拒绝入职";
                JPushApiExample.MSG_CONTENT = "您的悬赏订单求职者" + PerRealName + "已拒绝入职";
                PushPayload pushsms = JPushApiExample.PushObject_ios_audienceMore_messageWithExtras("s" + SerUserID, "Order");
                JPushApiExample.push(pushsms);
                strResult = "{\"state\":0}";
            }
            else
            {
                strResult = "{\"state\":1}";
            }
        }

        /// <summary>
        /// 得到人才经纪人匹配的职位
        /// </summary>
        /// <param name="context"></param>
        private void getPersonRewardPost(HttpContext context)
        {
            int PerID = Convert.ToInt32(context.Request.QueryString["PerID"]);
            DataTable dt = new ZhongLi.BLL.Person_Reward_Matching().getSerUserRewardMatPost(PerID);
            strResult = JsonConvert.SerializeObject(dt);
        }
        /// <summary>
        /// 得到人才经纪人匹配的职位详情
        /// </summary>
        /// <param name="context"></param>
        private void getPersonRewardPostDetail(HttpContext context)
        {
            int PerRewMatID = Convert.ToInt32(context.Request.QueryString["PerRewMatID"]);
            DataTable dt = new ZhongLi.BLL.Person_Reward_Matching().getSerUserRewardMatPostDetail(PerRewMatID);
            strResult = JsonConvert.SerializeObject(dt);
        }
        /// <summary>
        /// 确认人才经纪人提供的方案
        /// </summary>
        /// <param name="context"></param>
        private void setPersonRewardPostMat(HttpContext context)
        {
            int PerRewMatID = Convert.ToInt32(context.Request.Form["PerRewMatID"]);
            int PerID = Convert.ToInt32(context.Request.Form["PerID"]);
            int SerUserID = Convert.ToInt32(context.Request.Form["SerUserID"]);
            int OrderID = Convert.ToInt32(context.Request.Form["OrderID"]);
            string PerRealName = context.Request.Form["PerRealName"];
            int num = new ZhongLi.BLL.Person_Reward_Matching().setPersonRewardPostMat(PerRewMatID, OrderID, PerID, SerUserID, PerRealName);
            if (num > 0)
            {
                JPushApiExample.ALERT = "求职者" + PerRealName + "接受了您的职位方案，去我的订单查看吧";
                JPushApiExample.MSG_CONTENT = "求职者" + PerRealName + "接受了您的职位方案，去我的订单查看吧";
                PushPayload pushsms = JPushApiExample.PushObject_ios_audienceMore_messageWithExtras("s" + SerUserID, "Order");
                JPushApiExample.push(pushsms);
                strResult = "{\"state\":0,\"OrderID\":" + num + "}";
            }
            else
            {
                strResult = "{\"state\":0}";
            }
        }
        /// <summary>
        /// 忽略人才经纪人提供的方案
        /// </summary>
        /// <param name="context"></param>
        private void setPersonRewardNoMat(HttpContext context)
        {
            int PerRewMatID = Convert.ToInt32(context.Request.Form["PerRewMatID"]);
            string PerRealName = context.Request.Form["PerRealName"];
            int SerUserID = Convert.ToInt32(context.Request.Form["SerUserID"]);
            if (new ZhongLi.BLL.Person_Reward_Matching().setPersonRewardPostNoMat(PerRewMatID, PerRealName, SerUserID))
            {
                JPushApiExample.ALERT = "求职者" + PerRealName + "拒绝了您的职位方案，去我的订单查看吧";
                JPushApiExample.MSG_CONTENT = "求职者" + PerRealName + "拒绝了您的职位方案，去我的订单查看吧";
                PushPayload pushsms = JPushApiExample.PushObject_ios_audienceMore_messageWithExtras("s" + SerUserID, "Order");
                JPushApiExample.push(pushsms);
                strResult = "{\"state\":0}";
            }
            else
            {
                strResult = "{\"state\":1}";
            }
        }
        /// <summary>
        /// 用户的悬赏
        /// </summary>
        /// <param name="context"></param>
        private void getPersonReward(HttpContext context)
        {
            string PerID = context.Request.QueryString["PerID"];
            DataSet ds = new ZhongLi.BLL.Person_Reward().GetList(" PerID=" + PerID);
            strResult = JsonConvert.SerializeObject(ds.Tables[0]);
        }
        /// <summary>
        /// 悬赏详情
        /// </summary>
        /// <param name="context"></param>
        private void getPersonRewardDetail(HttpContext context)
        {
            int PerRewardID = Convert.ToInt32(context.Request.QueryString["PerRewardID"]);
            ZhongLi.Model.Person_Reward perreward = new ZhongLi.BLL.Person_Reward().GetModel(PerRewardID);
            strResult = JsonConvert.SerializeObject(perreward);
        }
        /// <summary>
        /// 添加悬赏
        /// </summary>
        /// <param name="context"></param>
        private void addPersonReward(HttpContext context)
        {
            ZhongLi.Model.Person_Reward reward = new ZhongLi.Model.Person_Reward();
            reward.PerID = Convert.ToInt32(context.Request.Form["PerID"]);
            //reward.PerRewardID = Convert.ToInt32(context.Request.Form["PerRewardID"]);
            reward.IsDelete = 0;
            reward.RewardState = 0;
            reward.RewardTime = DateTime.Now;
            reward.Trade = context.Request.Form["Trade"];
            reward.CompanySize = context.Request.Form["CompanySize"];
            reward.CompanyNature = context.Request.Form["CompanyNature"];
            reward.EngagePost = context.Request.Form["EngagePost"];
            reward.DemandPay = context.Request.Form["DemandPay"];
            reward.JobCity = context.Request.Form["JobCity"];
            reward.OtherDemand = context.Request.Form["OtherDemand"];
            reward.CompanyMatching = context.Request.Form["CompanyMatching"];
            reward.RewardMoney = Convert.ToDecimal(context.Request.Form["RewardMoney"]);
            reward.OtherDemandDes = context.Request.Form["OtherDemandDes"];
            reward.Education = context.Request.Form["Education"];
            reward.WorkLife = context.Request.Form["WorkLife"];
            if (new ZhongLi.BLL.Person_Reward().Add(reward) > 0)
            {
                strResult = "{\"state\":0}";
            }
            else
            {
                strResult = "{\"state\":1}";
            }
        }
        /// <summary>
        /// 修改悬赏
        /// </summary>
        /// <param name="context"></param>
        private void editPersonReward(HttpContext context)
        {
            ZhongLi.Model.Person_Reward reward = new ZhongLi.Model.Person_Reward();
            reward.PerRewardID = Convert.ToInt32(context.Request.Form["PerRewardID"]);
            reward.Trade = context.Request.Form["Trade"];
            reward.CompanySize = context.Request.Form["CompanySize"];
            reward.CompanyNature = context.Request.Form["CompanyNature"];
            reward.EngagePost = context.Request.Form["EngagePost"];
            reward.DemandPay = context.Request.Form["DemandPay"];
            reward.JobCity = context.Request.Form["JobCity"];
            reward.OtherDemand = context.Request.Form["OtherDemand"];
            reward.CompanyMatching = context.Request.Form["CompanyMatching"];
            reward.RewardMoney = Convert.ToDecimal(context.Request.Form["RewardMoney"]);
            reward.OtherDemandDes = context.Request.Form["OtherDemandDes"];
            reward.Education = context.Request.Form["Education"];
            reward.WorkLife = context.Request.Form["WorkLife"];
            if (new ZhongLi.BLL.Person_Reward().editPersonReward(reward))
            {
                strResult = "{\"state\":0}";
            }
            else
            {
                strResult = "{\"state\":1}";
            }
        }
        /// <summary>
        /// 删除悬赏
        /// </summary>
        /// <param name="context"></param>
        private void delPersonReward(HttpContext context)
        {
            string PerRewardID = context.Request.Form["PerRewardID"];
            if (new ZhongLi.BLL.Person_Reward().Delete(Convert.ToInt32(PerRewardID)))
            {
                strResult = "{\"state\":0}";
            }
            else
            {
                strResult = "{\"state\":1}";
            }
        }
        public void getMatState(HttpContext context)
        {
            int PerRewMatID = Convert.ToInt32(context.Request.QueryString["PerRewMatID"]);
            int State = new ZhongLi.BLL.Person_Reward_Matching().GetState(PerRewMatID);
            strResult = "{\"state\":" + State + "}";
        }
        #endregion

        #region 好友
        /// <summary>
        /// 删除好友
        /// </summary>
        /// <param name="context"></param>
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
        /// 人才的好友
        /// </summary>
        /// <param name="context"></param>
        private void PerFriend(HttpContext context)
        {
            string PerID = context.Request.QueryString["PerID"];
            DataSet dt = new ZhongLi.BLL.Friends().PersonFriend(PerID);
            strResult = JsonConvert.SerializeObject(dt);
        }
        /// <summary>
        /// 判断是否是好友
        /// </summary>
        /// <param name="context"></param>
        private void IsFriend(HttpContext context)
        {
            int PerID = Convert.ToInt32(context.Request.Form["PerID"]);//求职者ID
            int SerUserID = Convert.ToInt32(context.Request.Form["SerUserID"]);//经纪人ID
            int state = new ZhongLi.BLL.Friends().PerIsFriend(PerID, SerUserID);
            strResult = "{\"state\":" + state + "}";//0 可添加  1 已申请 2已经是好友
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
            string SerRealName = context.Request.Form["SerRealName"];//经纪人姓名
            if (new ZhongLi.BLL.Friends().PersonApply(PerID, PerRealName, SerUserID, SerRealName, 0))
            {
                JPushApiExample.ALERT = "求职者" + PerRealName + "申请添加您为好友";
                JPushApiExample.MSG_CONTENT = "求职者" + PerRealName + "申请添加您为好友";
                PushPayload pushsms = JPushApiExample.PushObject_ios_audienceMore_messageWithExtras("s" + SerUserID, "Friend");
                JPushApiExample.push(pushsms);
                strResult = "{\"state\":0}";//添加成功
            }
            else
            {
                strResult = "{\"state\":1}";//添加失败
            }
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
            string PerRealName = context.Request.Form["RealName"];
            if (new ZhongLi.BLL.Friends().AgreeApply(PerID, SerUserID, ApplyID))
            {
                JPushApiExample.ALERT = "求职者" + PerRealName + "同意了您的好友申请";
                JPushApiExample.MSG_CONTENT = "求职者" + PerRealName + "同意了您的好友申请";
                PushPayload pushsms = JPushApiExample.PushObject_ios_audienceMore_messageWithExtras("s" + SerUserID, "Friend");
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
            int SerUserID = Convert.ToInt32(context.Request.Form["SerUserID"]);
            string RealName = context.Request.Form["RealName"];
            if (new ZhongLi.BLL.Friends().PerRefuseApply(ApplyID, SerUserID, RealName))
            {
                JPushApiExample.ALERT = "求职者" + RealName + "拒绝了您的好友申请";
                JPushApiExample.MSG_CONTENT = "求职者" + RealName + "拒绝了您的好友申请";
                PushPayload pushsms = JPushApiExample.PushObject_ios_audienceMore_messageWithExtras("s" + SerUserID, "Friend");
                JPushApiExample.push(pushsms);
                strResult = "{\"state\":0}";//拒绝成功
            }
            else
            {
                strResult = "{\"state\":1}";//拒绝失败
            }
        }

        #endregion

        #region 订单
        /// <summary>
        /// 得到订单状态
        /// </summary>
        /// <param name="context"></param>
        public void getOrderState(HttpContext context)
        {
            int OrderID = Convert.ToInt32(context.Request.QueryString["OrderID"]);
            int State = new ZhongLi.BLL.Reward_Order().getOrderState(OrderID);
            strResult = "{\"state\":" + State + "}";
        }


        /// <summary>
        /// 根据订单ID得到已接受的职位方案
        /// </summary>
        /// <param name="context"></param>
        private void getMatPostByOrder(HttpContext context)
        {
            int OrderID = Convert.ToInt32(context.Request.QueryString["OrderID"]);
            DataTable dt = new ZhongLi.BLL.Person_Reward_Matching().getPostByOrderID(OrderID);
            strResult = JsonConvert.SerializeObject(dt);
        }

        /// <summary>
        /// 延期订单
        /// </summary>
        /// <param name="context"></param>
        private void OrderDelay(HttpContext context)
        {
            int OrderID = Convert.ToInt32(context.Request.Form["OrderID"]);
            if (new ZhongLi.BLL.Reward_Order().OrderDelay(OrderID))
            {
                strResult = "{\"state\":0}";
            }
            else
            {
                strResult = "{\"state\":1}";
            }
        }
        /// <summary>
        /// 针对职位发送悬赏订单
        /// </summary>
        /// <param name="context"></param>
        private void setRewardOrderByPost(HttpContext context)
        {
            //添加悬赏订单。 添加匹配信息 状态为3 待人才经纪人确认
            int PerID = Convert.ToInt32(context.Request.Form["PerID"]);
            int SerUserID = Convert.ToInt32(context.Request.Form["SerUserID"]);
            int PostID = Convert.ToInt32(context.Request.Form["PostID"]);
            string RealName = context.Request.Form["RealName"];
            string SerRealName = context.Request.Form["SerRealName"];
            DataTable dt = new ZhongLi.BLL.Person_Reward().GetList(" PerID=" + PerID).Tables[0];
            DataRow dr = dt.Rows[0];
            ZhongLi.Model.ServerUser_Post post = new ZhongLi.BLL.ServerUser_Post().GetModel(PostID);
            ZhongLi.Model.Reward_Order order = new ZhongLi.Model.Reward_Order();
            Random r = new Random();
            int n = r.Next(0, 100);
            string OrderNum = "y" + DateTime.Now.ToString("yyyyMMddHHmmssms") + n.ToString().PadLeft(2, '0');
            order.OrderNum = OrderNum;
            order.PerRewardID = Convert.ToInt32(dr["PerRewardID"]);
            order.PostID = PostID;
            order.RewardMoney = Convert.ToDecimal(dr["RewardMoney"]);
            DateTime time = DateTime.Now;
            order.CreateTime = time;
            if (Convert.ToDecimal(dr["RewardMoney"]) == 0)//悬赏金额为 0  则不用支付 订单状态变为11
            {
                order.OrderState = 11;//订单状态11  表示已支付 等待人才经纪人确认悬赏订单  
            }
            else
            {
                order.OrderState = 0;
            }
            order.PerID = PerID;
            order.RealName = RealName;
            order.SerUserID = SerUserID;
            order.SerRealName = SerRealName;
            order.IsDelete = 0;
            order.Trade = dr["Trade"] + "";
            order.CompanySize = dr["CompanySize"] + "";
            order.CompanyNature = dr["CompanyNature"] + "";
            order.EngagePost = dr["EngagePost"] + "";
            order.DemandPay = dr["DemandPay"] + "";
            order.JobCity = dr["JobCity"] + "";
            order.OtherDemand = dr["OtherDemand"] + "";
            order.CompanyMatching = dr["CompanyMatching"] + "";
            order.OtherDemandDes = dr["OtherDemandDes"] + "";
            order.Education = dr["Education"] + "";
            order.WorkLife = dr["WorkLife"] + "";
            order.RewardTime = Convert.ToDateTime(dr["RewardTime"]);
            order.Company = post.Company;
            order.Post_Trade = post.Trade;
            order.Scale = post.Scale;
            order.Nature = post.Nature;
            order.PostName = post.PostName;
            order.PostDuty = post.PostDuty;
            order.Salary = post.Salary;
            order.DevelopProspect = post.DevelopProspect;
            order.DirectLeader = post.DirectLeader;
            order.WorkAdress = post.WorkAdress;
            order.Address = post.Address;
            order.WelfareTag = post.WelfareTag;
            order.Post_CompanyMatching = post.CompanyMatching;
            order.OtherPoint = post.OtherPoint;
            order.AutoImg = "";
            int OrderID = new ZhongLi.BLL.Reward_Order().Add(order);
            if (OrderID > 0)
            {
                if (order.OrderState == 11)
                {
                    //免费订单  直接等待人才经纪人确认 添加确认项
                    ZhongLi.Model.Person_Reward_Matching prm = new ZhongLi.Model.Person_Reward_Matching();
                    prm.PerID = PerID;
                    prm.OrderID = OrderID;
                    prm.PerRewID = order.PerRewardID;
                    prm.SerUserID = SerUserID;
                    prm.SerPostID = PostID;
                    prm.MatchingTime = time;
                    prm.State = 3;
                    prm.IsDelete = 0;
                    new ZhongLi.BLL.Person_Reward_Matching().Add(prm);
                    //系统消息
                    ZhongLi.Model.ServerUser_Message sermsg = new ZhongLi.Model.ServerUser_Message();
                    sermsg.MesCon = "您的职位有新的悬赏订单等待确认哦，赶紧去“我匹配的悬赏”里面查看吧";
                    sermsg.SendTime = time;
                    sermsg.SerUserID = SerUserID;
                    sermsg.MesType = 2;
                    new ZhongLi.BLL.ServerUser_Message().Add(sermsg);

                }
                strResult = "{\"state\":0,\"OrderID\":" + OrderID + "}";
            }
            else
            {
                strResult = "{\"state\":0,\"OrderID\":" + OrderID + "}";
            }

        }
        /// <summary>
        /// 判断订单是否快要到期
        /// </summary>
        /// <param name="context"></param>
        private void IsOrderTimeOver(HttpContext context)
        {
            ZhongLi.Model.siteconfig site = new ZhongLi.Bll.siteconfig().loadConfig(context.Server.MapPath("/xmlconfig/site.config"));
            int PerID = Convert.ToInt32(context.Request.QueryString["PerID"]);
            strResult = new ZhongLi.BLL.Reward_Order().IsOrderOver(PerID, site.SetOrderTime); ;
        }
        /// <summary>
        /// 判断是否可以发送订单
        /// </summary>
        /// <param name="context"></param>
        private void checkIsSendOrder(HttpContext context)
        {
            int PerID = Convert.ToInt32(context.Request.QueryString["PerID"]);
            int IsSendOrder = new ZhongLi.BLL.Person().IsSendOrder(PerID);//判断了期望工作  测评 和悬赏
            strResult = "{\"state\":" + IsSendOrder + "}";
        }
        /// <summary>
        /// 添加订单
        /// </summary>
        /// <param name="context"></param>
        private void AddOrder(HttpContext context)
        {
            int PerID = Convert.ToInt32(context.Request.Form["PerID"]);
            int PerRewardID = Convert.ToInt32(context.Request.Form["PerRewardID"]);
            strResult = new ZhongLi.BLL.Reward_Order().AddOrder(PerID, PerRewardID);
        }
        /// <summary>
        /// 支付宝回调
        /// </summary>
        /// <param name="context"></param>
        public void AliPayOrderResult(HttpContext context)
        {
            //WxLogger("进入回调函数", context);
            //try
            //{
            //    Dictionary<string, string> sPara = GetRequestPost(context);
            //    string notify_id = context.Request.Form["notify_id"];//获取notify_id
            //    sPara.Remove("action");
            //    string sign = context.Request.Form["sign"];//获取sign
            //    //过滤空值、sign与sign_type参数
            //    Dictionary<string, string> aaa = Core.FilterPara(sPara);


            //    //获取待签名字符串
            //    string preSignStr = Core.CreateLinkString(aaa);
            //    WxLogger("参数:" + preSignStr, context);
            //    if (notify_id != null && notify_id != "")//判断是否有带返回参数
            //    {
            //        Notify aliNotify = new Notify();
            //        WxLogger("issign:" + aliNotify.GetSignVeryfy(sPara, sign), context);
            //        WxLogger("ResponseTxt:" + aliNotify.GetResponseTxt(context.Request.Form["notify_id"]), context);
            //        //WxLogger("公钥:" + Notify.getPublicKeyStr(Config.alipay_public_key), context);
            //        if (aliNotify.GetResponseTxt(notify_id) == "true")
            //        {
            //            if (aliNotify.GetSignVeryfy(sPara, sign))
            //            {
            //                //卖家支付宝账号	//订单号//
            //                WxLogger("验证成功", context);
            //                WxLogger("订单号：" + sPara["out_trade_no"], context);
            //                //WxLogger("金额：" + total_amount + " 实收金额：" + receipt_amount, context);
            //                //修改订单状态
            //                string t = sPara["out_trade_no"].Substring(0, 1);
            //                WxLogger("编号" + sPara["out_trade_no"] + "--t:" + t, context);
            //                if (t.Equals("d"))
            //                {
            //                    WxLogger("订单", context);
            //                    if (new ZhongLi.BLL.Reward_Order().isOrderState(sPara["out_trade_no"]))
            //                    {
            //                        bool issuss = new ZhongLi.BLL.Reward_Order().modOrderStateByOrderNum(sPara["out_trade_no"], "支付宝");
            //                        WxLogger("修改数据库：" + issuss, context);
            //                    }
            //                    else
            //                    {
            //                        WxLogger("已修改数据库：" + sPara["out_trade_no"], context);
            //                    }
            //                }
            //                else if (t.Equals("c"))
            //                {
            //                    WxLogger("充值", context);
            //                    if (new ZhongLi.BLL.Person().IsPayCheck(sPara["out_trade_no"]))
            //                    {
            //                        bool issuss = new ZhongLi.BLL.Person().EditPayCheck(sPara["out_trade_no"]);
            //                        WxLogger("修改数据库：" + issuss, context);
            //                    }
            //                    else
            //                    {
            //                        WxLogger("已修改数据库" + sPara["out_trade_no"], context);
            //                    }
            //                }
            //                else if (t.Equals("y"))
            //                {
            //                    WxLogger("指定职位订单悬赏", context);
            //                    if (new ZhongLi.BLL.Reward_Order().isOrderState(sPara["out_trade_no"]))
            //                    {
            //                        bool issuss = new ZhongLi.BLL.Reward_Order().modOrderStateByNumPost(sPara["out_trade_no"], "支付宝");
            //                    }
            //                    else
            //                    {

            //                    }
            //                }
            //                strResult = "success";
            //            }
            //            else
            //            {
            //                WxLogger("订单号：" + sPara["out_trade_no"], context);
            //                WxLogger("验证失败", context);
            //                strResult = "failure";
            //            }

            //        }
            //        else
            //        {
            //            strResult = "response fail!";
            //        }
            //    }
            //    else
            //    {
            //        // Response.Write("非通知参数!");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    WxLogger("异常：" + ex.Message, context);
            //}
        }
        //日志
        void WxLogger(string log, HttpContext context)
        {
            string logFile = context.Request.MapPath("/log.txt");

            File.AppendAllText(logFile, string.Format("{0}:{1}\r\n", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), log));

        }
        /// <summary>
        /// 求职者悬赏页面悬赏金额大于0的订单
        /// </summary>
        private void PerRewardOrder(HttpContext context)
        {
            string perid = context.Request.QueryString["PerID"];
            DataTable dt = new ZhongLi.BLL.Reward_Order().PerOrderMoney(perid);
            strResult = JsonConvert.SerializeObject(dt);
        }
        /// <summary>
        /// 人才的订单
        /// </summary>
        /// <param name="context"></param>
        private void PerOrder(HttpContext context)
        {
            string perid = context.Request.QueryString["PerID"];
            DataTable dt = new ZhongLi.BLL.Reward_Order().PerOrder(perid);
            strResult = JsonConvert.SerializeObject(dt);
        }
        /// <summary>
        /// 订单详情
        /// </summary>
        /// <param name="context"></param>
        private void getOrderDetail(HttpContext context)
        {
            int OrderID = Convert.ToInt32(context.Request.QueryString["OrderID"]);
            ZhongLi.Model.Reward_Order order = new ZhongLi.BLL.Reward_Order().GetModel(OrderID);
            strResult = JsonConvert.SerializeObject(order);
        }
        /// <summary>
        /// 得到订单支付的简略信息
        /// </summary>
        /// <param name="context"></param>
        private void getOrderPayInfo(HttpContext context)
        {
            int PerID = Convert.ToInt32(context.Request.QueryString["PerID"]);
            int OrderID = Convert.ToInt32(context.Request.QueryString["OrderID"]);
            DataTable dt = new ZhongLi.BLL.Reward_Order().getOrderPayInfo(PerID, OrderID);
            if (dt.Rows.Count > 0)
            {
                strResult = "{\"state\":0,\"OrderNum\":\"" + dt.Rows[0]["OrderNum"] + "\",\"EngagePost\":\"" + dt.Rows[0]["EngagePost"] + "\",\"PostName\":\"" + dt.Rows[0]["PostName"] + "\",\"RewardMoney\":" + dt.Rows[0]["RewardMoney"] + ",\"Balance\":" + dt.Rows[0]["Balance"] + "}";
            }
            else
            {
                strResult = "{\"state\":1}";
            }
        }
        /// <summary>
        /// 得到余额
        /// </summary>
        /// <param name="context"></param>
        private void getBalance(HttpContext context)
        {
            string PerID = context.Request.QueryString["PerID"];
            decimal b = new ZhongLi.BLL.Person().getBalance(PerID);
            strResult = "{\"balance\":" + b + "}";
        }
        /// <summary>
        /// 订单余额支付
        /// </summary>
        /// <param name="context"></param>
        private void OrderPay(HttpContext context)
        {
            int PerID = Convert.ToInt32(context.Request.Form["PerID"]);
            int OrderID = Convert.ToInt32(context.Request.Form["OrderID"]);
            if (new ZhongLi.BLL.Person().BalancePay(PerID, OrderID))
            {
                strResult = "{\"state\":0}";
            }
            else
            {
                strResult = "{\"state\":1}";
            }
        }
        /// <summary>
        /// 订单确认上传入职 合照
        /// </summary>
        /// <param name="context"></param>
        private void setOrderAutoImg(HttpContext context)
        {
            string photo64 = context.Request.Form["img64str"];
            int OrderID = Convert.ToInt32(context.Request.Form["OrderID"]);
            string FileUrl = "";
            if (photo64 != "")
            {
                byte[] buffer = Convert.FromBase64String(photo64);
                FileUrl = "/upload/order/" + Guid.NewGuid().ToString() + ".png";
                string sFilePath = context.Server.MapPath(FileUrl);
                File.WriteAllBytes(sFilePath, buffer);
            }
            if (new ZhongLi.BLL.Reward_Order().setOrderAutoImg(FileUrl, OrderID))
            {
                strResult = "{\"state\":0,\"Photo\":\"" + FileUrl + "\"}";
            }
            else
            {
                strResult = "{\"state\":1}";
            }
        }
        private void getAutoImg(HttpContext context)
        {
            int OrderID = Convert.ToInt32(context.Request.QueryString["OrderID"]);
            string img = new ZhongLi.BLL.Reward_Order().getAutoImg(OrderID);
            strResult = "{\"AutoImg\":\"" + img + "\"}";
        }
        /// <summary>
        /// 人才入职失败 
        /// </summary>
        /// <param name="context"></param>
        private void perOrderFail(HttpContext context)
        {
            int OrderID = Convert.ToInt32(context.Request.Form["OrderID"]);
            if (new ZhongLi.BLL.Reward_Order().editOrderState(OrderID, 4))
            {
                strResult = "{\"state\":0}";
            }
            else
            {
                strResult = "{\"state\":1}";
            }
        }
        /// <summary>
        /// 取消订单
        /// </summary>
        /// <param name="context"></param>
        private void CanceOrder(HttpContext context)
        {
            int OrderID = Convert.ToInt32(context.Request.Form["OrderID"]);
            int PerID = Convert.ToInt32(context.Request.Form["PerID"]);
            string RealName = context.Request.Form["PerRealName"];
            string EngagePost = context.Request.Form["EngagePost"];
            if (new ZhongLi.BLL.Reward_Order().CanceOrder(OrderID, PerID))
            {
                string SerUserids = new ZhongLi.BLL.Person_Reward_Matching().OrderAuthSerUserMsg(OrderID, RealName);
                if (SerUserids != "")
                {
                    SerUserids = SerUserids.TrimEnd(',');
                    string[] ids = SerUserids.Split(',');
                    JPushApiExample.ALERT = "求职者" + RealName + "取消了悬赏订单，您的匹配的悬赏职位" + EngagePost + "已失效";
                    JPushApiExample.MSG_CONTENT = "求职者" + RealName + "取消了悬赏订单，您的匹配的悬赏职位" + EngagePost + "已失效";
                    PushPayload pushsms = JPushApiExample.PushObject_ios_audienceMore_messageWithExtras(ids, "Order");
                    JPushApiExample.push(pushsms);
                }
                strResult = "{\"state\":0}";
            }
            else
            {
                strResult = "{\"state\":1}";
            }

        }
        /// <summary>
        /// 启用订单
        /// </summary>
        /// <param name="context"></param>
        private void UsingOrder(HttpContext context)
        {
            int OrderID = Convert.ToInt32(context.Request.Form["OrderID"]);
            if (new ZhongLi.BLL.Reward_Order().UsingOrder(OrderID))
            {
                strResult = "{\"state\":0}";
            }
            else
            {
                strResult = "{\"state\":1}";
            }
        }
        #endregion

        #region 经纪人
        /// <summary>
        /// 更多独家职位
        /// </summary>
        /// <param name="context"></param>
        private void moreSolePost(HttpContext context)
        {
            int PageIndex = Convert.ToInt32(context.Request.Form["PageIndex"]);
            DataTable dt = new ZhongLi.BLL.ServerUser_Post().moreSolePost(PageIndex);
            strResult = JsonConvert.SerializeObject(dt);
        }

        /// <summary>
        /// 首页职位筛选
        /// </summary>
        /// <param name="context"></param>
        private void getHomePostSearch(HttpContext context)
        {
            int PerID = Convert.ToInt32(context.Request.Form["PerID"]);
            string salary = context.Request.Form["Salary"];//薪资
            string ComMat = context.Request.Form["ComMat"];//福利
            string NotIn = context.Request.Form["NotIn"];
            int PageIndex = Convert.ToInt32(context.Request.Form["PageIndex"]);
            DataTable dt = new ZhongLi.BLL.ServerUser_Post().HomePagePersonPost(PerID, salary, ComMat, PageIndex, NotIn);
            strResult = JsonConvert.SerializeObject(dt); ;
        }
        private void SerUserList(HttpContext context)
        {
            int PageIndex = Convert.ToInt32(context.Request.QueryString["PageIndex"]);
            DataTable dt = new ZhongLi.BLL.ServerUser().SerUserList(PageIndex);
            strResult = JsonConvert.SerializeObject(dt);
        }
        /// <summary>
        /// 职位列表
        /// </summary>
        /// <param name="context"></param>
        private void SerUserPostList(HttpContext context)
        {
            int PageIndex = Convert.ToInt32(context.Request.Form["PageIndex"]);
            string Key = context.Request.Form["Key"];
            Key = Key.Replace("insert", "").Replace("select", "").Replace("script", "").Replace("update", "").Replace("delete", "");
            DataTable dt = new ZhongLi.BLL.ServerUser_Post().GetListByPage(" PostName like '%" + Key + "%'", " Convert(int,Colvalue),SeeCount desc,CreateTime desc", (PageIndex - 1) * 20 + 1, PageIndex * 20).Tables[0];
            strResult = JsonConvert.SerializeObject(dt);
        }
        /// <summary>
        /// 独家职位
        /// </summary>
        /// <param name="context"></param>
        private void getSolePost(HttpContext context)
        {
            int PerID = Convert.ToInt32(context.Request.Form["PerID"]);
            DataSet ds = new ZhongLi.BLL.ServerUser_Post().HomePagePost(PerID);
            strResult = JsonConvert.SerializeObject(ds);
        }
        /// <summary>
        /// 职位浏览量+1
        /// </summary>
        private void SerUserPostSee(HttpContext context)
        {
            int SerUserPostID = Convert.ToInt32(context.Request.Form["SerUserPostID"]);
            new ZhongLi.BLL.ServerUser_Post().PostSeeCount(SerUserPostID);
            strResult = "{\"state\":0}";
        }
        #endregion

        #region 身份认证
        /// <summary>
        /// 身份认证
        /// </summary>
        /// <param name="context"></param>
        private void setAuthImg(HttpContext context)
        {
            try
            {
                int PerID = Convert.ToInt32(context.Request.Form["PerID"]);
                string str64Img = context.Request.Form["AuthImg"];
                string FileUrl = "";
                if (str64Img != "")
                {
                    byte[] buffer = Convert.FromBase64String(str64Img);
                    FileUrl = "/upload/person/auto/" + Guid.NewGuid().ToString() + ".png";
                    string sFilePath = context.Server.MapPath(FileUrl);
                    File.WriteAllBytes(sFilePath, buffer);
                }
                if (new ZhongLi.BLL.Person().setAutoImg(PerID, FileUrl))
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
        /// 得到用户认证状态
        /// </summary>
        /// <param name="context"></param>
        private void getFlagState(HttpContext context)
        {
            string PerID = context.Request.QueryString["PerID"];
            int Flag = new ZhongLi.BLL.Person().getFlag(PerID);
            strResult = "{\"state\":0,\"flag\":" + Flag + "}";
        }
        #endregion

        #region 人才提示消息
        /// <summary>
        /// 得到所有未读的消息数量
        /// </summary>
        /// <param name="context"></param>
        private void getMsgCount(HttpContext context)
        {
            int PerID = Convert.ToInt32(context.Request.QueryString["PerID"]);
            int count = new ZhongLi.BLL.Person_Message().getMsgCount(PerID);
            strResult = "{\"count\":" + count + "}";
        }
        /// <summary>
        /// 得到各个类型消息类型
        /// </summary>
        /// <param name="context"></param>
        private void getMsgCountByType(HttpContext context)
        {
            int PerID = Convert.ToInt32(context.Request.QueryString["PerID"]);
            DataTable dt = new ZhongLi.BLL.Person_Message().getMsgCountByType(PerID);
            strResult = JsonConvert.SerializeObject(dt);
        }
        /// <summary>
        /// 根据类型得到未读消息
        /// </summary>
        /// <param name="context"></param>
        private void getMsgByType(HttpContext context)
        {
            int PerID = Convert.ToInt32(context.Request.QueryString["PerID"]);
            int MsgType = Convert.ToInt32(context.Request.QueryString["MsgType"]);
            DataTable dt = new ZhongLi.BLL.Person_Message().getMsgByType(PerID, MsgType);
            strResult = JsonConvert.SerializeObject(dt);
        }
        #endregion
        #region 交易记录
        /// <summary>
        /// 人才交易记录
        /// </summary>
        /// <param name="context"></param>
        private void getPersonRecord(HttpContext context)
        {
            int perid = Convert.ToInt32(context.Request.QueryString["PerID"]);
            int PageIndex = Convert.ToInt32(context.Request.QueryString["PageIndex"]);
            DataTable dt = new ZhongLi.BLL.TransactionRecord().getRecord(perid, 0, PageIndex);
            strResult = JsonConvert.SerializeObject(dt);
        }
        /// <summary>
        /// 添加充值单据
        /// </summary>
        /// <param name="context"></param>
        private void AddPayCheck(HttpContext context)
        {
            int PerID = Convert.ToInt32(context.Request.Form["PerID"]);
            decimal Money = Convert.ToDecimal(context.Request.Form["Money"]);
            string PayType = context.Request.Form["PayType"];
            string RealName = context.Request.Form["realname"];
            if (PerID != 0 && PerID != null)
            {
                string num = new ZhongLi.BLL.Person().AddPayCheck(PerID, RealName, Money, PayType);
                strResult = "{\"PayCheckNum\":\"" + num + "\"}";
            }
            else
            {
                strResult = "{\"PayCheckNum\":\"\"}";
            }

        }
        /// <summary>
        /// 获取支付宝POST过来通知消息，并以“参数名=参数值”的形式组成数组
        /// </summary>
        /// <returns>request回来的信息组成的数组</returns>
        public Dictionary<string, string> GetRequestPost(HttpContext context)
        {
            int i = 0;
            Dictionary<string, string> sArray = new Dictionary<string, string>();
            NameValueCollection coll;
            //Load Form variables into NameValueCollection variable.
            coll = context.Request.Form;

            // Get names of all forms into a string array.
            String[] requestItem = coll.AllKeys;

            for (i = 0; i < requestItem.Length; i++)
            {
                sArray.Add(requestItem[i], context.Request.Form[requestItem[i]]);
            }

            return sArray;
        }
        /// <summary>
        /// 充值回调
        /// </summary>
        /// <param name="context"></param>
        private void PayCheck(HttpContext context)
        {
            WxLogger("进入充值回调函数", context);
            try
            {
                IDictionary<string, string> dic = GetRequestPost(context);
                #region 注销
                //IDictionary<string, string> dic = new Dictionary<string, string>();
                //string notify_time = context.Request.Form["notify_time"];
                //string notify_type = context.Request.Form["notify_type"];
                //string notify_id = context.Request.Form["notify_id"];
                //string app_id = context.Request.Form["app_id"];
                //string sign_type = context.Request.Form["sign_type"];
                //string sign = context.Request.Form["sign"];
                //string trade_no = context.Request.Form["trade_no"];
                //string out_trade_no = context.Request.Form["out_trade_no"];
                //string out_biz_no = context.Request.Form["out_biz_no"];
                //string buyer_id = context.Request.Form["buyer_id"];
                //string buyer_logon_id = context.Request.Form["buyer_logon_id"];
                //string seller_id = context.Request.Form["seller_id"];
                //string seller_email = context.Request.Form["seller_email"];
                //string trade_status = context.Request.Form["trade_status"];
                //string total_amount = context.Request.Form["total_amount"];
                //string receipt_amount = context.Request.Form["receipt_amount"];
                //string invoice_amount = context.Request.Form["invoice_amount"];
                //string buyer_pay_amou = context.Request.Form["buyer_pay_amou"];
                //string point_amount = context.Request.Form["point_amount"];
                //string refund_fee = context.Request.Form["refund_fee"];
                //string send_back_fee = context.Request.Form["send_back_fee"];
                //string subject = context.Request.Form["subject"];
                //string body = context.Request.Form["body"];
                //string gmt_create = context.Request.Form["gmt_create"];
                //string gmt_payment = context.Request.Form["gmt_payment"];
                //string gmt_refund = context.Request.Form["gmt_refund"];
                //string gmt_close = context.Request.Form["gmt_close"];
                //string fund_bill_list = context.Request.Form["fund_bill_list"];
                //dic.Add("notify_time", notify_time);
                //dic.Add("notify_type", notify_type);
                //dic.Add("notify_id", notify_id);
                //dic.Add("app_id", app_id);
                //dic.Add("sign_type", sign_type);
                //dic.Add("sign", sign);
                //dic.Add("trade_no", trade_no);
                //dic.Add("out_trade_no", out_trade_no);
                //dic.Add("out_biz_no", out_biz_no);
                //dic.Add("buyer_id", buyer_id);
                //dic.Add("buyer_logon_id", buyer_logon_id);
                //dic.Add("seller_id", seller_id);
                //dic.Add("seller_email", seller_email);
                //dic.Add("trade_status", trade_status);
                //dic.Add("total_amount", total_amount);
                //dic.Add("receipt_amount", receipt_amount);
                //dic.Add("invoice_amount", invoice_amount);
                //dic.Add("buyer_pay_amou", buyer_pay_amou);
                //dic.Add("point_amount", point_amount);
                //dic.Add("refund_fee", refund_fee);
                //dic.Add("send_back_fee", send_back_fee);
                //dic.Add("subject", subject);
                //dic.Add("body", body);
                //dic.Add("gmt_create", gmt_create);
                //dic.Add("gmt_payment", gmt_payment);
                //dic.Add("gmt_refund", gmt_refund);
                //dic.Add("gmt_close", gmt_close);
                //dic.Add("fund_bill_list", fund_bill_list);
                #endregion
                if (dic.Count > 0)
                {
                    //byte[] newSign = Convert.FromBase64String(sign);
                    //WxLogger( AlipaySignature.GetSignContent(dic),context);
                    //string pubkeypem = "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCnxj/9qwVfgoUh/y2W89L6BkRAFljhNhgPdyPuBV64bfQNN1PjbCzkIM6qRdKBoLPXmKKMiFYnkd6rAoprih3/PrQEB/VsW8OoM8fxn67UDYuyBTqA23MML9q1+ilIZwBC2AQ2UBVOrFXfFl75p6/B5KsiNG9zpgmLCUYuLkxpLQIDAQAB";
                    ////WxLogger(AlipaySignature.RSACheckV1(dic, pubkeypem)+"验证结果",context);
                    //if (AlipaySignature.RSACheckV1(dic, pubkeypem,"utf-8"))
                    //{
                    string num = dic["out_trade_no"].Trim();
                    //    //卖家支付宝账号	//订单号//
                    //    WxLogger("验证成功", context);
                    //    WxLogger("订单号：" + num, context);
                    //    WxLogger("金额：" + dic["total_amount"] + " 实收金额：" + dic["receipt_amount"], context);
                    //修改订单状态
                    WxLogger("提现号：" + num, context);
                    if (new ZhongLi.BLL.Person().IsPayCheck(num))
                    {
                        //bool issuss = new ZhongLi.BLL.Person().EditPayCheck(num);
                        //WxLogger("修改数据库：" + issuss, context);
                    }
                    else
                    {
                        WxLogger("已修改数据库" + dic["out_trade_no"], context);
                    }

                    //}
                    //else
                    //{
                    //    WxLogger("验证失败", context);
                    //}
                    strResult = "success";
                }
                else
                {
                    WxLogger("无参数", context);
                }
            }
            catch (Exception ex)
            {
                WxLogger("异常：" + ex.Message, context);
            }
        }
        /// <summary>
        /// 添加提现申请
        /// </summary>
        /// <param name="context"></param>
        //private void AddPresent(HttpContext context)
        //{
        //    int PerID = Convert.ToInt32(context.Request["PerID"]);
        //    string RealName=context.Request["RealName"];
        //    int PreType = Convert.ToInt32(context.Request["PreType"]);
        //    string Account=context.Request["Account"];
        //    decimal Money=Convert.ToDecimal(context.Request["Money"]);
        //    if (new ZhongLi.BLL.PresentApplication().AddPresent(PerID, RealName, PreType, Account, Money, 0))
        //    {
        //        strResult = "{\"state\":0}";
        //    }
        //    else
        //    {
        //        strResult = "{\"state\":1}";
        //    }

        //}
        private void test(HttpContext context)
        {
            new ZhongLi.BLL.Reward_Order().modOrderStateByOrderNum("", "支付宝");
        }
        #endregion
        #region 用户反馈
        /// <summary>
        /// 得到用户反馈
        /// </summary>
        /// <param name="context"></param>
        private void GetFeedBack(HttpContext context)
        {
            int UserID = Convert.ToInt32(context.Request.Form["UserID"]);
            int UserType = Convert.ToInt32(context.Request.Form["UserType"]);
            int PageIndex = Convert.ToInt32(context.Request.Form["PageIndex"]);
            DataTable dt = new ZhongLi.BLL.FeedBack().GetListByPage("", " ID desc", 10 * (PageIndex - 1) + 1, PageIndex * 10).Tables[0];
            strResult = JsonConvert.SerializeObject(dt);
        }
        /// <summary>
        /// 添加用户反馈
        /// </summary>
        private void AddFeedBack(HttpContext context)
        {
            int UserID = Convert.ToInt32(context.Request["UserID"]);
            string UserName = context.Request["UserName"];
            int UserType = Convert.ToInt32(context.Request["UserType"]);
            string Con = context.Request["Con"];
            ZhongLi.Model.FeedBack fb = new ZhongLi.Model.FeedBack();
            fb.UserID = UserID;
            fb.UserName = UserName;
            fb.UserType = UserType;
            fb.Con = Con;
            fb.CreateTime = DateTime.Now;
            fb.State = 0;
            if (new ZhongLi.BLL.FeedBack().Add(fb) > 0)
            {
                strResult = "{\"state\":0}";
            }
            else
            {
                strResult = "{\"state\":1}";
            }
        }
        #endregion
        #region 首页 新闻 职业培训 职业规划
        /// <summary>
        /// 热门滚动新闻
        /// </summary>
        /// <param name="context"></param>
        private void hotNews(HttpContext context)
        {
            DataTable dt = new ZhongLi.BLL.News().GetList(5, " Hot='True'", "CreateTime Desc").Tables[0];
            strResult = JsonConvert.SerializeObject(dt);
        }
        /// <summary>
        /// 新闻列表
        /// </summary>
        /// <param name="context"></param>
        private void newsList(HttpContext context)
        {
            int PageIndex = Convert.ToInt32(context.Request.QueryString["PageIndex"]);
            DataTable dt = new ZhongLi.BLL.News().GetListByPage(" Hot='False'", "CreateTime Desc", (PageIndex - 1) * 10 + 1, PageIndex * 10).Tables[0];
            strResult = JsonConvert.SerializeObject(dt);
        }
        // <summary>
        /// 新闻详情
        /// </summary>
        /// <param name="context"></param>
        private void newsDetail(HttpContext context)
        {
            int NewsID = Convert.ToInt32(context.Request.QueryString["NewsID"]);
            ZhongLi.Model.News news = new ZhongLi.BLL.News().GetModel(NewsID);
            strResult = JsonConvert.SerializeObject(news);
        }
        /// <summary>
        /// 职业规划top5
        /// </summary>
        /// <param name="context"></param>
        private void careerPlan(HttpContext context)
        {
            DataTable dt = new ZhongLi.BLL.CareerPlanning().GetList(5, "", " Sort desc").Tables[0];
            strResult = JsonConvert.SerializeObject(dt);
        }
        /// <summary>
        /// 职业规划列表
        /// </summary>
        /// <param name="context"></param>
        private void careerPlanList(HttpContext context)
        {
            int PageIndex = Convert.ToInt32(context.Request.QueryString["PageIndex"]);
            DataTable dt = new ZhongLi.BLL.CareerPlanning().GetListByPage("", " Sort desc", (PageIndex - 1) * 10 + 1, PageIndex * 10).Tables[0];
            strResult = JsonConvert.SerializeObject(dt);
        }
        /// <summary>
        /// 职业规划详情
        /// </summary>
        /// <param name="context"></param>
        private void careerPlanDetail(HttpContext context)
        {
            int CPID = Convert.ToInt32(context.Request.QueryString["CPID"]);
            ZhongLi.Model.CareerPlanning cp = new ZhongLi.BLL.CareerPlanning().GetModel(CPID);
            strResult = JsonConvert.SerializeObject(cp);
        }
        /// <summary>
        /// 职业培训top5
        /// </summary>
        /// <param name="context"></param>
        private void JobTr(HttpContext context)
        {
            DataTable dt = new ZhongLi.BLL.JobTraining().GetList(5, "", " Sort desc").Tables[0];
            strResult = JsonConvert.SerializeObject(dt);
        }
        /// <summary>
        /// 职业培训列表
        /// </summary>
        /// <param name="context"></param>
        private void JobTrList(HttpContext context)
        {
            int PageIndex = Convert.ToInt32(context.Request.QueryString["PageIndex"]);
            DataTable dt = new ZhongLi.BLL.JobTraining().GetListByPage("", " Sort desc", (PageIndex - 1) * 10 + 1, PageIndex * 10).Tables[0];
            strResult = JsonConvert.SerializeObject(dt);
        }
        /// <summary>
        /// 职业培训详情
        /// </summary>
        /// <param name="context"></param>
        private void JobTrDetail(HttpContext context)
        {
            int JobTraID = Convert.ToInt32(context.Request.QueryString["JobTraID"]);
            ZhongLi.Model.JobTraining jp = new ZhongLi.BLL.JobTraining().GetModel(JobTraID);
            strResult = JsonConvert.SerializeObject(jp);
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