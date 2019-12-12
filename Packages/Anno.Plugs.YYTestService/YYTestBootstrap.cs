using System;
using Anno.EngineData;

namespace Anno.Plugs.YYTestService
{
    //服务启动 配置
    public class YYTestBootstrap : IPlugsConfigurationBootstrap
    {
        public void ConfigurationBootstrap()
        {
            /*
             * 服务启动的时候会执行此方法
             * 也可以用来加载插件的配置
             */

        }

        public void PreConfigurationBootstrap()
        {
            //Ioc 注入之前
        }
    }
}
