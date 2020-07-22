#coding:utf-8
import clr  #clr是公共运行时环境，这个模块是与C#交互的核心

clr.FindAssembly("ClassLibrary1.dll") ## 加载c#dll文件

 

from ClassLibrary1 import *    # 导入命名空间

instance = Class1() #class1是dll里面的类

print(instance.Add(2, 3))#一个简单的加法

