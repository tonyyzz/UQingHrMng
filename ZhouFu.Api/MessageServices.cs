using System;
using System.Collections.Concurrent;
using System.Configuration;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Xml;
using Top.Api;
using Top.Api.Request;
using Top.Api.Response;
using ZhongLi.Common;


namespace ZhongLi.Api
{

    public static class MessageServices
    {
        #region 模板短信发送


        /// <summary>
        /// 发送注册验证码短信
        /// </summary>
        /// <param name="PhoneNumber">手机号码（多个手机号码请用逗号隔开）</param>
        /// <param name="Captcha">手机验证码</param>
        /// <returns>返回是否发送成功</returns>
        public static string SendRegistrationMessage(string PhoneNumber, string Captcha)
        {
            //string conent = string.Format("尊敬的用户，您好！欢迎您注册华盟金融{0}网站会员，您的验证码是{1}。", PublicMethod.GetSiteName(), Captcha);//【更改手机短信内容】
            string smsParam = "{\"code\":\"" + Captcha + "\",\"product\":\"优青网\"}";
            string smsTemplateCode = "SMS_13261999";
            //if (JySendInfo(PhoneNumber, conent))
            if (ALiDaYuSendInfo(PhoneNumber, smsParam, smsTemplateCode))
            {
                return "发送成功";
            }
            else
            {
                return "发送失败 失败原因：";
            }

        }

        /// <summary>
        /// 修改密码验证短信
        /// </summary>
        /// <param name="PhoneNumber">手机号码（多个手机号码请用逗号隔开）</param>
        /// <param name="Captcha">手机验证码</param>
        /// <returns>返回是否发送成功</returns>
        public static string SendCaptchaMessage(string PhoneNumber, string Captcha)
        {
            //string conent = string.Format("欢迎使用{0}网站会员，您的手机验证码是{1}。如非本人操作请致电：{2}。或回复TD退订", PublicMethod.GetSiteName(), Captcha, PublicMethod.GetSiteTell());//【更改手机短信内容】
            string smsParam = "{\"code\":\"" + Captcha + "\",\"product\":\"优青网\"}";
            string smsTemplateCode = "SMS_13261997";
            if (ALiDaYuSendInfo(PhoneNumber, smsParam, smsTemplateCode))
            {
                return "发送成功";
            }
            else
            {
                return "发送失败 失败原因：";
            }

        }
        /// <summary>
        /// 通用验证短信
        /// </summary>
        /// <param name="PhoneNumber">手机号码（多个手机号码请用逗号隔开）</param>
        /// <param name="Captcha">手机验证码</param>
        /// <returns>返回是否发送成功</returns>
        public static string SendPublicMessage(string PhoneNumber, string Captcha)
        {
            //string conent = string.Format("欢迎使用{0}网站会员，您的手机验证码是{1}。如非本人操作请致电：{2}。或回复TD退订", PublicMethod.GetSiteName(), Captcha, PublicMethod.GetSiteTell());//【更改手机短信内容】
            string smsParam = "{\"code\":\"" + Captcha + "\"}";
            string smsTemplateCode = "SMS_13706275";
            if (ALiDaYuSendInfo(PhoneNumber, smsParam, smsTemplateCode))
            {
                return "发送成功";
            }
            else
            {
                return "发送失败 失败原因：";
            }
        }

