using DomainLayer.Fork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.BusinessLogic
{
    public class Operations : IOperations
    {
        private IDataAccess _da;
        private ILogger _log;

        public Operations(IDataAccess da,ILogger log)
        {
            _da = da;
            _log = log;
        }
        public string PerformCRUD()
        {
            string perf = string.Empty;
            _da.Connect();
            perf += $"{perf}connection successful{Environment.NewLine}";
            _log.Log(perf);
            _da.UpdateData();
            perf += $"{perf}update successful";
            _log.Log(perf);

            return perf;

        }

        public string SecondOperations()
        {
            return "simple second operation";
        }
    }
}
