using MCC78.Model;
using MCC78.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC78.Controller
{
    public class ProfilingController
    {
        private Profiling _profiling = new Profiling();
        public void GetAll()
        {
            var results = _profiling.GetProfiling();
            var view = new ProfilingView();
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

        public void Insert(Profiling profilings)
        {
            var result = _profiling.InsertProfiling(profilings);
            var view = new ProfilingView();
            if (result == 0)
            {
                view.Output("Insert Profiling Failed");
            }
            else
            {
                view.Output("Insert Profiling Success");
            }
        }
    }
}
