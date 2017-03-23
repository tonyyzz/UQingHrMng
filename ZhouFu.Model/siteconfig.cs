using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ZhongLi.Model
{
    /// <summary>
    /// 站点配置实体类
    /// </summary>
    [Serializable]
    public class siteconfig
    {
        public siteconfig()
        {
            this.FileSize = 0;
            this.OrderTime = 0;
            this.SetOrderTime = 0;
        }
        public int FileSize { get; set; }
        public string ImgFormat { get; set; }
        public int OrderTime { get; set; }
        public int SetOrderTime { get; set; }
        public int Commission { get; set; }
        public string  log { get; set; }
        public string phone { get; set; }
        public string mail { get; set; }
        public string bgtu { get; set; }
        public string QRCode { get; set; }
        public string Edition { get; set; }
    }
}
