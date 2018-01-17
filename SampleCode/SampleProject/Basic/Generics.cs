using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Basic
{

    public class SubGenerics<T> : Generics<T> { }

    public class Jumper
    {
        Generics<int> Jump(Generics<int> input)
        {
            return input;
        }
    }

    public class Generics<T>
    {
       T Method (T param)
       {
            return param;
       }
    }
}
