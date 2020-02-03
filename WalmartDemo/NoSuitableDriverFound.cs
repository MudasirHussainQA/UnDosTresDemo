using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalmartDemo
{
    class NoSuitableDriverFound : Exception
    {
        public NoSuitableDriverFound(string msg) : base(msg)
        {

        }
    }
}
