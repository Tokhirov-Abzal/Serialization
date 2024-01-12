using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;

namespace Binary_Serialization
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Department department = new Department
            {
                DepartmentName = "IT",
                Employees = new List<Employee>
            {
                new Employee { EmployeeName = "John Doe" },
                new Employee { EmployeeName = "Alan Wake" }
            }
            };


            Stream stream = File.Open("Department.dat", FileMode.Create);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, department);
            stream.Close();

            department = null;

            stream = File.Open("Department.dat", FileMode.Open);
            bf = new BinaryFormatter();
            department = (Department)bf.Deserialize(stream);
            stream.Close();
            Console.WriteLine(department.ToString());


        }
    }
}