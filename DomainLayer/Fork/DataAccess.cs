using System;

namespace DomainLayer.Fork
{
    public class DataAccess : IDataAccess
    {
        ILogger _logger;
        public DataAccess(ILogger logger)
        {
            _logger = logger;
        }
        public void Connect()
        {
            string tst = "Connection Successful";
            Console.WriteLine(tst);
            _logger.Log(tst);
        }

        public void QueryData()
        {
            string tst = "Querying Data";
            Console.WriteLine(tst);
            _logger.Log(tst);
        }

        public void UpdateData()
        {
            string tst = "Updating Data";
            Console.WriteLine(tst);
            _logger.Log(tst);
        }
    }
}
