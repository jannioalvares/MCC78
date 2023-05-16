using MCC78.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC78.View
{
    public class ProfilingView
    {
        public void Output(Profiling profiling)
        {
            Console.WriteLine("");
            Console.WriteLine("Employee ID  : " + profiling.EmployeeId);
            Console.WriteLine("Education ID : " + profiling.EducationId);
            Console.WriteLine("----------------------------------------------------------");
        }
        public void Output(List<Profiling> profilings)
        {
            foreach (var profiling in profilings)
            {
                Output(profiling);
            }
        }

        public void Output(string message)
        {
            Console.WriteLine(message);
        }

        public void Title()
        {
            Console.WriteLine("\nSELECT ALL FROM PROFILING");
            Console.WriteLine("-----------------------------------------");
        }
    }
}
