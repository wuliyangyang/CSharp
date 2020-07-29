using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace DesignMode2.Prototype
{
    /// <summary>
    /// 视频类
    /// </summary>
    [Serializable]
    public class Video : ICloneable
    {
        public string Id { get; set; }//编号
        public string Content { get; set; }//内容

        public string Watermark { get; set; }//水印

        public DateTime DateTime { get; set; }

        public object Clone()
        {
            //1.浅拷贝 无法拷贝引用类型的内存空间
            object obj = this.MemberwiseClone();

            //2.深拷贝
            //中间流
            using (MemoryStream memoryStream = new MemoryStream())
            {
                //序列化类
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(memoryStream, this);

                memoryStream.Position = 0;
                return binaryFormatter.Deserialize(memoryStream);
            }
            // return obj;
        }
    }
}
