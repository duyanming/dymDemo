using System;

using dym.Rpc.Client;

namespace YY.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * 1、AppName
             * 2、注册中心
             * 3、注册中心端口
             * 4、关闭调用链追踪
             */
            DefaultConfigManager.SetDefaultConfiguration("YY.Client", "10.112.93.122", 6660,false);
            Restart:
            Console.WriteLine("请输入一个消息然后回车发送到服务器：");
            var inputMsg = Console.ReadLine();
            var input = new InputTest()
            {
                channel = "dym.Plugs.YYTest",
                router = "MyFirst",
                method = "MyT",
                XX = $"{inputMsg}MyFirst"
            };

            var rltStr = Connector.BrokerDns(input);
            //var outPut = Newtonsoft.Json.JsonConvert.DeserializeObject<dynamic>(rltStr);
            Console.WriteLine(rltStr);

            Console.WriteLine("-----------------------------------------------------------------------------");

            var inputYYTest = new InputTest()
            {
                channel = "dym.Plugs.Samsundot",
                router = "Samsundot",
                method = "Samsundot",
                XX = $"{inputMsg}Samsundot"
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
