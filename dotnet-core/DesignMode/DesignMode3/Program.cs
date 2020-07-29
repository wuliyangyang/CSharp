using DesignMode3.Builders;
using DesignMode3.Builders.Interface;
using DesignMode3.Configuration;
using DesignMode3.Configuration.Builders;
using DesignMode3.Decorators;
using DesignMode3.Decorators.Decorator;
using DesignMode3.Decorators.Interface;
using System;

namespace DesignMode3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            #region 1、建造者模式
            {
                /*1. 为了构造复杂的对象出现的设计模式
                 *2. 不需要关心属性的关系和细节
                 * 目的：提高程序的通用性和扩展性，达到逻辑解耦效果
                 * 缺点：每一个车的细节都会不一样，所以会有很多个builder类
                 */

                //IBuilder bikeBuilder = new BikeBuilder();
                //bikeBuilder.Assembly();
                //Bike bike = bikeBuilder.BuildBike();

                //IBuilder ofoBikeBuilder = new OfoBikeBuilder();
                //ofoBikeBuilder.Assembly();
                //Bike ofoBike = ofoBikeBuilder.BuildBike();


            }
            #endregion

            #region 2、装饰器模式
            {
                /*支付回调
                 * 1.发送短信
                 * 2.发送邮件
                 * 3.记录日志
                 * 缺点：装饰器太多
                 */

                //原始回调
            //    IPayCallback payCallback = new PayCallback();
            //    //payCallback.CallbackHandler();

            //    IPayCallback sendMsgPayCallback = new SendMsgPayCallbackDecorator(payCallback);
            //    IPayCallback sendMailPayCallback = new SendMailPayCallbackDecorator(sendMsgPayCallback);
            //    IPayCallback saveLogPayCallback = new SaveLogPayCallbackDecorator(sendMailPayCallback);

            //    saveLogPayCallback.CallbackHandler();
            }
            #endregion

            #region 3、代理模式
            {

            }
            #endregion

            #region 4、Configuration Example
            {
                /*.net Configuration体系核心对象
                 * 1、IConfiguration（最核心对象）IConfigurationRoot IConfigurationSection
                 * 2、IConfigurationPrivoder (提供配置数据)
                 * 3、IConfigurationSource（提供配置源）
                 * 4、IConfigurationBuilder（构造IConfiguration对象）
                 * 
                 * 核心领域：IConfiguration、IConfigurationBuilder
                 * 
                 */

                ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
                configurationBuilder.AddJsonFileData("C:\\123.json");
                MConfiguration configuration = configurationBuilder.Build();
                string data = configuration["data"];
            }
            #endregion
        }
    }
}
