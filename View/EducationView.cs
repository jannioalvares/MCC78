using MCC78.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC78.View
{
    public class EducationView
    {
        public void Output(Education education)
        {
            Console.WriteLine("Id: " + education.Id);
            Console.WriteLine("Major: " + education.Major);
            Console.WriteLine("Degree: " + education.Degree);
            Console.WriteLine("GPA: " + education.GPA);
            Console.WriteLine("Universty Id : " + education.UniversityId);
            Console.WriteLine("-----------------------------------------");
        }

        public void Output(List<Education> educations)
        {
            foreach (var education in educations)
            {
                Output(education);
            }
        }

        public void Output(string message)
        {
            Console.WriteLine(message);
        }

        public void Title()
        {
            Console.WriteLine("\nSELECT ALL FROM EDUCATION");
            Console.WriteLine("-----------------------------------------");
        }
    }
}
