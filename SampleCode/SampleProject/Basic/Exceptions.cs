using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Basic
{
    class Exceptions<T> : Exception
    {
        private void Method()
        {
            try
            {
                //something something
            }
            catch (Exceptions<T> e)
            {
                throw new Exceptions<String>();
                throw new DivideByZeroException(); 
            }
        }
    }
}
