using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Basic
{
    [System.AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
    sealed class AnnotationAttribute : System.Attribute
    {
        readonly string firstString;
        
        // This is a positional argument
        public AnnotationAttribute(string firstString)
        {
            this.firstString = firstString;
        }

        public string FirstString
        {
            get { return firstString; }
        }

        // This is a named argument
        public int NamedInt { get; set; }
    }
}
