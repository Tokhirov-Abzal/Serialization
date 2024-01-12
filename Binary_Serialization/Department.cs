using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace Binary_Serialization
{
    [Serializable]
    public class Department : ISerializable
    {
        public string DepartmentName { get; set; }
        public List<Employee> Employees { get; set; }

        public Department() { }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("DepartmentName", DepartmentName);
            info.AddValue("Employees", Employees);
        }

        public Department(SerializationInfo info, StreamingContext context)
        {
            DepartmentName = (string)info.GetValue("DepartmentName", typeof(string));
            Employees = (List<Employee>)info.GetValue("Employees", typeof(List<Employee>));
        }

        public override string ToString()
        {
            return string.Format($"{DepartmentName}: Employees {string.Join(",", Employees)}");
        }
    }
}
