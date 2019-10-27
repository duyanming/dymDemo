# dymDemo
    dym 分布式开发框架 Demo

# dym 分布式开发框架

    dym 是一个分布式开发框架，同时支持 .net core3.0 、.net frameworker4.6.1。

## 1、运行Demo
    第一步：启动注册中心
        进入项目文件夹 dymDemo\YY.AppCenter\bin\Debug\netcoreapp3.0 ，运行命令 dotnet AppCenter.dll
        看到下图 说明运行成功
![第一步](./doc/1.png)

    第二步：启动Server  
        Server可以和 AppCenter 不在同一台电脑，也可以运行多个server 也可以负载均衡，高级用法随后介绍
        进入项目文件夹 dymDemo\YY.Server\bin\Debug\netcoreapp3.0 ，运行命令 dotnet YY.Server.dll
        看到下图 说明 Server 成功运行 并且已经注册到 注册中心（APPCenter）运行成功
![第二步](./doc/2.png)

    第三步：启动Client
        启动Client 测试 Client调用 Server是否成功
        进入项目文件夹 dymDemo\YY.Client\bin\Debug\netcoreapp3.0 ，运行命令 dotnet YY.Client.dll
        看到下图 说明 Client 成功运行 
![第三步](./doc/3.png)

# dym EventBus
	Eventbus Support  InMemory and Rabbitmq
## 1、Server配置

```c#
	//指定EventHandler的 所在程序集
	var funcs = dym.Const.Assemblys.Dic.Values.ToList();
                #region RabbitMQEventBus
                //消费失败通知

                RabbitMQEventBus.Instance.ErrorNotice += (string exchange, string routingKey, Exception exception, string body) =>
                        {
                            Log.Fatal(new { exchange, routingKey, exception, body }, typeof(RabbitMQEventBus));
                        };
                EventBusSetting.Default.RabbitConfiguration = new RabbitConfiguration()
                {
                    HostName = "192.168.100.173",
                    VirtualHost = "dev",
                    UserName = "dev",
                    Password = "dev",
                    Port = 5672
                };
                RabbitMQEventBus.Instance.SubscribeAll(funcs);

                #endregion
                #region InMemory EventBus
                EventBus.Instance.ErrorNotice += (string exchange, string routingKey, Exception exception, string body) =>
                {
                    Log.Fatal(new { exchange, routingKey, exception, body }, typeof(EventBus));
                };
                EventBus.Instance.SubscribeAll(funcs);

 ```  

## 2、EventData配置

```c#

	using dym.EventBus;
	
	namespace Events
	{
	    public class FirstMessageEvent:EventData
	    {
	        public string Message { get; set; }
	    }
	}

 ```  

 
## 3、EventHandler配置

```c#
	
	namespace dym.Plugs.SamsundotService.EventHandler
	{
	    using dym.EventBus;
	    using Events;
	
	    class FirstMessageEventHandler : IEventHandler<FirstMessageEvent>
	    {
	        public void Handler(FirstMessageEvent entity)
	        {
	            Log.Log.Info(new { Plugs= "Samsundot",Entity=entity },typeof(FirstMessageEventHandler));
	        }
	    }
	}

 ```  

 ```c#
	
	namespace dym.Plugs.YYTestService.EventHandler
	{
	    using dym.EventBus;
	    using Events;
	
	    class FirstMessageEventHandler : IEventHandler<FirstMessageEvent>
	    {
	        public void Handler(FirstMessageEvent entity)
	        {
	            Log.Log.Info(new { Plugs = "YYTest", Entity = entity }, typeof(FirstMessageEventHandler));
	        }
	    }
	    /// <summary>
	    /// 异常消费演示，测试 消费失败通知
	    /// </summary>
	    class FirstMessageExceptionEventHandler : IEventHandler<FirstMessageEvent>
	    {
	        public void Handler(FirstMessageEvent entity)
	        {
	            Log.Log.Info(new { Plugs = "YYTest",Handle= "FirstMessageExceptionEventHandler", Entity = entity }, typeof(FirstMessageEventHandler));
	            throw new Exception("异常消费演示，测试 消费失败通知 From FirstMessageExceptionEventHandler!");
	        }
	    }
	}

 ```  