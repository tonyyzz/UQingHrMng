using OfficeOpenXml;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Web;

namespace ZhongLi.Common
{
    public class PublicMethod
    {
        /// <summary>
        /// 文件生成
        /// </summary>
        /// <param name="iStream"></param>
        /// <param name="Type"></param>
        /// <returns></returns>
        public static string GenerateFile(byte[] iStream, int Type, string filePath)
        {
            string urlname = "";
            //视频
            if (Type == 2)
            {
                string urlname1 = filePath + ".mp4";
                filePath = Path(urlname1);
                urlname = urlname1;
            }
            //图片
            else
            {
                string urlname2 = filePath + ".png";
                filePath = Path(urlname2);
                urlname = urlname2;
            }
            FileStream fStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fStream);
            bw.Write(iStream);
            bw.Close();
            fStream.Close();
            return urlname;
        }
        /// <summary>
        /// 路径生成
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static string Path(string urlname)
        {
            string serverPath = "";
            if (!Directory.Exists(serverPath))//不存在此目录则创建目录
            {
                Directory.CreateDirectory(serverPath);
            }
            return serverPath + urlname;
        }
        /// <summary>
        /// 导出excel 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="flieName"></param>
        /// <param name="dict">sheetname和DataTable的键值对</param>
        public static void DumpExcel(HttpContext context, string fileName, IDictionary<string, DataTable> dict)
        {
            using (ExcelPackage pck = new ExcelPackage())
            {
                foreach (var kp in dict)
                {
                    //Create the worksheet
                    ExcelWorksheet ws = pck.Workbook.Worksheets.Add(kp.Key);

                    //Load the datatable into the sheet, starting from cell A1. Print the column names on row 1
                    ws.Cells["A1"].LoadFromDataTable(kp.Value, true);

                    ////Format the header for column 1-3
                    //using (ExcelRange rng = ws.Cells["A1:C1"])
                    //{
                    //    rng.Style.Font.Bold = true;
                    //    rng.Style.Fill.PatternType = ExcelFillStyle.Solid;                      //Set Pattern for the background to Solid
                    //    rng.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(79, 129, 189));  //Set color to dark blue
                    //    rng.Style.Font.Color.SetColor(Color.White);
                    //}

                    ////Example how to Format Column 1 as numeric 
                    //using (ExcelRange col = ws.Cells[2, 1, 2 + tbl.Rows.Count, 1])
                    //{
                    //    col.Style.Numberformat.Format = "#,##0.00";
                    //    col.Style.HorizontalAlignment = ExcelHorizontalAlignment.Right;
                    //}

                }
                //Write it back to the client
                var data = pck.GetAsByteArray();
                context.Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                context.Response.AddHeader("content-disposition", "attachment;  filename=" + fileName + ".xlsx");
                context.Response.AddHeader("Content-Length", data.Length.ToString());
                context.Response.BinaryWrite(data);
            }
        }

    }
}
