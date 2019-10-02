using System;
using System.Linq;
using System.Threading;
using Autofac;

namespace YY.Server
{
    using dym.EngineData;
    using dym.Loader;
    using dym.Rpc.Server;
    static class Program
    {
        static void Main(string[] args)
        {
            Bootstrap.StartUp(args,()=> {
                //dym.Const.SettingService.TraceOnOff = true;
                var autofac = IocLoader.GetAutoFacContainerBuilder();
                autofac.RegisterType(typeof(RpcConnectorImpl)).As(typeof(IRpcConnector)).SingleInstance();
            });
        }
    }
}
