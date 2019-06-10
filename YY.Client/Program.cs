using System;

using dym.Rpc.Client;

namespace YY.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //负载中心地址
            dym.Const.SettingService.Local.IpAddress = "10.112.93.122";
            //负载中心端口
            dym.Const.SettingService.Local.Port = 6660;
            //客户端名称
            dym.Const.SettingService.AppName = "YY.Client";
            //关闭调用链追踪
            dym.Const.SettingService.TraceOnOff = false;
            Restart:
            Console.WriteLine("请输入一个消息然后回车发送到服务器：");
            var inputMsg = Console.ReadLine();
            var input = new InputTest()
            {
                channel = "dym.Plugs.YYTest",
                router = "MyFirst",
                method = "MyT",
                XX = $"{inputMsg}参数1"
            };
            var rltStr = Connector.BrokerDns(input);
            //var outPut = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(rltStr);
            Console.WriteLine(rltStr);

            Console.WriteLine("-----------------------------------------------------------------------------");

            var inputYYTest = new InputTest()
            {
                channel = "dym.Plugs.YYTest",
                router = "MySecond",
                method = "MyT",
                XX = $"{inputMsg}参数2"
            };
            var rltStrYY = Connector.BrokerDns(inputYYTest);
            //var outPutYY = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(rltStr);
            Console.WriteLine(rltStrYY);
            goto Restart;
        }
    }

    public class InputTest : InputDtoBase
    {
        public string XX { get; set; }
    }
}
