using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Basic
{
    class Called
    {
        public int CalledMethod()
        {



            return 1;
        }
    }

    class StandardCaller
    {
        public StandardCaller CallerMethod()
        {
            new Called().CalledMethod();
            return null;
        }
    }

    class InlineCaller
    {
        public void CallerMethod() => new Called().CalledMethod();
    }
}
