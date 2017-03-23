﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.Web.Security;
using ZhongLi.Common;
using System.Net;
using System.IO;

namespace WebSystem.Systestcomjun.AppCode
{
    public class PushClass
    {
        private string AppID = "A6913849878138";
        private string AppKey = "FF30497E-10A5-BC6E-F666-7F2D09B14D92";

        public string title { get; set; }
        public string content { get; set; }
        public string type { get; set; }
        public string platform { get; set; }
        public string groupName { get; set; }
        public string userIds { get; set; }

        //title–消息标题，
        //content – 消息内容
        //type – 消息类型，1:消息 2:通知
        //platform - 0:全部平台，1：ios, 2：android
        //groupName - 推送组名，多个组用英文逗号隔开.默认:全部组。eg.group1,group2 .
        //userIds - 推送用户id, 多个用户用英文逗号分隔，eg. user1,user2。
        public void ts_01()
        {
            string formData = String.Format("title={0}&content={1}&type={2}&platform={3}&userIds={4}", title, content, type, 0, userIds);
            //标题1 内容2 消息1/通知2 平台0全部1ios2案桌 制定用户5    （还可以制定群组）

            string url = String.Format("https://p.apicloud.com/api/push/message");
            System.Net.HttpWebRequest request = System.Net.HttpWebRequest.Create(url) as System.Net.HttpWebRequest;
            request.Method = "POST";
            request.Headers.Add("X-APICloud-AppId", AppID);
            request.Headers.Add("X-APICloud-AppKey", GetSHA1Key(AppID, AppKey));
            //aha1加密
            request.ContentType = "application/x-www-form-urlencoded";

            byte[] postData = System.Text.Encoding.UTF8.GetBytes(formData);
            request.ContentLength = postData.Length;

            using (System.IO.Stream reqStream = request.GetRequestStream())
            {
                //StreamWriter reqWriter = new StreamWriter(reqStream);
                reqStream.Write(postData, 0, postData.Length);
                //reqWriter.Write(formData);
                using (var response = request.GetResponse() as System.Net.HttpWebResponse)
                {
                    using (System.IO.Stream respSream = response.GetResponseStream())
                    {
                        System.IO.StreamReader respReader = new System.IO.StreamReader(respSream);
                        string result = respReader.ReadToEnd();

                        //Console.WriteLine(result);
                    }
                }
            }
        }
        //sha1加密
        static String GetSHA1Key(String AppId, String AppKey)
        {

            long longTime = (long)(DateTime.Now - new DateTime(1970, 01, 01)).TotalMilliseconds;
            String value = String.Format("{0}UZ{1}UZ{2}", AppId, AppKey, longTime);
            byte[] buffer = System.Security.Cryptography.SHA1.Create().ComputeHash(System.Text.Encoding.UTF8.GetBytes(value));
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            foreach (byte num in buffer)
            {
                builder.AppendFormat("{0:x2}", num);
            }
            return builder.ToString() + "." + longTime;
        }
      
    }
}