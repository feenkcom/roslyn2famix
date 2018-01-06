using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Basic
{
    class ReturnType
    {
        void Method() { }

        int IntMethod()
        {
            return 1;
        }

        ReturnType ReturnMethod()
        {
            return this;
        }

        List<ReturnType> GenericListMethod() => new List<ReturnType>();

        Generics<ReturnType> GenericReturnTypeMethod()
        {
            return null;
        }

    }
}
