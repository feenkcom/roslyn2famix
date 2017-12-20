using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Basic
{
    class Exceptions : Exception
    {
        private void Method()
        {
            try
            {
                //something something
            }
            catch (Exceptions e)
            {
                throw this;
                throw new DivideByZeroException();
            }
        }
    }
}
