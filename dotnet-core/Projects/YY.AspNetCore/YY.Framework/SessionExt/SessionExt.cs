using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace YY.Framework.SessionExt
{
    public static class SessionExt
    {
        public static string GetString(this ISession session,string key)
        {
            byte[] dataBuffer;
            bool b  = session.TryGetValue(key, out dataBuffer);
            if (dataBuffer == null) return null;
            string dataStr = BytesToObject(dataBuffer).ToString();
            return dataStr;
        }

        public static byte[] GetBytes(this ISession session, string key)
        {
            byte[] dataBuffer;
            bool b = session.TryGetValue(key, out dataBuffer);
            return dataBuffer;
        }

        public static object GetObject(this ISession session, string key)
        {
            byte[] dataBuffer;
            bool b = session.TryGetValue(key, out dataBuffer);
            if (dataBuffer == null) return null;
            return BytesToObject(dataBuffer);
        }
        public static void SetObject(this ISession session, string key,object value)
        {
            byte[] dataBuffer = ObjectToBytes(value);
            session.Set(key, dataBuffer);
        }
        public static void SetString(this ISession session, string key, string value)
        {
            byte[] dataBuffer = ObjectToBytes(value);
            session.Set(key, dataBuffer);
        }
        /// <summary> 
        /// 将一个object对象序列化，返回一个byte[]         
        /// </summary> 
        /// <param name="obj">能序列化的对象</param>         
        /// <returns></returns> 
        public static byte[] ObjectToBytes(object obj)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                IFormatter formatter = new BinaryFormatter(); formatter.Serialize(ms, obj); return ms.GetBuffer();
            }
        }

        /// <summary> 
        /// 将一个序列化后的byte[]数组还原         
        /// </summary>
        /// <param name="Bytes"></param>         
        /// <returns></returns> 
        public static object BytesToObject(byte[] Bytes)
        {
            using (MemoryStream ms = new MemoryStream(Bytes))
            {
                IFormatter formatter = new BinaryFormatter(); return formatter.Deserialize(ms);
            }
        }
    }
}
