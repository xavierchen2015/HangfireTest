using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Hangfire;

namespace HangfireTest_1.Controllers
{
    public class MsgController : ApiController
    {
        public static void Send(string msg)
        {
            EventLog.WriteEntry("EventSystem", string.Format("這是由Hangfire 產生 Task :{0},时间为:{1}", msg, DateTime.Now));
        }

        public IHttpActionResult Post(string msg)
        {
            //这里可以做一些业务判断或操作

            //然后需要推送的时候，调用下面的方法即可
            //BackgroundJob.Enqueue(() => Send(msg));

            //EventLog.WriteEntry("EventSystem", string.Format("這是由Hangfire 產生的 Log :{0},时间为:{1}", msg, DateTime.Now));
            //BackgroundJob.Schedule(() => Send(msg), TimeSpan.FromMinutes(1));
            //EventLog.WriteEntry("EventSystem", string.Format("這是由Hangfire 產生的 Log :{0},时间为:{1}", msg, DateTime.Now));

            EventLog.WriteEntry("EventSystem", string.Format("這是由Hangfire 產生開始的 Log :{0},时间为:{1}", msg, DateTime.Now));
            RecurringJob.AddOrUpdate(() => Send(msg), Cron.Minutely);
            EventLog.WriteEntry("EventSystem", string.Format("這是由Hangfire 產生結束的 Log :{0},时间为:{1}", msg, DateTime.Now));
            //最后返回（这里是立即返回，不会阻塞）
            return Ok();
        }
    }
}