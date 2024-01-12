using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace Deep_Cloning
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Department originalDepartment = new Department
            {
                DepartmentName = "IT",
                Employees = new List<Employee>
            {
                new Employee { EmployeeName = "John Doe" },
                new Employee { EmployeeName = "Alan Wake" }
            }
            };


            Department clonedDepartmentBinary = DeepClone(originalDepartment, SerializationType.Binary);
            Department clonedDepartmentXml = DeepClone(originalDepartment, SerializationType.Xml);
            Department clonedDepartmentJson = DeepClone(originalDepartment, SerializationType.Json);

            originalDepartment.DepartmentName = "New IT Department";
            originalDepartment.Employees[0].EmployeeName = "Updated John Doe";


            Console.WriteLine("Original Department:");
            DisplayDepartment(originalDepartment);

            Console.WriteLine("\nCloned Department (Binary Serialization):");
            DisplayDepartment(clonedDepartmentBinary);

            Console.WriteLine("\nCloned Department (XML Serialization):");
            DisplayDepartment(clonedDepartmentXml);

            Console.WriteLine("\nCloned Department (JSON Serialization):");
            DisplayDepartment(clonedDepartmentJson);
        }

        static T DeepClone<T>(T original, SerializationType serializationType)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                switch (serializationType)
                {
                    case SerializationType.Binary:
                        BinaryFormatter binaryFormatter = new BinaryFormatter();
                        binaryFormatter.Serialize(memoryStream, original);
                        memoryStream.Seek(0, SeekOrigin.Begin);
                        return (T)binaryFormatter.Deserialize(memoryStream);

                    case SerializationType.Xml:
                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                        xmlSerializer.Serialize(memoryStream, original);
                        memoryStream.Seek(0, SeekOrigin.Begin);
                        return (T)xmlSerializer.Deserialize(memoryStream);

                    case SerializationType.Json:
                        string json = JsonConvert.SerializeObject(original);
                        T clonedObject = JsonConvert.DeserializeObject<T>(json);
                        return clonedObject;

                    default:
                        throw new ArgumentException("Invalid serialization type");
                }
            }
        }

        static void DisplayDepartment(Department department)
        {
            Console.WriteLine($"Department Name: {department.DepartmentName}");
            Console.WriteLine("Employees:");
            foreach (Employee employee in department.Employees)
            {
                Console.WriteLine($"  - {employee.EmployeeName}");
            }
            Console.WriteLine();
        }

        enum SerializationType
        {
            Binary,
            Xml,
            Json
        }
    }
}