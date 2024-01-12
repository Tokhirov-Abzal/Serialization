using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace Custom_Serialization
{
    [Serializable]
    public class CustomSerializableClass : ISerializable
    {
        public int Property1 { get; set; }
        public string Property2 { get; set; }

        public CustomSerializableClass() { }
        protected CustomSerializableClass(SerializationInfo info, StreamingContext context)
        {
            Property1 = info.GetInt32("Property1");
            Property2 = info.GetString("Property2");
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Property1", Property1);
            info.AddValue("Property2", Property2);
        }
    }
}
