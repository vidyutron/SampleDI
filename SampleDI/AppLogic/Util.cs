using DomainLayer.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDI.AppLogic
{
    public class Util : IUtil
    {
        private IConfig _config;
        private IOperations _ops;

        public Util(IConfig config,IOperations ops)
        {
            _config = config;
            _config.LoadConfig();
            _ops = ops;
        }
        public void SampleUtilOp()
        {
            string tst=_config.settings.ToString();
            string tst2 = _ops.PerformCRUD();
        }
    }
}
