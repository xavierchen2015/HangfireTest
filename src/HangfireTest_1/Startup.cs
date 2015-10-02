using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Hangfire;
using Hangfire.MemoryStorage;

[assembly: OwinStartup(typeof(HangfireTest_1.Startup))]

namespace HangfireTest_1
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // 如需如何設定應用程式的詳細資訊，請參閱  http://go.microsoft.com/fwlink/?LinkID=316888
            // 指定Hangfire使用記憶體儲存任務
            GlobalConfiguration.Configuration.UseMemoryStorage();
            // 啟用HanfireServer
            app.UseHangfireServer();
            // 啟用Hangfire的Dashboard
            app.UseHangfireDashboard();
        }
    }
}
