using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Basic
{
    public class EventDelegateClass
    {
        public delegate void MyDelegate();
        public event MyDelegate MyEvent;

        public void MyDelegateHandler() { }


        void StepThree(object[] args)
        {
            MyEvent += MyDelegateHandler;
        }

        void Trigger()
        {
            MyEvent();
        }
    }
}
