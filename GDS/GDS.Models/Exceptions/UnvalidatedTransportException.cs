using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GDS.Models.Exceptions
{
    public class UnvalidatedTransportException : Exception
    {
        //ctor
        public UnvalidatedTransportException() : base("Can not validate Transport.")
        {

        }
    }
}
