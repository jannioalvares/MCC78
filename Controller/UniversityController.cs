using MCC78.Model;
using MCC78.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC78.Controller
{
    public class UniversityController
    {
        private University _university = new University();

        public void GetAll()
        {
            var results = _university.GetUniversities();
            var view = new UniversityView();
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

        public void Insert(University university)
        {
            var result = _university.InsertUniversity(university);
            var view = new UniversityView();
            if (result == 0)
            {
                view.Output("Insert University Failed");
            }
            else
            {
                view.Output("Insert University Success");
            }
        }

        public void Update(University university)
        {
            var result = _university.UpdateUniversity(university);
            var view = new UniversityView();
            if (result > 0)
            {
                view.Output("Update Success");
            }
            else
            {
                view.Output("Update Failed");
            }
        }

        public void Delete(University university)
        {
            var result = _university.DeleteUniversity(university);
            var view = new UniversityView();
            if (result > 0)
            {
                view.Output("Delete Success");
            }
            else
            {
                view.Output("Delete Failed");
            }
        }
    }
}
