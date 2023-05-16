using MCC78.Model;
using MCC78.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC78.Controller
{
    public class EducationController
    {
        private static Education _education = new Education();
        public void GetAll()
        {
            var results = _education.GetEducation();
            var view = new EducationView();
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

        public void Insert(Education education)
        {
            var result = _education.InsertEducation(education);
            var view = new EducationView();
            if (result == 0)
            {
                view.Output("Insert Education Failed");
            }
            else
            {
                view.Output("Insert Education Success");
            }
        }

        public void Update(Education education)
        {
            var results = _education.UpdateEducation(education);
            var view = new EducationView();
            if (results > 0)
            {
                view.Output("Update Success");
            }
            else
            {
                view.Output("Update Failed");
            }
        }
        public void Delete(Education education)
        {
            var result = _education.DeleteEducation(education);
            var view = new EducationView();
            if (result > 0)
            {
                view.Output("Delete Success");
            }
            else
            {
                view.Output("Delete Failed");
            }
        }

        public void LinqGPA()
        {
            var results = _education.GetEducation();
            var getGpa = results.Where(u => u.GPA == "4");
            var view = new EducationView();
            if (results.Count == 0)
            {
                view.Output("Data Tidak Ditemukan");
            }
            else
            {
                view.Output(results);
            }
        }
    }
}
