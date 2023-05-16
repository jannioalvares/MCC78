using MCC78.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC78.View
{
    public class EmployeeView
    {
        public void Output(Employee employee)
        {
            Console.WriteLine("Id            : " + employee.Id);
            Console.WriteLine("NIK           : " + employee.Nik);
            Console.WriteLine("First Name    : " + employee.FirstName);
            Console.WriteLine("Last Name     : " + employee.LastName);
            Console.WriteLine("Birthdate     : " + employee.Birthdate);
            Console.WriteLine("Gender        : " + employee.Gender);
            Console.WriteLine("Hiring Date   : " + employee.HiringDate);
            Console.WriteLine("Email         : " + employee.Email);
            Console.WriteLine("Phone Number  : " + employee.PhoneNumber);
            Console.WriteLine("Department ID : " + employee.DepartmentId);
            Console.WriteLine("-------------------------------------------------------");
        }

        public void Output(List<Employee> employees)
        {
            foreach (var employee in employees)
            {
                Output(employee);
            }
        }

        public void Output(string message)
        {
            Console.WriteLine(message);
        }

        public void Title()
        {
            Console.WriteLine("\nSELECT ALL FROM EMPLOYEE");
            Console.WriteLine("-----------------------------------------");
        }
    }
}
