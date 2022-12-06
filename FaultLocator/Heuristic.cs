using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FaultLocator
{
    public class Heuristic : IHeuristic
    {
        public double CalculateHeuristic1(Input input)
        {
            return input.failed;
        }

        public double CalculateHeuristic2(Input input)
        {
            return input.failed - input.passed;
        }

        public double CalculateHeuristic3(Input input)
        {
            if (input.passed < 3)
            {
                return input.failed - input.passed;
            }
            else if (input.passed > 2 && input.passed < 11)
            {
                return input.failed - 2 + (input.passed - 2) * 0.1;
            }
            else
            {
                return input.failed - 2.8 + (input.passed - 10) * 0.01;
            }
        }
    }
}
