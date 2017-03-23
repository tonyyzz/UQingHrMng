using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Data;
using ThoughtWorks.QRCode.Codec;
using ZhongLi.Common;
using ZhongLi.Model;
using System.Text;
using System.Text.RegularExpressions;
using System.Configuration;
using ZhongLi.DBUtility;

namespace WebSystem.AppCode
{
    public class webHelper
    {



        #region 加载site.config
        public static siteconfig SettingsListLoad()
        {
            ZhongLi.Bll.siteconfig bll = new ZhongLi.Bll.siteconfig();
            ZhongLi.Model.siteconfig site = bll.loadConfig(Utils.GetXmlMapPath(DTKeys.FILE_SITE_XML_CONFING));
            return site;
        }
        #endregion

        //#region 取整数和小数
        //public static float GetInt(int i)
        //{
        //    float f = SettingsListLoad().YearIncome;
        //    string[] s = f.ToString().Split('.');
        //    if (i == 1)
        //    {
        //        return Convert.ToSingle(s[0]);
        //    }
        //    else
        //    {
        //        return Convert.ToSingle(s[1]);
        //    }


        //}
        //#endregion

        #region 获取字典表信息
        public static string GetDictionaryName(object id)
        {
            string strResult = string.Empty;
            if (id != null && id.ToString() != "" && Convert.ToInt32(id) > 0)
            {
                strResult = new ZhongLi.Bll.sys_Dictionary().GetModel(Convert.ToInt32(id)).DtyName + "";
            }
            return strResult;
        }
        #endregion

        #region 获取省份信息
        public static string GetCity(object files, object code)
        {
            string strResult = string.Empty;
            if (files != null && code != null)
            {
                DataSet ds = new ZhongLi.Bll.sys_City().GetList(" code='" + code + "'", files.ToString());
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    strResult = ds.Tables[0].Rows[0][0].ToString();
                }
            }
            return strResult;
        }
        #endregion





        #region 去除内容中的图片
        public static string CutContentImg(object s)
        {
            string rs = s.ToString();
            string reg = "<[^<>]*>|&nbsp;";
            System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex(reg);
            rs = r.Replace(s.ToString(), "").Trim();
            return rs;
        }

