﻿using System;
using cn.jpush.api.common;
using cn.jpush.api.push.mode;
using cn.jpush.api.push.notification;
using cn.jpush.api.common.resp;
using cn.jpush.api;
using ZhongLi.Common;

namespace WebSystem.Systestcomjun.AppCode
{
    public class JPushApiExample
    {
        //run the DeviceApiExample first,it will add mobile,tags,alias to the device:
        //首先运行DeviceApiExample，为设备添加手机号码，标签别名，再运行JPushApiExample,ScheduleApiExample，步骤如下：
        //1.设置cn.jpush.api.example为启动项
        //2.在cn.jpush.api.example项目，右键选择属性，然后选择应用程序，最后在启动对象下拉框中选择DeviceApiExample
        //3.按照2的步骤设置，运行JPushApiExample,ScheduleApiExample.

        public static string TITLE = "Test from C# v3 sdk";//标题
        public static string ALERT = "Test from  C# v3 sdk - alert";
        public static string MSG_CONTENT = "Test from C# v3 sdk - msgContent";//内容
        public static string REGISTRATION_ID = "0900e8d85ef";
        public static string SMSMESSAGE = "Test from C# v3 sdk - SMSMESSAGE";
        public static int DELAY_TIME = 1;
        public static string TAG = "tag_api";
        public static string app_key = "d8be0cfe5ab6703e951ebf94";
        public static string master_secret = "e42ee11bd96c3b136b07044e";
        public static void push(PushPayload pushsms)
        {
            try
            {
                JPushClient client = new JPushClient(app_key, master_secret);
                var result = client.SendPush(pushsms);
            }
            catch (Exception ex)
            {
				LoggerHelper.LogError(ex.Message);
            }
        }
        public static void Main(string[] args)
        {
            Console.WriteLine("*****开始发送******");
            JPushClient client = new JPushClient(app_key, master_secret);

            PushPayload payload = PushObject_All_All_Alert();
            try
            {
                var result = client.SendPush(payload);
                //由于统计数据并非非是即时的,所以等待一小段时间再执行下面的获取结果方法
                System.Threading.Thread.Sleep(10000);
                //如需查询上次推送结果执行下面的代码
                var apiResult = client.getReceivedApi(result.msg_id.ToString());
                var apiResultv3 = client.getReceivedApi_v3(result.msg_id.ToString());
                //如需查询某个messageid的推送结果执行下面的代码
                var queryResultWithV2 = client.getReceivedApi("1739302794"); 
                var querResultWithV3 = client.getReceivedApi_v3("1739302794");

            }
            catch (APIRequestException e)
            {
                Console.WriteLine("Error response from JPush server. Should review and fix it. ");
                Console.WriteLine("HTTP Status: " + e.Status);
                Console.WriteLine("Error Code: " + e.ErrorCode);
                Console.WriteLine("Error Message: " + e.ErrorMessage);
            }
            catch (APIConnectionException e)
            {
                Console.WriteLine(e.Message);
            }

            //send   smsmessage
            PushPayload pushsms = PushSendSmsMessage();
            try
            {
                var result = client.SendPush(pushsms);
                //由于统计数据并非非是即时的,所以等待一小段时间再执行下面的获取结果方法
                System.Threading.Thread.Sleep(10000);
                //如需查询上次推送结果执行下面的代码
                var apiResult = client.getReceivedApi(result.msg_id.ToString());
                var apiResultv3 = client.getReceivedApi_v3(result.msg_id.ToString());
                //如需查询某个messageid的推送结果执行下面的代码
                var queryResultWithV2 = client.getReceivedApi("1739302794");
                var querResultWithV3 = client.getReceivedApi_v3("1739302794");

            }
            catch (APIRequestException e)
            {
                Console.WriteLine("Error response from JPush server. Should review and fix it. ");
                Console.WriteLine("HTTP Status: " + e.Status);
                Console.WriteLine("Error Code: " + e.ErrorCode);
                Console.WriteLine("Error Message: " + e.ErrorMessage);
            }
            catch (APIConnectionException e)
            {
                Console.WriteLine(e.Message);
            }

            PushPayload payload_alias = PushObject_all_alias_alert("");
            try
            {
                var result = client.SendPush(payload_alias);
                //由于统计数据并非非是即时的,所以等待一小段时间再执行下面的获取结果方法
                System.Threading.Thread.Sleep(10000);
                //如需查询上次推送结果执行下面的代码
                var apiResult = client.getReceivedApi(result.msg_id.ToString());
                var apiResultv3 = client.getReceivedApi_v3(result.msg_id.ToString());
                //如需查询某个messageid的推送结果执行下面的代码
                var queryResultWithV2 = client.getReceivedApi("1739302794");
                var querResultWithV3 = client.getReceivedApi_v3("1739302794");

            }
            catch (APIRequestException e)
            {
                Console.WriteLine("Error response from JPush server. Should review and fix it. ");
                Console.WriteLine("HTTP Status: " + e.Status);
                Console.WriteLine("Error Code: " + e.ErrorCode);
                Console.WriteLine("Error Message: " + e.ErrorMessage);
            }
            catch (APIConnectionException e)
            {
                Console.WriteLine(e.Message);
            }



            Console.WriteLine("*****结束发送******");
        }

