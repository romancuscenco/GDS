using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Models.Exceptions
{
    public class RetireWorkingTransportException : Exception
    {
        //ctor
        public RetireWorkingTransportException()
            : base("You cannot retire a transport in work state")
        {

        }
    }
}
