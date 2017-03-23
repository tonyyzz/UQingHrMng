using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Web;
using System.Text;
using System.Drawing;
using System.IO;

namespace ZhongLi.Common
{
    public class WebHelper
    {
        public static System.Web.Script.Serialization.JavaScriptSerializer jsSeri = new System.Web.Script.Serialization.JavaScriptSerializer();
        /// <summary>
        /// 用户上传图片路径
        /// </summary>
        public static readonly string strUserUploadPath = System.Web.Configuration.WebConfigurationManager.AppSettings["userUploadPath"];

        #region 01.从当前登录用户数据中，获得用户id，如果没有登录则返回0
        /// <summary>
        /// 从当前登录用户数据中，获得用户id，如果没有登录则返回0
        /// </summary>
        /// <returns></returns>
        public static int GetUserId()
        {
            //获得当前正在执行的上下文对象
            HttpContext context = HttpContext.Current;
            int res = 0;
            if (context.Request.Cookies["id"] != null)//如果cookie中有数据
            {
                res = Convert.ToInt32(context.Request.Cookies["id"].Value);
            }
            else if (context.Session["id"] != null)//如果session中有数据
            {
                res = Convert.ToInt32(context.Session["id"]);
            }
            return res;
        }
        #endregion

        #region 02.输出alert字符串
        /// <summary>
        /// 输出alert,location字符串
        /// </summary>
        /// <param name="strMsg"></param>
        /// <param name="strUrl"></param>
        public static void WriteMsg(string strMsg, string strUrl)
        {
            HttpContext.Current.Response.Write("<script type='text/javascript'>alert('" + strMsg + "');window.location='" + strUrl + "';</script>");
        }
        /// <summary>
        /// 输出alert字符串
        /// </summary>
        /// <param name="strMsg"></param>
        public static void WriteMsg(string strMsg)
        {
            HttpContext.Current.Response.Write("<script type='text/javascript'>alert('" + strMsg + "');</script>");
        }
        /// <summary>
        /// 输出alert,top.location字符串
        /// </summary>
        /// <param name="strMsg"></param>
        /// <param name="strUrl"></param>
        public static void WriteMsgSon(string strMsg, string strUrl)
        {
            HttpContext.Current.Response.Write("<script type='text/javascript'>alert('" + strMsg + "');window.top.location='" + strUrl + "';</script>");
        }
        #endregion

