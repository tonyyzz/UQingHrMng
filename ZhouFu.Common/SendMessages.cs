using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;
using System.Web;


namespace ZhongLi.Common
{
    public class SendMessages
    {
        public static string SendMe(string smsNumber, string smsContent)
        {

            string userid = "6483";//企业ID
            string account = "mike08";			//用户名
            string password = "tyamc8899";	//密码
            string mobile = smsNumber;  //发送号码
            string strContent = smsContent;
            StringBuilder sbTemp = new StringBuilder();
            Encoding myEncoding = Encoding.GetEncoding("UTF-8");
            //POST 传值
            sbTemp.Append("action=send&userid=" + userid + "&account=" + account + "&password=" + password + "&mobile=" + mobile + "&content=" + HttpUtility.UrlEncode(strContent, myEncoding));
            byte[] bTemp = System.Text.Encoding.GetEncoding("UTF-8").GetBytes(sbTemp.ToString());
            String postReturn = doPostRequest("http://inter.ueswt.com/sms.aspx", bTemp);
            //String postReturn = "<?xml version='1.0' encoding='utf-8' ?><returnsms> <returnstatus>Success</returnstatus> <message>ok</message> <remainpoint>5</remainpoint> <taskID>1499844</taskID> <successCounts>1</successCounts></returnsms>";

            XmlDocument xx = new XmlDocument();
            xx.LoadXml(postReturn); //加载xml
            XmlNodeList xxList = xx.GetElementsByTagName("returnstatus"); //取得节点名为row的XmlNode集合
            string returnstatus = string.Empty;//返回状态值：成功返回Success 失败返回：Faild
            foreach (XmlNode xxNode in xxList)
            {
                returnstatus = xxNode.InnerText;
            }
            return returnstatus;
        }

        private static String doPostRequest(string url, byte[] bData)
        {
            System.Net.HttpWebRequest hwRequest;
            System.Net.HttpWebResponse hwResponse;

            string strResult = string.Empty;
            try
            {
                hwRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
                hwRequest.Timeout = 5000;
                hwRequest.Method = "POST";
                hwRequest.ContentType = "application/x-www-form-urlencoded";
                hwRequest.ContentLength = bData.Length;

                System.IO.Stream smWrite = hwRequest.GetRequestStream();
                smWrite.Write(bData, 0, bData.Length);
                smWrite.Close();
            }
            catch (System.Exception err)
            {
                WriteErrLog(err.ToString());
                return strResult;
            }

            //get response
            try
            {
                hwResponse = (HttpWebResponse)hwRequest.GetResponse();
                StreamReader srReader = new StreamReader(hwResponse.GetResponseStream(), Encoding.ASCII);
                strResult = srReader.ReadToEnd();
                srReader.Close();
                hwResponse.Close();
            }
            catch (System.Exception err)
            {
                WriteErrLog(err.ToString());
            }

            return strResult;
        }
        private static void WriteErrLog(string strErr)
        {
            Console.WriteLine(strErr);
            System.Diagnostics.Trace.WriteLine(strErr);
        }
    }
}