        public static PushPayload PushObject_All_All_Alert()
        {
            PushPayload pushPayload = new PushPayload();
            pushPayload.platform = Platform.all();
            pushPayload.audience = Audience.all();
            pushPayload.notification = new Notification().setAlert(ALERT);
            return pushPayload;
        }
        public static PushPayload PushObject_all_alias_alert(string alias)
        {

            PushPayload pushPayload_alias = new PushPayload();
            pushPayload_alias.platform = Platform.android();
            pushPayload_alias.audience = Audience.s_alias(alias);
            pushPayload_alias.notification = new Notification().setAlert(ALERT);
            return pushPayload_alias;
        }
        public static PushPayload PushObject_Android_Tag_AlertWithTitle()
        {
            PushPayload pushPayload = new PushPayload();

            pushPayload.platform = Platform.android();
            pushPayload.audience = Audience.s_tag("tag1"); 
            pushPayload.notification =  Notification.android(ALERT,TITLE);
            return pushPayload;
        }
        public static PushPayload PushObject_android_and_ios()
        {
            PushPayload pushPayload = new PushPayload();
            pushPayload.platform = Platform.android_ios();
            var audience = Audience.s_tag("tag1");
            pushPayload.audience = audience;
            var notification = new Notification().setAlert("alert content");
            notification.AndroidNotification = new AndroidNotification().setTitle("Android Title");
            notification.IosNotification = new IosNotification();
            notification.IosNotification.incrBadge(1);
            notification.IosNotification.AddExtra("extra_key", "extra_value");

            pushPayload.notification = notification.Check(); 
      

            return pushPayload;
        }
        public static PushPayload PushObject_ios_tagAnd_alertWithExtrasAndMessage(string alias, string from)
        {
            PushPayload pushPayload = new PushPayload();
            pushPayload.ResetOptionsApnsProduction(true);
            pushPayload.platform = Platform.android_ios();
            pushPayload.audience = Audience.s_alias(alias);
            var notification = new Notification();
            notification.IosNotification = new IosNotification().setAlert(ALERT).setSound("happy").AddExtra("from", from);
            notification.AndroidNotification = new AndroidNotification().setAlert(ALERT).AddExtra("from", from);
            pushPayload.notification = notification;
            pushPayload.message = Message.content(MSG_CONTENT).AddExtras("from", from);
            return pushPayload;

        }
        public static PushPayload PushObject_ios_audienceMore_messageWithExtras(string alias,string from)
        {
            var pushPayload = new PushPayload();
            pushPayload.ResetOptionsApnsProduction(true);
            pushPayload.platform = Platform.android_ios();
            //pushPayload.audience = Audience.s_tag("tag1","tag2");
            pushPayload.audience = Audience.s_alias(alias);
            pushPayload.notification = new Notification().setAlert(ALERT);
            pushPayload.message = Message.content(MSG_CONTENT).AddExtras("from", from);
            return pushPayload;

        }
        public static PushPayload PushObject_ios_audienceMore_messageWithExtras(string[] alias, string from)
        {
            var pushPayload = new PushPayload();
            pushPayload.platform = Platform.android_ios();
            //pushPayload.audience = Audience.s_tag("tag1","tag2");
            pushPayload.audience = Audience.s_alias(alias);
            pushPayload.notification = new Notification().setAlert(ALERT);
            pushPayload.message = Message.content(MSG_CONTENT).AddExtras("from", from);
            return pushPayload;

        }
        public static PushPayload PushSendSmsMessage()
        {
            var pushPayload = new PushPayload();
            pushPayload.platform = Platform.all();
            pushPayload.audience = Audience.all();
            pushPayload.notification = new Notification().setAlert(ALERT);
            SmsMessage sms_message = new SmsMessage();
            sms_message.setContent(SMSMESSAGE);
            sms_message.setDelayTime(DELAY_TIME);
            pushPayload.sms_message = sms_message;
            return pushPayload;
        }

    }
}
