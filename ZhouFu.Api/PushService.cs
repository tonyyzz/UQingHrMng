using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Xml;
using System.Net;
using System.IO;
using System.IO.Compression;

namespace ZhongLi.Api
{
    public class Jpush
    {
        public static string MD5Encrypt(string strSource)
        {
            return MD5Encrypt(strSource, 32);
        }

        /// <summary>  
        /// </summary>  
        /// <param name="strSource">待加密字串</param>  
        /// <param name="length">16或32值之一,其它则采用.net默认MD5加密算法</param>  
        /// <returns>加密后的字串</returns>  
        public static string MD5Encrypt(string strSource, int length)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(strSource);
            byte[] hashValue = ((System.Security.Cryptography.HashAlgorithm)System.Security.Cryptography.CryptoConfig.CreateFromName("MD5")).ComputeHash(bytes);
            StringBuilder sb = new StringBuilder();
            switch (length)
            {
                case 16:
                    for (int i = 4; i < 12; i++)
                        sb.Append(hashValue[i].ToString("x2"));
                    break;
                case 32:
                    for (int i = 0; i < 16; i++)
                    {
                        sb.Append(hashValue[i].ToString("x2"));
                    }
                    break;
                default:
                    for (int i = 0; i < hashValue.Length; i++)
                    {
                        sb.Append(hashValue[i].ToString("x2"));
                    }
                    break;
            }
            return sb.ToString();
        }

        public string doSend(string receiverValue, string content, string msg_type, int receiverType)
        {
            string appkeys = "76cf417f5050e3b5fffdbc68";//appkey
            string secret = "8c6ab98282d47204ae10a2bc";
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            string html = string.Empty;
            int sendno =1;
            String input = sendno.ToString() + receiverType + receiverValue + secret;
            if (receiverType == 4)
            {
                input = sendno.ToString() + receiverType + secret;
            }
            string verificationCode = MD5Encrypt(input);
            string loginUrl = "http://api.jpush.cn:8800/sendmsg/v2/sendmsg";
            parameters.Add("sendno", sendno.ToString());
            parameters.Add("app_key", appkeys);
            parameters.Add("receiver_type", receiverType.ToString());
            if (receiverType==3)
            {
             parameters.Add("receiver_value", receiverValue);
            }
            parameters.Add("verification_code", verificationCode);   //MD5  
            parameters.Add("msg_type", msg_type);
            parameters.Add("msg_content", content);        //内容  
            parameters.Add("platform", "android,ios");
            HttpWebResponse response = HttpWebResponseUtility.CreatePostHttpResponse(loginUrl, parameters, null, null, Encoding.UTF8, null);
            if (response != null)
            {
                // 得到返回的数据流  
                Stream receiveStream = response.GetResponseStream();
                // 如果有压缩,则进行解压  
                if (response.ContentEncoding.ToLower().Contains("gzip"))
                {
                    receiveStream = new GZipStream(receiveStream, CompressionMode.Decompress);
                }
                // 得到返回的字符串  
                html = new StreamReader(receiveStream).ReadToEnd();
            }
            return html;
        }

  }

}