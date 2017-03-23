using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSystem.Systestcomjun.AppCode
{
    public class RYToken
    {
        private string AppKey = "3argexb6rrtwe";
        private string AppSecret = "CPUjCJCglGz3";


        public string getToken(string id,string realname,string photo)
        {
            string formData = String.Format("userId={0}&name={1}&portraitUri={2}", id, realname, photo);
            Random r = new Random();
            int Nonce = r.Next(1,1000000);
            long longTime = (long)(DateTime.Now - new DateTime(1970, 01, 01)).TotalMilliseconds;
            string url = String.Format("https://api.cn.ronghub.com/user/getToken.json");
            System.Net.HttpWebRequest request = System.Net.HttpWebRequest.Create(url) as System.Net.HttpWebRequest;
            request.Method = "POST";
            request.Headers.Add("App-Key", AppKey);
            request.Headers.Add("Nonce",Nonce+"");
            request.Headers.Add("Timestamp", longTime + "");
            request.Headers.Add("Signature", GetSHA1Key(AppSecret, Nonce, longTime));
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

                        return result;
                    }
                }
            }
        }

        //sha1加密
        static String GetSHA1Key(string AppSecret, int Nonce, long longTime)
        {
            String value = String.Format("{0}{1}{2}", AppSecret, Nonce, longTime);
            byte[] buffer = System.Security.Cryptography.SHA1.Create().ComputeHash(System.Text.Encoding.UTF8.GetBytes(value));
            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            foreach (byte num in buffer)
            {
                builder.AppendFormat("{0:x2}", num);
            }
            return builder.ToString();
        }
    }
}