        #region  03.获得MD5加密值
        /// <summary>
        /// 03.获得MD5加密值
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string MD5(string str)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "md5").ToUpper();
        }
        #endregion

        /// <summary>
        /// 实现对一个文件md5的读取，path为文件路径
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string md5_hash(string path)
        {
            try
            {
                FileStream get_file = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read);
                System.Security.Cryptography.MD5CryptoServiceProvider get_md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] hash_byte = get_md5.ComputeHash(get_file);
                string resule = System.BitConverter.ToString(hash_byte);
                resule = resule.Replace("-", "");
                return resule;
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }

        #region 04.根据bool值输出 复选框 选中状态属性字符串
        /// <summary>
        /// 根据bool值输出 复选框 选中状态属性字符串
        /// </summary>
        /// <param name="isChecked"></param>
        /// <returns></returns>
        public static string GetChecked(bool isChecked)
        {
            return isChecked ? "checked='checked'" : "";
        }
        #endregion

        #region 05.获得状态选项下拉框选项 (状态 1-公开2-隐藏3-好友公开)
        /// <summary>
        /// 05.获得状态选项下拉框选项 
        /// </summary>
        /// <param name="statu">(状态 1-公开2-隐藏3-好友公开)</param>
        /// <returns></returns>
        public static string GetStatusOpts(int statu)
        {
            if (statu == 1)
            {
                return "<option value=\"1\" selected='true'>公开</option><option value=\"2\">仅自己可见</option><option value=\"3\">对好友公开</option>";
            }
            else if (statu == 2)
            {
                return "<option value=\"1\">公开</option><option value=\"2\" selected='true'>仅自己可见</option><option value=\"3\">对好友公开</option>";
            }
            else
                return "<option value=\"1\">公开</option><option value=\"2\">仅自己可见</option><option value=\"3\" selected='true'>对好友公开</option>";
        }
        #endregion

        #region 06.获取Json字符串 +string Serili(object obj)
        /// <summary>
        /// 获取Json字符串
        /// </summary>
        /// <param name="isChecked"></param>
        /// <returns></returns>
        public static string SerializeJson(object obj)
        {
            return jsSeri.Serialize(obj);
        }
        #endregion

        #region 07.生成返回给浏览器ajax请求的字符串 +string AjaxResult(string statu,string msg)
        /// <summary>
        /// 生成返回给浏览器ajax请求的字符串
        /// </summary>
        /// <param name="statu">状态</param>
        /// <param name="msg">消息</param>
        /// <returns></returns>
        public static string AjaxResult(string statu, string msg)
        {
            return "{\"statu\":\"" + statu + "\",\"msg\":\"" + msg + "\"}";
        }
        /// <summary>
        /// 生成返回给浏览器ajax请求的字符串
        /// </summary>
        /// <param name="statu">状态</param>
        /// <param name="msg">消息</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public static string AjaxResult(string statu, string msg, string data)
        {
            return "{\"statu\":\"" + statu + "\",\"msg\":\"" + msg + "\",\"data\":" + data + "}";
        }

        /// <summary>
        /// 生成返回给浏览器ajax请求的字符串
        /// </summary>
        /// <param name="statu">状态</param>
        /// <param name="msg">消息</param>
        /// <returns></returns>
        public static void AjaxResultOut(string statu, string msg)
        {
            HttpContext.Current.Response.Write("{\"statu\":\"" + statu + "\",\"msg\":\"" + msg + "\"}");
        }
        /// <summary>
        /// 生成返回给浏览器ajax请求的字符串
        /// </summary>
        /// <param name="statu">状态</param>
        /// <param name="msg">消息</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public static void AjaxResultOut(string statu, string msg, string data)
        {
            HttpContext.Current.Response.Write("{\"statu\":\"" + statu + "\",\"msg\":\"" + msg + "\",\"data\":" + data + "}");
        }
        #endregion

        #region 08.生成缩略图 +void MakeThumbImg(HttpPostedFile file, string strFileName, string strExtension, int intThumbWidth, int intThumbHeight)
        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="file">文件对象</param>
        /// <param name="strFileName">不带后缀的文件名</param>
        /// <param name="strExtension">文件后缀</param>
        /// <param name="intThumbWidth">缩略图宽</param>
        /// <param name="intThumbHeight">缩略图高</param>
        public static void MakeThumbImg(HttpPostedFile file, string strFileName, string strExtension, float fThumbWidth, float fThumbHeight)
        {
            //将文件流 转成 图片
            using (Image img = Image.FromStream(file.InputStream))
            {
                float imgW = img.Width;//原图 宽
                float imgH = img.Height;//原图 高
                //根据 原图的 高宽比，算出 缩略图的 高（保证缩略图不变形）
                float thumbWidth;
                float thumbHeight;
                //获取第一张绘制图的大小,(比较 原图的宽/缩略图的宽 和 原图的高/缩略图的高) 
                thumbWidth = imgW;
                thumbHeight = imgH;
                //宽大于高或宽等于高（横向矩形或正方）
                if (imgW > imgH || imgW == imgH)
                {
                    //如果宽大于模版
                    if (imgW > fThumbWidth)
                    {
                        //宽按缩略图宽，高按比例缩放
                        thumbWidth = fThumbWidth;
                        thumbHeight = imgH * (fThumbWidth / imgW);
                    }
                }
                //高大于宽（竖图）
                else
                {
                    //如果高大于模版
                    if (imgH > fThumbHeight)
                    {
                        //高按模版，宽按比例缩放
                        thumbHeight = fThumbHeight;
                        thumbWidth = imgW * (fThumbHeight / imgH);
                    }
                }
                //按照高宽比算出的宽和高来生成缩略图，并保存 
                using (Image imgThumb = new Bitmap((int)thumbWidth, (int)thumbHeight))
                {
                    //创建“画家”对象，并告知在imgThumb上“作画”
                    using (Graphics g = Graphics.FromImage(imgThumb))
                    {
                        //设置缩略图的背景色为透明
                        g.Clear(Color.Transparent);
                        //设置一系列图片质量
                        g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                        //将大图 画到 小图上
                        g.DrawImage(img, new Rectangle(0, 0, imgThumb.Width, imgThumb.Height), new Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
                        //保存缩略图
                        imgThumb.Save(HttpContext.Current.Server.MapPath("/upload/userphoto/" + strFileName + "_thumb" + strExtension));
                    }
                }
            }
        }
        #endregion

        #region 09.生成随机文件名 +string GetRanFileName()
        /// <summary>
        /// 生成随机文件名
        /// </summary>
        /// <returns></returns>
        public static string GetRanFileName()
        {
            return Guid.NewGuid().ToString();
        }
        #endregion

        #region 10.根据原图名获取缩略图名 +string GetThumbFileName()
        /// <summary>
        /// 根据原图名获取缩略图名
        /// </summary>
        /// <returns></returns>
        public static string GetThumbFileName(string orgImgName)
        {
            string[] fArr = orgImgName.Split('.');
            return fArr[0] + "_thumb." + fArr[1];
        }
        #endregion

        #region 11.将相对路径转成物理路径并删除此文件 +void DelFile(string strVirthPath)
        /// <summary>
        /// 将相对路径转成物理路径并删除此文件
        /// </summary>
        /// <param name="strVirthPath"></param>
        public static void DelFile(string strVirthPath)
        {
            //获取物理路径
            string strPhyPath = HttpContext.Current.Request.MapPath(strVirthPath);
            if (System.IO.File.Exists(strPhyPath))
            {
                System.IO.File.Delete(strPhyPath);
            }
        }
        #endregion

        #region +AJAX获得功能页码条
        /// <summary>
        /// AJAX获得功能页码条
        /// </summary>
        /// <param name="funName">js方法名</param>
        /// <param name="allrecord">全部记录条数</param>
        /// <param name="allpage">全部页面数</param>
        /// <param name="curpage">当前页码</param>
        /// <param name="groupsize">页码组大小</param>
        /// <param name="pagesize">页容量</param>
        public static string GetPageTxtAjax(string funName, int allrecord, int allpage, int curpage, int groupsize, int pagesize)
        {
            int curGroupPage = 0;
            StringBuilder test = new StringBuilder();
            StringBuilder test2 = new StringBuilder();
            StringBuilder pagetxt = new StringBuilder();
            if (curpage.Equals("") || curpage < 1) curpage = 1;
            if (allrecord.Equals("") || allrecord < 1) allrecord = 1;
            if (pagesize.Equals("") || pagesize < 1) pagesize = 1;
            if (allrecord == 0) { pagetxt.Append("页码：0/0 │ 共0条</TD> <td align='left'> 首页 << 上一页 | 1 Next | >> 尾页 &nbsp;&nbsp;</td></tr></table>"); }
            else
            {
                test2.Append(allpage.ToString());

                if (allpage.Equals("") || allpage < 1) allpage = 1;
                pagetxt.Append("页码：" + curpage.ToString() + "/" + allpage.ToString() + " │ 共" + allrecord.ToString() + "条");
                pagetxt.Append("<A href='javascript:" + funName + "(1)' title='首页'>1</A>&nbsp;");
                curGroupPage = (((curpage - 1) / groupsize) * groupsize) + 1;

                if (curGroupPage <= 1) pagetxt.Append("<a href='javascript:" + funName + "(" + curGroupPage + ")' title='回到首页'>&lt;&lt;</A>&nbsp;");
                else pagetxt.Append("<a href='javascript:" + funName + "(" + (curGroupPage - 1) + ")' title='前 " + groupsize + " 页'>&lt;&lt;</A>&nbsp;");

                if (curpage <= 1) pagetxt.Append("<A href='javascript:" + funName + "(" + curpage + ")' title='首页'>Prev</A>&nbsp;");
                else pagetxt.Append("<A href='javascript:" + funName + "(" + (curpage - 1) + ")' title='前一页'>Prev</A>&nbsp;");

                int tempI = 0;
                tempI = curGroupPage;//此时获得的是当前页码组的第一页
                do
                {
                    if (tempI == curpage) pagetxt.Append("<span class='nowpage'>" + tempI + "</span>&nbsp;");
                    else pagetxt.Append("<A href='javascript:" + funName + "(" + tempI + ")'>" + tempI + "</A>&nbsp;");
                    tempI = tempI + 1;
                } while (tempI < curGroupPage + groupsize && tempI <= allpage);//生成的页码不能大于 当前 页码组 的最大页，也不能大于 总页数

                if (curpage < allpage) pagetxt.Append("<A href='javascript:" + funName + "(" + (curpage + 1) + ")' title='后一页'>Next</A>&nbsp;");
                else pagetxt.Append("<A href='javascript:" + funName + "(" + curpage + ")' title='后一页'>Next</A>&nbsp;");

                if (curGroupPage + groupsize > allpage) pagetxt.Append("<a href='javascript:" + funName + "(" + allpage + ")' title='后 " + groupsize + " 页'>&gt;&gt;</A>&nbsp;");
                else pagetxt.Append("<a href='javascript:" + funName + "(" + (curGroupPage + groupsize) + ")' title='后" + groupsize + "页'>&gt;&gt;</A>&nbsp;");

                pagetxt.Append("<A href='javascript:" + funName + "(" + allpage + ")' title='最后一页'>" + allpage + "</A>");
            }
            test.Append("allpage=" + allpage + ",allrecord=" + allrecord + ",pagesize=" + pagesize + ",groupsize=" + groupsize + ",curGroupPage=" + curGroupPage + ",curpage=" + curpage);
            return pagetxt.ToString();
        }
        #endregion

        #region +WEBFORM获得功能页码条
        /// <summary>
        /// WEBFORM获得功能页码条
        /// </summary>
        /// <param name="url">页码连接地址</param>
        /// <param name="searcheurl">搜索url</param>
        /// <param name="allrecord">全部记录条数</param>
        /// <param name="allpage">全部页面数</param>
        /// <param name="curpage">当前页码</param>
        /// <param name="groupsize">页码组大小</param>
        /// <param name="pagesize">页容量</param>
        public static string GetPageTxt(string url, string searcheurl, int allrecord, int allpage, int curpage, int groupsize, int pagesize)
        {
            int curGroupPage = 0;
            StringBuilder test = new StringBuilder();
            StringBuilder test2 = new StringBuilder();
            StringBuilder pagetxt = new StringBuilder();
            if (curpage.Equals("") || curpage < 1) curpage = 1;
            if (allrecord.Equals("") || allrecord < 1) allrecord = 1;
            if (pagesize.Equals("") || pagesize < 1) pagesize = 1;
            if (allrecord == 0) { pagetxt.Append("页码：0/0 │ 共0条</TD> <td align='left'> 首页 << 上一页 | 1 Next | >> 尾页 &nbsp;&nbsp;</td></tr></table>"); }
            else
            {
                test2.Append(allpage.ToString());

                if (allpage.Equals("") || allpage < 1) allpage = 1;
                pagetxt.Append("页码：" + curpage.ToString() + "/" + allpage.ToString() + " │ 共" + allrecord.ToString() + "条");
                pagetxt.Append("<A href='" + url + "1' title='首页'>1</A>&nbsp;");
                curGroupPage = (((curpage - 1) / groupsize) * groupsize) + 1;

                if (curGroupPage <= 1) pagetxt.Append("<a href='" + url + curGroupPage + searcheurl + "' title='回到首页'>&lt;&lt;</A>&nbsp;");
                else pagetxt.Append("<a href='" + url + (curGroupPage - 1) + searcheurl + "' title='前 " + groupsize + " 页'>&lt;&lt;</A>&nbsp;");

                if (curpage <= 1) pagetxt.Append("<A href='" + url + curpage + searcheurl + "' title='首页'>Prev</A>&nbsp;");
                else pagetxt.Append("<A href='" + url + (curpage - 1) + searcheurl + "' title='前一页'>Prev</A>&nbsp;");

                int tempI = 0;
                tempI = curGroupPage;
                do
                {
                    if (tempI == curpage) pagetxt.Append("<span class='nowpage'>" + tempI + "</span>&nbsp;");
                    else pagetxt.Append("<A href='" + url + tempI + searcheurl + "'>" + tempI + "</A>&nbsp;");
                    tempI = tempI + 1;
                } while (tempI < curGroupPage + groupsize && tempI <= allpage);

                if (curpage < allpage) pagetxt.Append("<A href='" + url + (curpage + 1) + searcheurl + "' title='后一页'>Next</A>&nbsp;");
                else pagetxt.Append("<A href='" + url + curpage + searcheurl + "' title='后一页'>Next</A>&nbsp;");

                if (curGroupPage + groupsize > allpage) pagetxt.Append("<a href='" + url + allpage + searcheurl + "' title='后 " + groupsize + " 页'>&gt;&gt;</A>&nbsp;");
                else pagetxt.Append("<a href='" + url + (curGroupPage + groupsize) + searcheurl + "' title='后" + groupsize + "页'>&gt;&gt;</A>&nbsp;");

                pagetxt.Append("<A href='" + url + allpage + searcheurl + "' title='最后一页'>" + allpage + "</A>");
            }
            test.Append("allpage=" + allpage + ",allrecord=" + allrecord + ",pagesize=" + pagesize + ",groupsize=" + groupsize + ",curGroupPage=" + curGroupPage + ",curpage=" + curpage);
            return pagetxt.ToString();
        }
        #endregion

        #region 获取微软Guid

        /// <summary>
        /// 获取32位唯一Guid
        /// </summary>
        /// <returns></returns>
        public static string GetGuid()
        {
            return System.Guid.NewGuid().ToString("N");
        }

        #endregion
    }
}
