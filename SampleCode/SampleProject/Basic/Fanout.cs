using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Basic
{
    class Fanin1
    {
        static public void Called() { }
    }

    class Fanin2
    {
        static public void Called() { }
    }

    class Fanout
    {
        public void Caller()
        {
            Fanin1.Called();
            Fanin1.Called();
        }
        public void Calle2()
        {
            Fanin1.Called();
            Fanin1.Called();
        }

        public void Calle3()
        {
            Fanin2.Called();
            this.Caller();
        }

    }
}
