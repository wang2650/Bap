using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Xml.Serialization;
namespace CommonLib.Tools
{
    public interface IDataSerializer
    {
        /// <summary>
        /// 序列化
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="obj">object</param>
        /// <returns>bytes</returns>
        byte[] Serialize<T>(T obj);

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="bytes">bytes</param>
        /// <returns>obj</returns>
        T Deserialize<T>(byte[] bytes);
    }

    public class DataSerializerHelper
    {


        public class BinaryDataSerializer : IDataSerializer
        {
            private readonly BinaryFormatter _binaryFormatter = new BinaryFormatter();

            public T Deserialize<T>(byte[] bytes)
            {
                if (typeof(Task).IsAssignableFrom(typeof(T)))
                {
                    throw new ArgumentException("BinaryDataSerializer反序列化错误");
                }
                using (var memoryStream = new MemoryStream(bytes))
                {
                    return (T)_binaryFormatter.Deserialize(memoryStream);
                }
            }

            public byte[] Serialize<T>(T obj)
            {
                if (typeof(Task).IsAssignableFrom(typeof(T)))
                {
                    throw new ArgumentException("BinaryDataSerializer序列化错误");
                }
                using (var memoryStream = new MemoryStream())
                {
                    _binaryFormatter.Serialize(memoryStream, obj);
                    return memoryStream.ToArray();
                }
            }
        }

        public class XmlDataSerializer : IDataSerializer
        {
            public static Lazy<XmlDataSerializer> Instance = new Lazy<XmlDataSerializer>();

            public T Deserialize<T>(byte[] bytes)
            {
                if (typeof(Task).IsAssignableFrom(typeof(T)))
                {
                    throw new ArgumentException("XmlDataSerializer反序列化错误");
                }
                using (var ms = new MemoryStream(bytes))
                {
                    var serializer = new XmlSerializer(typeof(T));
                    return (T)serializer.Deserialize(ms);
                }
            }

            public byte[] Serialize<T>(T obj)
            {
                if (typeof(Task).IsAssignableFrom(typeof(T)))
                {
                    throw new ArgumentException("XmlDataSerializer序列化错误");
                }
                using (var ms = new MemoryStream())
                {
                    var serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(ms, obj);
                    return ms.ToArray();
                }
            }
        }




    }
}
