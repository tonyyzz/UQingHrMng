using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace ZhongLi.DBUtility
{
    /// <summary>
    /// Summary description for EUCPComm
    /// </summary>
    public class EUCPComm
    {
        private static EUCPComm comm = new EUCPComm();

        //声明委托，对回调函数进行封装。
        public delegate void deleSQF(string mobile, string senderaddi, string recvaddi, string ct, string sd, ref int flag);
        private event deleSQF _mySmsContent;

        public delegate void delegSMSReport(string mobile, string errorCode, string serviceCodeAdd, string reportType, ref int flag);
        private event delegSMSReport _mySmsReport;

        public delegate void delegSMSReportEx(string seq, string mobile, string errorCode, string serviceCodeAdd, string reportType, ref int flag);
        private event delegSMSReportEx _mySmsReportEx;

        public deleSQF sqf = null;
        public delegSMSReport report = null;
        public delegSMSReportEx reportex = null;


        public event deleSQF mySmsContent;
        public event delegSMSReport mySmsReport;
        public event delegSMSReportEx mySmsReportEx;

        private EUCPComm()
        {
            sqf = new EUCPComm.deleSQF(comm_mySmsContent);
            report = new EUCPComm.delegSMSReport(comm_mySmsReport);
            reportex = new EUCPComm.delegSMSReportEx(comm_mySmsReportEx);

            _mySmsContent += sqf;
            _mySmsReport += report;
            _mySmsReportEx += reportex;
        }
        public static EUCPComm GetInstance()
        {
            return comm;
        }
        void comm_mySmsReportEx(string seq, string mobile, string errorCode, string serviceCodeAdd, string reportType, ref int flag)
        {
            mySmsReportEx.Invoke(seq, mobile, errorCode, serviceCodeAdd, reportType, ref flag);
        }

        void comm_mySmsReport(string mobile, string errorCode, string serviceCodeAdd, string reportType, ref int flag)
        {
            mySmsReport.Invoke(mobile, errorCode, serviceCodeAdd, reportType, ref flag);
        }

        void comm_mySmsContent(string mobile, string senderaddi, string recvaddi, string ct, string sd, ref int flag)
        {
            mySmsContent.Invoke(mobile, senderaddi, recvaddi, ct, sd, ref flag);
        }

        //调用dll方法
        [DllImport("EUCPComm.dll", EntryPoint = "SendSMS")]  //即时发送
        public static extern int SendSMS(string sn, string mn, string ct, string priority);

        [DllImport("EUCPComm.dll", EntryPoint = "SendSMSEx")]  //即时发送(扩展)
        public static extern int SendSMSEx(string sn, string mn, string ct, string addi, string priority);

        [DllImport("EUCPComm.dll", EntryPoint = "SendScheSMS")]  // 定时发送
        public static extern int SendScheSMS(string sn, string mn, string ct, string ti, string priority);

        [DllImport("EUCPComm.dll", EntryPoint = "SendScheSMSEx")]  // 定时发送(扩展)
        public static extern int SendScheSMSEx(string sn, string mn, string ct, string ti, string addi, string priority);

        [DllImport("EUCPComm.dll", EntryPoint = "ReceiveSMS")]  // 接收短信
        public static extern int ReceiveSMS(string sn, deleSQF mySmsContent);

        [DllImport("EUCPComm.dll", EntryPoint = "ReceiveSMSEx")]  // 接收短信
        public static extern int ReceiveSMSEx(string sn, deleSQF mySmsContent);

        //[DllImport("EUCPComm.dll", EntryPoint = "ReceiveStatusReport")]  // 接收短信报告
        //public static extern int ReceiveStatusReport(string sn, delegSMSReport mySmsReport);

        //[DllImport("EUCPComm.dll", EntryPoint = "ReceiveStatusReportEx")]  // 接收短信报告(带批量ID)
        //public static extern int ReceiveStatusReportEx(string sn, delegSMSReportEx mySmsReportEx);

        [DllImport("EUCPComm.dll", EntryPoint = "Register")]   // 注册 
        public static extern int Register(string sn, string pwd, string EntName, string LinkMan, string Phone, string Mobile, string Email, string Fax, string sAddress, string Postcode);

        [DllImport("EUCPComm.dll", EntryPoint = "GetBalance", CallingConvention = CallingConvention.Winapi)] // 余额 
        public static extern int GetBalance(string m, System.Text.StringBuilder balance);

        [DllImport("EUCPComm.dll", EntryPoint = "ChargeUp")]  // 存值
        public static extern int ChargeUp(string sn, string acco, string pass);

        [DllImport("EUCPComm.dll", EntryPoint = "GetPrice")]  // 价格
        public static extern int GetPrice(string m, System.Text.StringBuilder balance);

        [DllImport("EUCPComm.dll", EntryPoint = "RegistryTransfer")]  //申请转接
        public static extern int RegistryTransfer(string sn, string mn);

        [DllImport("EUCPComm.dll", EntryPoint = "CancelTransfer")]  // 注销转接
        public static extern int CancelTransfer(string sn);

        [DllImport("EUCPComm.dll", EntryPoint = "UnRegister")]  // 注销
        public static extern int UnRegister(string sn);

        [DllImport("EUCPComm.dll", EntryPoint = "SetProxy")]  // 设置代理服务器 
        public static extern int SetProxy(string IP, string Port, string UserName, string PWD);

        [DllImport("EUCPComm.dll", EntryPoint = "RegistryPwdUpd")]  // 修改序列号密码
        public static extern int RegistryPwdUpd(string sn, string oldPWD, string newPWD);


    }
}
