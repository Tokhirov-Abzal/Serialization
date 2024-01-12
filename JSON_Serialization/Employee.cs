using System;
using System.Runtime.Serialization;

namespace JSON_Serialization
{
    [Serializable]
    public class Employee : ISerializable
    {
        public string EmployeeName { get; set; }

        public Employee() { }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("EmployeeName", EmployeeName);
        }

        public Employee(SerializationInfo info, StreamingContext context)
        {
            EmployeeName = (string)info.GetValue("EmployeeName", typeof(string));
        }

        public override string ToString()
        {
            return EmployeeName.ToString();
        }
    }
}
