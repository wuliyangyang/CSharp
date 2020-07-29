using DesignMode1.AbstractFactory;
using DesignMode1.AbstractFactory.ColorFactory;
using DesignMode1.AbstractFactory.ShapeFactory;
using DesignMode1.Factory;
using DesignMode1.Strategy;
using System;

namespace DesignMode1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            /*验证码场景：条件（区域、颜色、字体）
             * 开始：客户-->>画验证码区域-->>图形
             * 工厂模式：客户-->>画验证码区域-->>图形接口-->>图形
             */
            #region 1、工厂模式
            {
                //IShape circle = ShapeFactory.GetShape("Circle");
                //circle.Draw();

                //IShape rectangle = ShapeFactory.GetShape("Rectangle");
                //rectangle.Draw();

                //IShape square = ShapeFactory.GetShape("Square");
                //square.Draw();
            }
            #endregion

            #region 2、抽象工厂模式
            {
                //FactoryProducter factoryProducter = new FactoryProducter();

                //MAbstractFactory shapeFactory = factoryProducter.GetFactory("shape");

                //MAbstractFactory colorFactory = factoryProducter.GetFactory("color");

                //IObject circle = shapeFactory.GetT("Circle");
                //circle.Do();

                //IObject color = colorFactory.GetT("Red");
                //color.Do();
            }
            #endregion

            #region 3、策略模式
            {
                //策略模式 取代if else，但是并不是简单取代，是根据不同的环境选择不同的策略
                //选择不同的环境情况时，会有不同的表现（策略只和环境有关）
                Context context = new Context(new AddOperation());
                int ret =  context.ExecuteStrategy(1, 3);
                Console.WriteLine($"ret:{ret}");

            }
            #endregion
            Console.ReadKey();
        }

    }
}
