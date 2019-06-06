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
            var input = new InputTest()
            {
                channel = "dym.Plugs.SerialRule",
                router = "RuleFactory",
                method = "CreateSdaNum",
                XX = "我的自定义参数"
            };
            var rltStr = Connector.BrokerDns(input);
            var outPut = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(rltStr);
            Console.WriteLine(rltStr);

            Console.WriteLine("-----------------------------------------------------------------------------");

            var inputYYTest = new InputTest()
            {
                channel = "dym.Plugs.YYTest",
                router = "MyFirst",
                method = "MyT",
                XX = "我的自定义参数"
            };
            var rltStrYY = Connector.BrokerDns(inputYYTest);
            var outPutYY = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(rltStr);
            Console.WriteLine(rltStrYY);
            Console.ReadLine();
        }
    }

    public class InputTest : InputDtoBase
    {
        public string XX { get; set; }
    }
}
