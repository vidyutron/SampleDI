using SampleDI.AppLogic;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SampleDI
{
    public partial class Form1 : Form
    {
        private IUtil _util;

        public Form1(IUtil util)
        {
            _util = util;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _util.SampleUtilOp();          
        }
    }
}
