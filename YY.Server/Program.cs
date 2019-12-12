using System;
using System.Linq;
using System.Threading;
using Autofac;

namespace YY.Server
{
    using Anno.EventBus;
    using Anno.EventBus.RabbitMQ;
    using Anno.EngineData;
    using Anno.Loader;
    using Anno.Rpc.Server;
    using Anno.Log;
    static class Program
    {
        static void Main(string[] args)
        {
            Bootstrap.StartUp(args, () =>
            {
                var funcs = Anno.Const.Assemblys.Dic.Values.ToList();
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
                //Anno.Const.SettingService.TraceOnOff = true;
                var autofac = IocLoader.GetAutoFacContainerBuilder();
                autofac.RegisterType(typeof(RpcConnectorImpl)).As(typeof(IRpcConnector)).SingleInstance();
            });
        }
    }
}
