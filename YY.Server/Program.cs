using System;
using System.Linq;
using System.Threading;
using Autofac;

namespace YY.Server
{
    using dym.EventBus;
    using dym.EventBus.RabbitMQ;
    using dym.EngineData;
    using dym.Loader;
    using dym.Rpc.Server;
    using dym.Log;
    static class Program
    {
        static void Main(string[] args)
        {
            Bootstrap.StartUp(args, () =>
            {
                var funcs = dym.Const.Assemblys.Dic.Values.ToList();
                //#region RabbitMQEventBus
                ////消费失败通知

                //RabbitMQEventBus.Instance.ErrorNotice += (string exchange, string routingKey, Exception exception, string body) =>
                //        {
                //            Log.Fatal(new { exchange, routingKey, exception, body }, typeof(RabbitMQEventBus));
                //        };
                //EventBusSetting.Default.RabbitConfiguration = new RabbitConfiguration()
                //{
                //    HostName = "192.168.100.173",
                //    VirtualHost = "dev",
                //    UserName = "dev",
                //    Password = "dev",
                //    Port = 5672
                //};
                //RabbitMQEventBus.Instance.SubscribeAll(funcs);

                //#endregion
                #region InMemory EventBus
                EventBus.Instance.ErrorNotice += (string exchange, string routingKey, Exception exception, string body) =>
                {
                    Log.Fatal(new { exchange, routingKey, exception, body }, typeof(EventBus));
                };
                EventBus.Instance.SubscribeAll(funcs);
                #endregion
                //dym.Const.SettingService.TraceOnOff = true;
                var autofac = IocLoader.GetAutoFacContainerBuilder();
                autofac.RegisterType(typeof(RpcConnectorImpl)).As(typeof(IRpcConnector)).SingleInstance();
            });
        }
    }
}
