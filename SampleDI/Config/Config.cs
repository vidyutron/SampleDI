using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleDI
{
    public class Config:IConfig
    {
        public Dictionary<string,string> settings { get; set; }

        public void LoadConfig()
        {
            settings = new Dictionary<string, string>
            {
                { "key1","value1" },
                { "key2","value2" },
                { "key3","value3" }
            };
        }
    }
}
