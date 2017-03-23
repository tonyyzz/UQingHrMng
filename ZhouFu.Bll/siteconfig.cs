using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZhongLi.Common;

namespace ZhongLi.Bll
{
    public partial class siteconfig
    {
        private readonly ZhongLi.Dal.siteconfig dal = new ZhongLi.Dal.siteconfig();

        /// <summary>
        ///  读取配置文件
        /// </summary>
        public ZhongLi.Model.siteconfig loadConfig(string configFilePath)
        {
            ZhongLi.Model.siteconfig model = CacheHelper.Get<ZhongLi.Model.siteconfig>(DTKeys.CACHE_SITE_CONFIG);
            if (model == null)
            {
                CacheHelper.Insert(DTKeys.CACHE_SITE_CONFIG, dal.loadConfig(configFilePath), configFilePath);
                model = CacheHelper.Get<ZhongLi.Model.siteconfig>(DTKeys.CACHE_SITE_CONFIG);
            }
            return model;
        }
        /// <summary>
        /// 读取客户端站点配置信息
        /// </summary>
        public ZhongLi.Model.siteconfig loadConfig(string configFilePath, bool isClient)
        {
            ZhongLi.Model.siteconfig model = CacheHelper.Get<ZhongLi.Model.siteconfig>(DTKeys.CACHE_SITE_CONFIG_CLIENT);
            if (model == null)
            {
                model = dal.loadConfig(configFilePath);
                //model.templateskin = model.webpath + "templates/" + model.templateskin;
                CacheHelper.Insert(DTKeys.CACHE_SITE_CONFIG_CLIENT, model, configFilePath);
            }
            return model;
        }

        /// <summary>
        ///  保存配置文件
        /// </summary>
        public ZhongLi.Model.siteconfig saveConifg(ZhongLi.Model.siteconfig model, string configFilePath)
        {
            return dal.saveConifg(model, configFilePath);
        }

    }
}
