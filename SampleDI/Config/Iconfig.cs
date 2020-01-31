using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDI
{
    public interface IConfig
    {
        Dictionary<string, string> settings { get; set; }
        void LoadConfig();
    }
}