        /// <summary>
        /// 清除所有html内容与格式
        /// </summary>
        /// <param name="htmlstring"></param>
        /// <returns></returns>
        public static string RemoveHtml(string htmlstring)
        {
            if (htmlstring == null) throw new ArgumentNullException("htmlstring");
            //删除脚本  
            htmlstring = Regex.Replace(htmlstring, @"<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
            //删除HTML  
            htmlstring = Regex.Replace(htmlstring, @"<(.[^>]*)>", "", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"([\r\n])[\s]+", "", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"-->", "", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"<!--.*", "", RegexOptions.IgnoreCase);

            htmlstring = Regex.Replace(htmlstring, @"&(quot|#34);", "\"", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(amp|#38);", "&", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(lt|#60);", "<", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(gt|#62);", ">", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(nbsp|#160);", "   ", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(iexcl|#161);", "\xa1", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(cent|#162);", "\xa2", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(pound|#163);", "\xa3", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&(copy|#169);", "\xa9", RegexOptions.IgnoreCase);
            htmlstring = Regex.Replace(htmlstring, @"&#(\d+);", "", RegexOptions.IgnoreCase);

            htmlstring = htmlstring.Replace("<", "");
            htmlstring = htmlstring.Replace(">", "");
            htmlstring = htmlstring.Replace("\t", "");
            htmlstring = htmlstring.Replace("\r\n", "");
            htmlstring = HttpContext.Current.Server.HtmlEncode(htmlstring).Trim();

            return htmlstring;
        }

        public static string left(object o, int num, string dian)
        {
            string s = o.ToString().Trim();
            s = CutContentImg(s);
            int num1 = Encoding.Default.GetBytes(s).Length;
            if (num1 > ((num + 1) * 2))
            {
                int num2 = num - 2;
                while (true)
                {
                    string text1 = s.Substring(0, num2);
                    num1 = Encoding.Default.GetBytes(text1).Length;
                    if (num1 >= (2 * num))
                    {
                        return (text1 + dian);
                    }
                    num2++;
                }
            }
            return s;
        }
        #endregion







        #region 日期格式
        public static string GetDateFormater(object time, object formatter)
        {
            string sTime = string.Empty;
            if (!string.IsNullOrEmpty(Convert.ToString(time)))
            {
                sTime = Convert.ToDateTime(time).ToString(formatter.ToString());
            }
            return sTime;
        }
        #endregion


        #region 保留小数
        public static string GetDoubleToAcc(object dValue, string F)
        {
            string sReq = string.Empty;
            sReq = Convert.ToDouble(dValue).ToString(F);
            return sReq;
        }
        #endregion

        #region 获取月份
        public static string GetMonthOps()
        {
            StringBuilder str = new StringBuilder();
            str.Append("<option value=\"0\">请选择</option>");
            for (int i = 1; i <= 24; i++)
            {
                str.Append("<option value=\"" + i + "\">" + i + "个月</option>");
            }
            return str.ToString();
        }
        #endregion

        #region 获取天数
        public static string GetDayOps()
        {
            StringBuilder str = new StringBuilder();
            str.Append("<option value=\"0\">请选择</option>");
            for (int i = 1; i < 60; i++)
            {
                str.Append("<option value=\"" + i + "\">" + i + "天</option>");
            }
            return str.ToString();
        }
        #endregion

        #region 获取字典表信息
        public static string GetDtyNameByIds(object ids)
        {
            string strResult = "未设置";
            if (ids.ToString() == "")
                return strResult;
            DataSet ds = new ZhongLi.Bll.sys_Dictionary().GetList("ID in (" + ids.ToString().Trim(',') + ")");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    strResult += dr["DtyName"] + ",";
                }
            }
            if (strResult != "")
                strResult = strResult.Trim(',');
            return strResult;
        }

        public static string GetDtyFileByIds(object ids, object action)
        {
            string strResult = "";
            if (ids.ToString() == "")
                return strResult;
            DataSet ds = new ZhongLi.Bll.sys_Dictionary().GetList("ID in (" + ids.ToString().Trim(',') + ")");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    if (action != null && action.ToString() == "index")
                        strResult += "<img src=\"" + dr["Filepath"] + "\" title=\"" + dr["DtyName"] + "\"  /></a>";
                    else
                        strResult += "<img src=\"" + dr["Filepath"] + "\" title=\"" + dr["DtyName"] + "\" /></a>";
                }
            }
            if (strResult != "")
                strResult = strResult.Trim(',');
            return strResult;
        }

        /// <summary>
        /// wt修改，适用App版本
        /// </summary>
        /// <param name="ids"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static string GetDtyFileByIdsApp(object ids, object action)
        {
            string strResult = "";
            if (ids.ToString() == "")
                return strResult;
            DataSet ds = new ZhongLi.Bll.sys_Dictionary().GetList("ID in (" + ids.ToString().Trim(',') + ")");
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                DataTable dt = ds.Tables[0];
                foreach (DataRow dr in dt.Rows)
                {
                    if (action != null && action.ToString() == "index")
                        strResult += "<img src=\"" + dr["Filepath"] + "\"  />";
                    else
                        strResult += "<img src=\"" + dr["Filepath"] + "\" />";
                }
            }
            if (strResult != "")
                strResult = strResult.Trim(',');
            return strResult;
        }
        #endregion

        







      







        

        #region 记录日志文件
        public static void InfoToTxt(string fileName, string fileContent)
        {
            string m_LogName = MapPath("/Logs/notifY/" + DateTime.Now.ToString("yyyyMMdd") + fileName + ".txt");
            if (!System.IO.File.Exists(m_LogName))
            {
                System.IO.FileStream fsnew = System.IO.File.Create(m_LogName);
                fsnew.Close();
            }
            using (System.IO.FileStream fs = System.IO.File.Open(m_LogName, System.IO.FileMode.Append, System.IO.FileAccess.Write))
            {
                using (System.IO.StreamWriter w = new System.IO.StreamWriter(fs))
                {
                    w.WriteLine("Content:{0}", fileContent);
                    w.WriteLine("-----------------------------------------------------------------------------------------------------");
                    w.Flush();
                    w.Close();
                }
            }
        }

        public static string MapPath(string strPath)
        {
            if (System.Web.HttpContext.Current != null)
            {
                return System.Web.HttpContext.Current.Server.MapPath(strPath);
            }
            else //非web程序引用      
            {
                strPath = strPath.Replace("/", "");
                strPath = strPath.Replace("~", "");
                if (strPath.StartsWith("//"))
                {
                    strPath = strPath.TrimStart('/');
                }
                return System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, strPath);
            }
        }
        #endregion

        #region 获取时间戳
        /// <summary>  
        /// 获取时间戳  
        /// </summary>  
        /// <returns></returns>  
        public static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }
        #endregion


        #region  将网页地址生成为二维码
        /// <summary>  
        /// 生成二维码图片  
        /// </summary>  
        /// <param name="webUrl">要生成二维码的地址</param>       
        /// <returns>返回二维码保存路径</returns>  
        public static string Create_ImgCode(string webUrl)
        {
            try
            {
                QRCodeEncoder qrCodeEncoder = new QRCodeEncoder();
                qrCodeEncoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                qrCodeEncoder.QRCodeScale = 4;
                qrCodeEncoder.QRCodeVersion = 7;
                qrCodeEncoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;
                //生成二维码
                var bmp = qrCodeEncoder.Encode(webUrl);
                return SaveImg(MapPath("/images/QRcode/"), bmp);//返回图片物理路径
            }
            catch (Exception ex)
            {
                LoggerHelper.LogError("生成二维码：" + ex.ToString());
                return "";
            }
        }

        /// <summary>  
        /// 保存图片  
        /// </summary>  
        /// <param name="strPath">保存路径</param>  
        /// <param name="img">图片</param>  
        public static string SaveImg(string strPath, Bitmap img)
        {
            string fileName = string.Empty;
            //保存图片到目录  
            if (Directory.Exists(strPath))
            {
                //文件名称  
                fileName = DateTime.Now.ToString("yyyyMMddhhmmss") + ".png";
                img.Save(strPath + fileName, System.Drawing.Imaging.ImageFormat.Png);
            }
            else
            {
                //当前目录不存在，则创建  
                Directory.CreateDirectory(strPath);
            }
            return fileName;
        }
        #endregion

        #region 企业认证
        /// <summary>
        /// 企业认证
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetStatusImg(object value)
        {
            if (value.ToString() == "Fales")
            {
                return "无";
            }
            else
            {
                return "<img src=\"/images2.0/info_yes.png\" />";
            }
        }

        #endregion


        #region 添加日志信息
        /// <summary>
        /// 添加日志
        /// </summary>
        /// <param name="content">日志内容</param>
        public static void addLog(string content)
        {
            ZhongLi.Model.sys_Logs log = new ZhongLi.Model.sys_Logs();
            log.UserID = Convert.ToInt32(Utils.GetCookie("UserID"));
            log.Remark = content;
            log.AddTime = DateTime.Now + "";
            log.IpAddress = DTRequest.GetIP();
            new ZhongLi.Bll.sys_Logs().Add(log);
        }
        public static string delInfo(string table,string filed,string keyid,string delids)
        {
            string res = "";
            DataSet ds = DbHelperSQL.Query("select "+filed+" from "+table +" where "+keyid+" in ("+delids+")");
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                res += "[";
                string f = "";
                foreach (object o in dr.ItemArray)
                {
                    f += o + ",";
                }
                if (f != "")
                {
                    f = f.TrimEnd(',');
                    res += f;
                }
                res += "]";
            }
            //if (res != "")
            //{
            //    res = res.TrimEnd(',');
            //}
            return res;
        }
        #endregion
    
    }
}