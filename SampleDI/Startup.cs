using SampleDI.AppLogic;
using System.Windows.Forms;

namespace SampleDI
{
    public class Startup
    {
        private IUtil _util;

        public Startup(IUtil util)
        {
            _util = util;
        }

        public void Run()
        {
            var form = new Form1(_util);
            Application.Run(form);
        }
    }
}
