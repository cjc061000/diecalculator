using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DieCalculator.Models
{
    public class DieFormSubmit
    {
        public string rule { get; set; }
        public string dieCount { get; set; }
        public string dieType { get; set; }
        public string targetCount { get; set; }
        public string targetValue { get; set; }
    }
}
