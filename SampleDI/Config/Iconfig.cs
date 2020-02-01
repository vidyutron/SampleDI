using System.Collections.Generic;

namespace SampleDI
{
    public interface IConfig
    {
        Dictionary<string, string> settings { get; set; }
        void LoadConfig();
    }
}
