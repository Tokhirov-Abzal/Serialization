using Newtonsoft.Json;
using System.IO;

namespace JSON_Serialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Department department = new Department
            {
                DepartmentName = "Finance",
                Employees = new List<Employee>
            {
                new Employee { EmployeeName = "Charlie" },
                new Employee { EmployeeName = "David" }
            }
            };


            string json = JsonConvert.SerializeObject(department);
            File.WriteAllText("department.json", json);


            string jsonFromFile = File.ReadAllText("department.json");
            Department deserializedDepartment = JsonConvert.DeserializeObject<Department>(jsonFromFile);

            Console.WriteLine($"Department: {deserializedDepartment.DepartmentName}");
            foreach (Employee employee in deserializedDepartment.Employees)
            {
                Console.WriteLine($"Employee: {employee.EmployeeName}");
            }
        }
    }
}