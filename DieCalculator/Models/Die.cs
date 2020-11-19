using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DieCalculator.Models
{
    public class Die
    {
        public Die(int maxVal)
        {
            MaxVal = maxVal;
        }
        private int _maxVal { get; set; }
        public int MaxVal { get { return _maxVal; } set {
                _maxVal = value < 1 ? 1 : value;
            } }
        public double AnyNumProb { get { return 1.0 / MaxVal; } }
    }
}
