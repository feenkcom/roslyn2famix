using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleProject.Basic
{
    class Properties
    {
        private void Method() { }
        private int Value
        {
            set
            {
                Method();
                Value = value;
            }
        }

        private double seconds;
        
        public double Hours
        {
            get { return seconds / 3600; }
            set
            {
                if (value < 0 || value > 24)
                    throw new ArgumentOutOfRangeException(
                          $"{nameof(value)} must be between 0 and 24.");

                seconds = value * 3600;
            }
        }

        private string firstName;
        private string lastName;

        public Properties(string first, string last)
        {
            firstName = first;
            lastName = last;
        }

        public string Name => $"{firstName} {lastName}";
    }


    public class SaleItem
    {
        string name;
        decimal cost;

        public SaleItem(string name, decimal cost)
        {
            this.name = name;
            this.cost = cost;
        }

        public string Name
        {
            get => name;
            set => name = value;
        }

        public decimal Price
        {
            get => cost;           
            set => cost = value;
        }
    }
}
