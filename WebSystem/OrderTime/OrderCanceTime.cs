using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cn.jpush.api.push.mode;

namespace OrderTime
{
    public class OrderCanceTime
    {
        [SqlFunction(SystemDataAccess = SystemDataAccessKind.Read, DataAccess = DataAccessKind.Read)]
        public static string Sync()
        {
            string result = "true";

            try
            {
                //int OrderCanceDay = Convert.ToInt32(DbHelperSQL.GetSingle("select OrderCanceDay from OrderTime"));
                //DataTable dt = DbHelperSQL.Query("select PerID from Reward_Order Where DATEDIFF(minute,CreateTime,GETDATE())>="+OrderCanceDay+"*24*60 and OrderState=1").Tables[0];
                //if (dt.Rows.Count > 0)
                //{

                //}
                JPushApiExample.ALERT = "您的匹配的悬赏订单";
                JPushApiExample.MSG_CONTENT = "您的匹配的悬赏订单";
                PushPayload pushsms1 = JPushApiExample.PushObject_ios_audienceMore_messageWithExtras("p112", "Order");
                JPushApiExample.push(pushsms1);
            }
            catch (Exception ex)
            {
                result = "false:" + ex.ToString();
            }

            return result;
        }

       
    }
}
