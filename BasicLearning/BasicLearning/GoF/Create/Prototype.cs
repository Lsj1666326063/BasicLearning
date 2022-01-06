using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace BasicLearning
{
    [Serializable]
    public class Prototype//:ICloneable
    {
        public int Num = 0;
        public PrototypeTestObj protoTypeTestObj;

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public object DeepClone()
        {
            // 使用流进行深拷贝 相关类必须添加属性标记 [Serializable]
            using (Stream stream = new MemoryStream())
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream,this);
                stream.Seek(0, SeekOrigin.Begin);
                return formatter.Deserialize(stream);
            }
        }
    }

    [Serializable]
    public class PrototypeTestObj
    {
        public int Num = 0;
    }
}