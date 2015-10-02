using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace HangfireTest_1.Controllers
{
    public class FromValue
    {
        public string value { get; set; }
    }

    public class TestController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            EventLog.WriteEntry("EventSystem", string.Format("這是由Hangfire 產生 Task :{0},时间为:{1}", id, DateTime.Now));
            return "value";
        }

        // POST api/<controller>
        public void Post(FromValue fb)
        {
            EventLog.WriteEntry("EventSystem", string.Format("這是由Hangfire 產生 Post  :{0},时间为:{1}", fb.value, DateTime.Now));
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}