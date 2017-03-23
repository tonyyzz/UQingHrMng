using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZhouFu.Common;
using System.Text.RegularExpressions;
using ZhouFu.DBUtility;
using System.IO;

namespace ZhouFu.ServiceCs
{
    public class sys_Question
    {
        #region 添加网络互动
        public string InfoQuestion(int action, string strjson)
        {
            StringBuilder sbResult = new StringBuilder();
            if (action <=0)
            {
                switch (action)
                { 
                    case 1://网络问政
                        int iRowCount = InfoWlwz(strjson);
                        if (iRowCount > 0)
                        {
                            sbResult.Append("[{\"state\":\"0\",\"data\":\"提交成功。\",\"total\":\"" + iRowCount + "\"}]");
                        }
                        else {
                            sbResult.Append("[{\"state\":\"2\",\"data\":\"提交失败,SQL语句错误。\",\"total\":\"" + iRowCount + "\"}]");
                        }
                        break;
                }
            }
            else 
            {
                sbResult.Append("[{\"state\":\"1\",\"data\":\"action参数不正确\",\"total\":\"0\"}]");
            }
            return sbResult.ToString();
        }

        //网络问政
        private int InfoWlwz(string strjson)
        {
            int iRowCount = 0;
            CommonJsonModel model = new CommonJsonModel(Regex.Replace(strjson, @"\r\n", ""));
            List<CommonJsonModel> lst = model.GetCollection();
            foreach (CommonJsonModel item in lst)
            {
                int action = 1;
                string number = GetNumber(1);
                string title = item.GetValue("title");//标题
                string filepath = string.Empty;//图片地址
                #region 图片上传
                byte[] imgStream = Convert.FromBase64String(item.GetValue("stream"));
                if (!imgStream.Equals(""))
                {
                    string imgname = DateTime.Now.ToString("yyyyMMddHHmmss") + ".png";
                    filepath = "Upload/" + DateTime.Now.ToString("yyyyMM") + "/" + DateTime.Now.Date.Day + "/";
                    string webpath = System.Web.HttpContext.Current.Server.MapPath("/" + filepath);
                    if (!Directory.Exists(webpath))//不存在此目录则创建目录
                    {
                        Directory.CreateDirectory(webpath);
                    }
                    FileStream fStream = new FileStream(webpath, FileMode.Create, FileAccess.Write);
                    BinaryWriter bw = new BinaryWriter(fStream);
                    bw.Write(imgStream);
                    bw.Close();
                    fStream.Close();
                }
                #endregion
                string content = item.GetValue("content");//内容
                string type = item.GetValue("type");//类型(投诉...)
                string toppic = item.GetValue("toppic");//话题
                string deprtment = item.GetValue("deprtment");//提问部门
                string pubuser = item.GetValue("pubuser");//提问用户
                string longitude = item.GetValue("longitude");//经度
                string latitude = item.GetValue("latitude");//纬度
                string strsql = string.Format("insert into sys_Question(Number,Title,QuestionContent,QuestionType,PulishUserID,Longitude,Latitude,TopictypeID,ImageUrl,DepartmentID,Flag)values('{0}','{1}','{2}',{3},{4},{5},{6},{7},'{8}',{9},{10});", number, title, content, type, pubuser, longitude, latitude, toppic, filepath, deprtment, action);
                try
                {
                    iRowCount = DbHelperSQL.ExecuteSql(strsql);
                }
                catch {
                    iRowCount = 0;
                }
            }
            return iRowCount;
        }

        //获取信件编号
        private string GetNumber(int action)
        {
            string strReuslt = string.Empty;
            if (action > 0)
            {
                string sql = string.Format("select count(1) from sys_Question where Flag={0} and DATEDIFF(day,addtime,getdate())=0", action);
                object objCount = DbHelperSQL.GetSingle(sql);
                if (Convert.ToInt32(objCount) > 0)
                {
                    strReuslt = DateTime.Now.ToString("yyyyMMdd") + (Convert.ToInt32(objCount)+1).ToString().PadLeft(3, '0');
                }
                else
                {
                    strReuslt = DateTime.Now.ToString("yyyyMMdd") + objCount.ToString().PadLeft(3, '0');
                }
            }
            return strReuslt;
        }

        #endregion
    }
}
