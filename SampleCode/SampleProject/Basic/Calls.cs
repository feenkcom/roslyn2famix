using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Basic
{
    class Called
    {
        public void CalledMethod()
        {
        }
    }

    class StandardCaller
    {
        public void CallerMethod()
        {
            new Called().CalledMethod();
        }
    }

    class InlineCaller
    {
        public void CallerMethod() => new Called().CalledMethod();
    }
}
