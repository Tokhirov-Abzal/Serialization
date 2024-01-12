using System.Runtime.Serialization.Formatters.Binary;

namespace Custom_Serialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomSerializableClass customObject = new CustomSerializableClass
            {
                Property1 = 42,
                Property2 = "Hello, Serialization!"
            };


            using (FileStream stream = new FileStream("customSerializedObject.bin", FileMode.Create))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(stream, customObject);
            }


            using (FileStream stream = new FileStream("customSerializedObject.bin", FileMode.Open))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                CustomSerializableClass deserializedObject = (CustomSerializableClass)binaryFormatter.Deserialize(stream);

                Console.WriteLine($"Property1: {deserializedObject.Property1}");
                Console.WriteLine($"Property2: {deserializedObject.Property2}");
            }
        }
    }
}