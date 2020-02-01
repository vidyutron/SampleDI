using System;
using System.Windows.Forms;
using Autofac;

namespace SampleDI
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var bootstrap = Bootstrap.Configure();
            using(var scope = bootstrap.BeginLifetimeScope())
            {
                var startup = scope.Resolve<Startup>();
                startup.Run();
            }
        }
    }
}
