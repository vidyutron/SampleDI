using SampleDI.AppLogic;
using System;
using System.Windows.Forms;

namespace SampleDI
{
    public partial class Form1 : Form
    {
        private IUtil _util;
        private IConfig _config;

        public Form1(IUtil util,IConfig config)
        {
            _util = util;
            _config = config;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _util.SampleUtilOp();          
        }
    }
}
