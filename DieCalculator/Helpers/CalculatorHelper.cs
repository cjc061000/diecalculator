using DieCalculator.Models;
using DieCalculator.Models.ViewModels;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DieCalculator.Helpers
{
    public static class CalculatorHelper
    {
        public static CalculatedProbabilityVM CalculateDiceProb(DieFormSubmit frm)
        {
            var rule = frm.rule;
            int.TryParse(frm.dieType, out int dieType);
            int.TryParse(frm.dieCount, out int dieCount);
            int.TryParse(frm.targetValue, out int targetValue);
            int.TryParse(frm.targetCount, out int targetCount);
            
            var pcntFormat = "F2";
            
            switch (rule)
            {
                // probability of:
                // at least X die roll the target value or higher
                // P(at least 1) = 1 - P(event never occurs)
                // P(event never occurs) = (max-target+1)/max
                // Pk = C * (P^k) * [(1-P)^(N-K)]
                // Pn = Pk1 + Pk2 + ... Pkn
                case DieCalculator.Constants.FEValues.Rules.AtLeastX_GTEQ:
                    var p = ((dieType - targetValue + 1)*1.0) / (dieType*1.0); //probability of success for single die
                    var n = dieCount;//number of tries or die
                    var pn = 0.0;
                    for (int k = targetCount; k <= dieCount; k++)
                    {
                        var pk = PermutationsAndCombinations.nCr(n, k) * ( Math.Pow(p, k)) * Math.Pow((1 - p),(n - k));
                        pn += pk;
                    }
                    return new CalculatedProbabilityVM() { ProbabilityPcnt = $"{Math.Round(pn,2).ToString(pcntFormat)}%" };


                default:
                    break;
            }
            return new CalculatedProbabilityVM() { ProbabilityPcnt = "-1%" };
        }
    }
}
