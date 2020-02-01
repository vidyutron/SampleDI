using SampleDI.AppLogic;
using System.Windows.Forms;

namespace SampleDI
{
    public class Startup
    {
        private IUtil _util;
        private IConfig _config;

        public Startup(IUtil util,IConfig config)
        {
            _util = util;
            _config = config;
        }

        public void Run()
        {
            var form = new Form1(_util,_config);
            Application.Run(form);
        }
    }
}
