using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.Fork
{
    public interface IDataAccess
    {
        void Connect();
        void QueryData();
        void UpdateData();
    }
}
