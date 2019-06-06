using dym.Rpc;
using System.Threading;
using Thrift.Server;
using Thrift.Transport;

namespace YY.Server
{
    public static class Server
    {
        private static TServer _server;
        public static bool State { get; private set; } = false;
        public static void Start()
        {
            TServerSocket serverTransport = new TServerSocket(dym.Const.SettingService.Local.Port, 0, true);
            BrokerService.Processor processor = new BrokerService.Processor(new BusinessImpl());
            _server = new TThreadedServer(processor, serverTransport);
            new Thread(_server.Serve) { IsBackground = true }.Start();//开启业务服务
            State = true;
        }
        public static bool Stop()
        {
            _server.Stop();
            State = false;
            return true;
        }
    }
}
