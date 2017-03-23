using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ZhongLi.Api
{
    public class HuanXunInterface2
    {
        
        //商户配置文件---Start
        static string strMerchantID = "1184980025";//测试商户号
        static string strIV = "1eX24DCe";//向量
        static string strKey = "r0uScmDuH5FLO37AJV2FN72J";//密钥
        static string strMD5 = "Ys6z7H93z9h3kQll7tv02SUsjWDcVsatanaPuE4NMbfGLLDOoaAhN7hN9eUxzx45wGT3Ch8De1XwPvRNF0n7GqrnbWRmnlVbxZEs7n6og5229XUveYq9sENyEP5CEsLr";//MD5证书
        static string strRSA = "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCbfyYdw2j5gOF7X9cdFrUKJ+MRTAfpJB+opBxjSw7iAZNUv9TmQHH/LSAim2ucaBRiB/Cqm1agocip3g8YC7Md/AhCtN+di0uc3d0F2c7H/WZm4n98IPjwfjmxNUJxdvKnF3CezY9nCCHWu36NvtMlCKLlO14Iu/PNvsVVv85zowIDAQAB";//RSA公钥
        //商户配置文件---End



        public static string[] UserRegister()
        {
            //IPS用户开户接口
            return new string[]{};
        }
        
        
        

        private const string FIXED_JSON_DATA_UserRegister = @"{""operationType"": ""user.register"",""merchantID"": ""{0}"", ""sign"": ""{1}"", ""request"": {""merBillNo"": ""1000000001"",""merDate"": ""2015-01-02"",""userType"": ""1"",""userName"": ""test@163.com"",""mobileNo"": ""18978578577"",""identNo"": ""132158745145745454"",""bizType"": ""1"",""realName"": ""李明"",""enterName"": """",""orgCode"": """",""isAssureCom"": """",""webUrl"": ""http://ips.com/webtest.htm"",""s2SUrl"": ""http://ips.com/s2stest.htm""}}";

        private const string test_request = @"{""merBillNo"": ""1000000001"",""merDate"": ""2015-01-02"",""userType"": ""1"",""userName"": ""test@163.com"",""mobileNo"": ""18978578577"",""identNo"": ""132158745145745454"",""bizType"": ""1"",""realName"": ""李明"",""enterName"": """",""orgCode"": """",""isAssureCom"": """",""webUrl"": ""http://ips.com/webtest.htm"",""s2SUrl"": ""http://ips.com/s2stest.htm""}";

        public static string UserRegister1()
        {
            /*MD5(operationType  +merchantID
+request+系统证书(MD5))
取 32 位小写 \"+\"此处仅表示字符串拼接*/
            string request = DESHelper.Encode("﻿" + test_request + "", strKey, strIV);
            string json = FIXED_JSON_DATA_UserRegister.Replace("{0}", strMerchantID).Replace("{1}", GetSign1());
            //json = DESHelper.Encode(json);
            //json = "123456";
            json = "operationType={0}&merchantID={1}&sign={2}&request={3}";
            json = string.Format(json, "user.register", strMerchantID, GetSign1(), request);
            //string strTest = new WebUtils().DoPost("http://180.168.26.114:20010/p2p-deposit/gateway.htm", json);
            return "";
        }

        private static string GetSign1()
        {
            string str1 = "O75eJ5spQphliWkDyBTXItr9RH/lz3O0Qj08cPVAFYjmboeyvbx3itLYU80BmCwt9IaoUmJvrk8yV6coYjJ5kKQsSQJsQd8hgsTvN9rDVGiQtUboGHa4qwRDHumg+5Cwt4rKVhorpQZrDevVmjJKLSo3ruD5b1E0OiyFzlTvSb92+il07XCHuFYHbj7a9zi7gwvCJcJS6qVj8FV7sXh0x7i9jdcB4yPQsXbSvcD9ciyLTL7XuxmZ0/vIDcc9vfE9v4DDO0cOqgasbk97834FSTu7iq2LlhjZPjG4KsW1mFvUiRucKNl62K/IFZRAa5hLTdwfIz2pD2CxrVPgQQZdi1UbygPlMsi6V3TwiV6hLm/iXnI3L6ZiNi556xzm+rjtZ3Rxbjd0t90neXFTjA9R+Yt9Mwd1xlOPoxq1JHHY4sgnVetkoj4Srg==";
            //string str2 = DESHelper.Decode_(str1, "2EDxsEfp", "ICHuQplJ0YR9l7XeVNKi6FMn");

            string str3 = DESHelper.Decode(str1, "ICHuQplJ0YR9l7XeVNKi6FMn", "2EDxsEfp");
            string str4 = DESHelper.Encode(str3, "ICHuQplJ0YR9l7XeVNKi6FMn", "2EDxsEfp");
           


            string request = DESHelper.Encode("﻿" + test_request + "", strKey, strIV);
            string SignMD5 = "user.register" + strMerchantID + request + strMD5;
            SignMD5 = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(
               SignMD5, "MD5").ToLower();
            return SignMD5;
        }
       




    }


  



}


