using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Concurrent;

namespace SampleProject.Basic
{
    class ExpressionBody
    {

        private static ConcurrentDictionary<int, string> names = new ConcurrentDictionary<int, string>();
        private int id = 1;

        public ExpressionBody(string name) => names.TryAdd(id, name); // constructors
        ~ExpressionBody() => names.TryRemove(id, out _);              // finalizers
        public string Name
        {
            get => names[id];                                 // getters
            set => names[id] = value;                         // setters
        }
    }
}
