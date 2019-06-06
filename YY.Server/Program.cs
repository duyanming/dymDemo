using System;
using System.Linq;
using System.Threading;

namespace YY.Server
{
    static class Program
    {
        static void Main(string[] args)
        {
            var reStar = false;
        reStart:
            try
            {
                Bootstrap(args, reStar);
                //程序退出事件
                AppDomain.CurrentDomain.ProcessExit += (s, e) =>
                {
                    if (Server.State)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine(
                            $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} {dym.Const.SettingService.AppName} Service is being stopped·····");
                        //停止服务
                        Server.Stop();
                        Console.WriteLine(
                            $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} {dym.Const.SettingService.AppName} The service has stopped!");
                        Console.ResetColor();
                    }
                };
                //阻止daemon进程退出
                while (true)
                {
                    Thread.Sleep(1000);
                }
            }
            catch (Exception e)
            {
                dym.Log.Log.Error(e);
                if (e is Thrift.TException)
                {
                    reStar = true;
                }
                else
                {
                    throw;
                }
            }
            //服务因为传输协议异常自动退出，需要重启启动。如果是配置错误弹出配置错误信息
            goto reStart;
        }
        /// <summary>
        /// 启动服务
        /// </summary>
        /// <param name="args"></param>
        /// <param name="reStart">异常之中回复启动，true。正常启动，false</param>
        static void Bootstrap(string[] args, bool reStart)
        {
            if (!reStart)
            {
                //程序启动配置
                dym.EngineData.DymBootstrap.Bootstrap();
            }
            //设置服务名称
            Console.Title = dym.Const.SettingService.AppName;
            //启动服务
            Server.Start();

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss}");
            Console.WriteLine($"节点【{dym.Const.SettingService.AppName}】(端口：{dym.Const.SettingService.Local.Port})已启动");
            foreach (var f in dym.Const.SettingService.FuncName.Split(','))
            {
                Console.WriteLine($"{f}");
            }
            Console.WriteLine($"{"权重:" + dym.Const.SettingService.Weight}");
            Console.ResetColor();
            Console.WriteLine($"----------------------------------------------------------------- ");
            //将此服务注册到 注册中心，方便客户端调用
            dym.Const.SettingService.Ts.ForEach(t => { new dym.Rpc.Client.Register().ToCenter(t, 60); });
            /*
             * 1、Const.SettingService.Local 在APPservice(服务提供方)中 作为 本机信息
             * 2、Const.SettingService.Local 在客户端 作为 负载均衡地址信息(APPcenter)
             * 3、此处为了让APPservice 可以调用外部服务 Local使用完毕后更改为 APPcenter 地址
             */
            //dym.Const.SettingService.Local = dym.Const.SettingService.Ts?.First();
        }
    }
}
