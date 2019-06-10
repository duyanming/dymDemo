using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace YY.AppCenter
{
    static class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "AppCenter";
            AppDomain.CurrentDomain.ProcessExit += (s, e) =>
            {
                if (Accept.Monitor.State)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} AppCenter Service is being stopped·····");
                    Accept.Monitor.Stop();
                    Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} AppCenter The service has stopped!");
                    Console.ResetColor();
                }
            };
            Enter(args);
        } /// <summary>
          /// Daemon工作状态的主方法
          /// </summary>
          /// <param name="args"></param>
        static void Enter(string[] args)
        {
            Accept.Monitor.Start();
            var tc = Accept.ThriftConfig.CreateInstance();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}: BIF 服务注册、发现、健康检查、负载均衡中心。端口：{tc.Port}（AppCenter）已启动！");
            Console.ResetColor();
            //阻止daemon进程退出
            while (true)
            {
                tc.ServiceInfoList.Distinct().Where(s => s.Checking == false).ToList().ForEach(service =>
                    {
                        Task.Run(() => { Accept.Distribute.HealthCheck(service); });
                    });
                Thread.Sleep(3000);
            }
        }

    }
}