		/// <summary>
		/// 给经纪人发送悬赏订单短信通知
		/// </summary>
		/// <returns></returns>
		public static string SendToSerOrderInfo(string SerPhoneNumber, string SerName, string PerName)
		{
			//string conent = string.Format("欢迎使用{0}网站会员，您的手机验证码是{1}。如非本人操作请致电：{2}。或回复TD退订", PublicMethod.GetSiteName(), Captcha, PublicMethod.GetSiteTell());//【更改手机短信内容】
			string smsParam = "{\"SerName\":\"" + SerName + "\",\"PerName\":\"" + PerName + "\"}";
			string smsTemplateCode = "SMS_58460022";
			if (ALiDaYuSendInfo(SerPhoneNumber, smsParam, smsTemplateCode))
			{
				return "发送成功";
			}
			else
			{
				return "发送失败 失败原因：";
			}

		}
		/// <summary>
		/// 给经纪人发送悬赏订单短信通知
		/// </summary>
		/// <returns></returns>
		public static string SendToPerOrderSuccessInfo(string perPhoneNumber, string perName, string serName)
		{
			//string conent = string.Format("欢迎使用{0}网站会员，您的手机验证码是{1}。如非本人操作请致电：{2}。或回复TD退订", PublicMethod.GetSiteName(), Captcha, PublicMethod.GetSiteTell());//【更改手机短信内容】
			string smsParam = "{\"PerName\":\"" + perName + "\",\"SerName\":\"" + serName + "\"}";
			string smsTemplateCode = "SMS_58825018";
			if (ALiDaYuSendInfo(perPhoneNumber, smsParam, smsTemplateCode))
			{
				return "发送成功";
			}
			else
			{
				return "发送失败 失败原因：";
			}

		}
        #endregion


        #region 阿里大鱼短信平台，2016年5月7日

        public static bool ALiDaYuSendInfo(string mobile, string smsParam, string smsTemplateCode)
        {
            try
            {
                string url = "http://gw.api.taobao.com/router/rest";
                string appkey = "23440994";//应用Key，一般固定值，在大鱼平台设置。
                string secret = "86bcf90eecf43d146cb57bf2beabc477";//应用密钥，一般固定值，在大鱼平台设置。

                ITopClient client = new DefaultTopClient(url, appkey, secret);
                AlibabaAliqinFcSmsNumSendRequest req = new AlibabaAliqinFcSmsNumSendRequest();
                //req.Extend = "123456";//可选填，这里可以不用设置
                req.SmsType = "normal";
                req.SmsFreeSignName = "优青网";//签名
                //req.SmsParam = "{\"code\":\"1234\",\"product\":\"alidayu\"}"; 例子
                //req.RecNum = 13488997788;
                //req.SmsTemplateCode = "SMS_585014";
                req.SmsParam = smsParam;//参数集合
                req.RecNum = mobile;//电话
                req.SmsTemplateCode = smsTemplateCode;//模板ID
                AlibabaAliqinFcSmsNumSendResponse rsp = client.Execute(req);
                //Console.WriteLine(rsp.Body);
				if (rsp.Result == null)
				{
					return false;
				}
				else
				{
					return rsp.Result.Success;
				}
                //return true;
                //短信接口对接内容...
            }
            catch (Exception ex)
            {
                LoggerHelper.LogError(ex.Message);
            }
            return false;
        }

        #endregion 阿里大鱼短息平台


        #region 竟远三网短信平台



        /// <summary>
        /// 发送短信
        /// </summary>
        /// <param name="mobile">电话号码</param>
        /// <param name="conent">内容</param>
        /// <returns></returns>
        public static bool JySendInfo(string mobile, string conent)
        {
            try
            {
                return true;
                //短信接口对接内容...
            }
            catch (Exception ex)
            {
                LoggerHelper.LogError(ex.Message);
            }
            return false;
        }
        /// <summary>
        /// 随机数数组
        /// </summary>
        private static readonly char[] Constant ={   
        '0','1','2','3','4','5','6','7','8','9'};
        /// <summary>
        ///  生成随机数
        /// </summary>
        /// <param name="length">随机数长度</param>
        /// <returns></returns>
        public static string GenerateRandomNumber(int length)
        {
            var newRandom = new System.Text.StringBuilder(31);
            Random rd = new Random();
            for (int i = 0; i < length; i++)
            {
                newRandom.Append(Constant[rd.Next(10)]);
            }
            return newRandom.ToString();
        }
        #endregion

    }
}
