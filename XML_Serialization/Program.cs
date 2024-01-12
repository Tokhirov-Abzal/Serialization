using System.Xml.Serialization;
using System.IO;

namespace XML_Serialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Department department = new Department
            {
                DepartmentName = "HR",
                Employees = new List<Employee>
            {
                new Employee { EmployeeName = "Alice" },
                new Employee { EmployeeName = "Bob" }
            }
            };

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Department));

            using (FileStream stream = new FileStream("department.xml", FileMode.Create))
            {
                xmlSerializer.Serialize(stream, department);
            }

            using (FileStream stream = new FileStream("department.xml", FileMode.Open))
            {
                Department deserializedDepartment = (Department)xmlSerializer.Deserialize(stream);
                Console.WriteLine($"Department: {deserializedDepartment.DepartmentName}");
                foreach (Employee employee in deserializedDepartment.Employees)
                {
                    Console.WriteLine($"Employee: {employee.EmployeeName}");
                }
            }
        }
    }
}