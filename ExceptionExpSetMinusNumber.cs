using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrosoSleep
{
    class ExceptionExpSetMinusNumber : Exception
    {
        
        public ExceptionExpSetMinusNumber(string message)
            : base(message)
        {
        }

    }
}
