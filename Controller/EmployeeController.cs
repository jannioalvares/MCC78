using MCC78.Model;
using MCC78.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC78.Controller
{
    public class EmployeeController
    {
        private static Employee _employee = new Employee();

        public void GetAll()
        {
            var results = _employee.GetEmployee();
            var view = new EmployeeView();
            view.Title();
            if (results.Count == 0)
            {
                view.Output("Data Tidak Ditemukan");
            }
            else
            {
                view.Output(results);
            }
        }

        public void Insert(Employee employees)
        {
            var result = _employee.InsertEmployee(employees);
            var view = new EmployeeView();
            if (result == 0)
            {
                view.Output("Insert Employee Failed");
            }
            else
            {
                view.Output("Insert Employee Success");
            }
        }
    }
}
