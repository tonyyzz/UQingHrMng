using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using System.IO;
using System.IO.Compression;
using System.Text.RegularExpressions;

/// <summary>
/// HttpWebResponseUtility 的摘要说明
/// </summary>
public class HttpWebResponseUtility
{
    /// <summary>    
    /// 创建POST方式的HTTP请求    
    /// </summary>    
    /// <param name="url">请求的URL</param>    
    /// <param name="parameters">随同请求POST的参数名称及参数值字典</param>    
    /// <param name="timeout">请求的超时时间</param>    
    /// <param name="userAgent">请求的客户端浏览器信息，可以为空</param>    
    /// <param name="requestEncoding">发送HTTP请求时所用的编码</param>    
    /// <param name="cookies">随同HTTP请求发送的Cookie信息，如果不需要身份验证可以为空</param>    
    /// <returns></returns>    
    public static HttpWebResponse CreatePostHttpResponse(string url, IDictionary<string, string> parameters, int? timeout, string userAgent, Encoding requestEncoding, CookieCollection cookies)
    {
        if (string.IsNullOrEmpty(url))
        {
            throw new ArgumentNullException("url");
        }
        if (requestEncoding == null)
        {
            throw new ArgumentNullException("requestEncoding");
        }
        HttpWebRequest request = null;
        //如果是发送HTTPS请求    
        if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
        {
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
            request = WebRequest.Create(url) as HttpWebRequest;
            request.ProtocolVersion = HttpVersion.Version10;
        }
        else
        {
            request = WebRequest.Create(url) as HttpWebRequest;
        }
        request.Method = "POST";
        request.ContentType = "application/x-www-form-urlencoded";
        //如果需要POST数据    
        if (!(parameters == null || parameters.Count == 0))
        {
            StringBuilder buffer = new StringBuilder();
            int i = 0;
            foreach (string key in parameters.Keys)
            {
                if (i > 0)
                {
                    buffer.AppendFormat("&{0}={1}", key, parameters[key]);
                }
                else
                {
                    buffer.AppendFormat("{0}={1}", key, parameters[key]);
                }
                i++;
            }
            byte[] data = Encoding.UTF8.GetBytes(buffer.ToString());
            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }
        }
        return request.GetResponse() as HttpWebResponse;
    }


    private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
    {
        return true; //总是接受    
    }


    public static string SendHttpRequest(string url, string data)
    {
        return SendPostHttpRequest(url, "application/x-www-form-urlencoded", data);
    }
    public static string GetData(string url)
    {
        return SendGetHttpRequest(url, "application/x-www-form-urlencoded");
    }

    /// <summary>
    /// 发送请求
    /// </summary>
    /// <param name="url">Url地址</param>
    /// <param name="method">方法（post或get）</param>
    /// <param name="method">数据类型</param>
    /// <param name="requestData">数据</param>
    public static string SendPostHttpRequest(string url, string contentType, string requestData)
    {
        WebRequest request = (WebRequest)HttpWebRequest.Create(url);
        request.Method = "POST";
        byte[] postBytes = null;
        request.ContentType = contentType;
        postBytes = Encoding.UTF8.GetBytes(requestData);
        request.ContentLength = postBytes.Length;
        using (Stream outstream = request.GetRequestStream())
        {
            outstream.Write(postBytes, 0, postBytes.Length);
        }
        string result = string.Empty;
        using (WebResponse response = request.GetResponse())
        {
            if (response != null)
            {
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                    {
                        result = reader.ReadToEnd();
                    }
                }

            }
        }
        return result;
    }

    /// <summary>
    /// 发送请求
    /// </summary>
    /// <param name="url">Url地址</param>
    /// <param name="method">方法（post或get）</param>
    /// <param name="method">数据类型</param>
    /// <param name="requestData">数据</param>
    public static string SendGetHttpRequest(string url, string contentType)
    {
        WebRequest request = (WebRequest)HttpWebRequest.Create(url);
        request.Method = "GET";
        request.ContentType = contentType;
        string result = string.Empty;
        using (WebResponse response = request.GetResponse())
        {
            if (response != null)
            {
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                    {
                        result = reader.ReadToEnd();
                    }
                }
            }
        }
        return result;
    }



    public static string PostRequest(string url, string[] paramName, string[] paramValue)
    {
        // 编辑并Encoding提交的数据  
        StringBuilder sbuilder = new StringBuilder(paramName[0] + "=" + paramValue[0]);
        for (int i = 1; i < paramName.Length; i++)
            sbuilder.Append("&" + paramName[i] + "=" + paramValue[i]);
        byte[] data = new ASCIIEncoding().GetBytes(sbuilder.ToString());

        // 发送请求  
        var request = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);
        request.Method = "POST";
        request.ContentType = "application/x-www-form-urlencoded";
        request.ContentLength = data.Length;
        Stream stream = request.GetRequestStream();
        stream.Write(data, 0, data.Length);
        stream.Close();

        // 获得回复  
        var response = (System.Net.HttpWebResponse)request.GetResponse();
        var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
        var result = reader.ReadToEnd();
        reader.Close();

        return result;
    }
    /// <summary>
    /// 发送银行请求
    /// </summary>
    /// <param name="parameters">发送数据</param>
    /// <param name="url">接收地址</param>
    /// <param name="errInfo">错误信息</param>
    /// <returns>返回请求结果或错误信息</returns>
    public static string PostDataBySsl(string parameters, string url, out string errInfo)
    {

        errInfo = string.Empty;
        try
        {
            byte[] data = Encoding.GetEncoding("gb2312").GetBytes(parameters);
            WebRequest webRequest = WebRequest.Create(url);
            var httpRequest = webRequest as HttpWebRequest;
            if (httpRequest != null)
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(ValidateServerCertificate);
                httpRequest.Method = "POST";
                httpRequest.UserAgent = "liliwang";
                httpRequest.ContentType = "application/x-fox";
                httpRequest.ContentLength = data.Length;
                Stream requestStream = httpRequest.GetRequestStream();
                requestStream.Write(data, 0, data.Length);
                requestStream.Close();
                Stream responseStream = null;
                var getResponse = httpRequest.GetResponse();
                responseStream = getResponse.GetResponseStream();
                string stringResponse = string.Empty;
                if (responseStream != null)
                {
                    using (var responseReader =
                        new StreamReader(responseStream, Encoding.GetEncoding("GBK")))
                    {
                        stringResponse = responseReader.ReadToEnd();
                    }
                    responseStream.Close();
                }
                return stringResponse;
            }
            else
            {
                return string.Empty;
            }
        }
        catch (Exception e)
        {
            errInfo = e.Message;
            return string.Empty;
        }
    }

    public static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
        return true;
    }


}